#!/bin/bash

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

# Verify a document signature
if [ -z "$1" ] || [ -z "$2" ]; then
    echo "Usage: ./verify_signature.sh <username> <document_file>"
    echo "Example: ./verify_signature.sh alice message.txt"
    exit 1
fi

USERNAME=$1
DOCUMENT="$2"
SIGNATURE_FILE="${DOCUMENT}.sig"

if [ ! -f "$DOCUMENT" ]; then
    echo "Error: Document '$DOCUMENT' not found!"
    exit 1
fi

if [ ! -f "$SIGNATURE_FILE" ]; then
    echo "Error: Signature file '$SIGNATURE_FILE' not found!"
    exit 1
fi

# Convert paths to absolute before changing directory
DOCUMENT="$(readlink -f "$DOCUMENT")"
SIGNATURE_FILE="$(readlink -f "$SIGNATURE_FILE")"

# Now cd to pki directory
cd "$SCRIPT_DIR/../pki"

if [ ! -f "users/$USERNAME/${USERNAME}-cert.pem" ]; then
    echo "Error: Certificate for user '$USERNAME' not found!"
    exit 1
fi

echo "Verifying Document Signature..."
echo "Document: $DOCUMENT"
echo "Signer: $USERNAME"
echo ""

echo "Step 1: Extracting public key from certificate..."
openssl x509 -in users/$USERNAME/${USERNAME}-cert.pem \
             -pubkey -noout > users/$USERNAME/${USERNAME}-pubkey.pem

echo ""
echo "Step 2: Verifying signature with public key..."
openssl dgst -sha256 \
            -verify users/$USERNAME/${USERNAME}-pubkey.pem \
            -signature "$SIGNATURE_FILE" \
            "$DOCUMENT"

VERIFY_RESULT=$?

echo ""
if [ $VERIFY_RESULT -eq 0 ]; then
    echo "Signature verification SUCCESSFUL"
    echo "  - The document was signed by $USERNAME"
    echo "  - The document has NOT been modified since signing"
else
    echo "Signature verification FAILED"
    echo "  - Document may have been modified"
    echo "  - OR signature was created with different key"
fi

echo ""
echo "Step 3: Checking if certificate is revoked..."
if [ -f "ca/crl/crl.pem" ]; then
    openssl verify -crl_check \
                   -CRLfile ca/crl/crl.pem \
                   -CAfile ca/certs/ca-cert.pem \
                   users/$USERNAME/${USERNAME}-cert.pem
    
    if [ $? -eq 0 ]; then
        echo "Certificate is VALID and NOT REVOKED"
    else
        echo "WARNING: Certificate has been REVOKED"
    fi
else
    echo "No CRL found, skipping revocation check"
fi