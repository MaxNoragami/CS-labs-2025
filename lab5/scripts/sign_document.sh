#!/bin/bash

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR/../pki"

# Sign a document with user's private key
if [ -z "$1" ] || [ -z "$2" ]; then
    echo "Usage: ./03_sign_document.sh <username> <document_file>"
    echo "Example: ./03_sign_document.sh maxim message.txt"
    exit 1
fi

USERNAME=$1
DOCUMENT=$2

if [ ! -f "$DOCUMENT" ]; then
    echo "Error: Document '$DOCUMENT' not found!"
    exit 1
fi

if [ ! -f "users/$USERNAME/${USERNAME}-key.pem" ]; then
    echo "Error: Private key for user '$USERNAME' not found!"
    exit 1
fi

echo "=== Signing Document: $DOCUMENT ==="
echo "User: $USERNAME"
echo ""

SIGNATURE_FILE="${DOCUMENT}.sig"

echo "Creating digital signature..."
# Sign the document, hash + encrypt
openssl dgst -sha256 \
            -sign users/$USERNAME/${USERNAME}-key.pem \
            -out "$SIGNATURE_FILE" \
            "$DOCUMENT"

echo ""
echo "Signature Created Successfully"
echo "Original document: $DOCUMENT"
echo "Signature file: $SIGNATURE_FILE"
echo ""
echo "To verify this signature, use: ./verify_signature.sh $USERNAME $DOCUMENT"