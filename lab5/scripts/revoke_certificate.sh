#!/bin/bash

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR/../pki"

# Revoke a user certificate
if [ -z "$1" ]; then
    echo "Usage: ./revoke_certificate.sh <username>"
    echo "Example: ./revoke_certificate.sh maxim"
    exit 1
fi

USERNAME=$1

if [ ! -f "users/$USERNAME/${USERNAME}-cert.pem" ]; then
    echo "Error: Certificate for user '$USERNAME' not found!"
    exit 1
fi

echo "Revoking Certificate for User: $USERNAME"
echo ""

echo "Step 1: Revoking certificate..."
openssl ca -config ca/openssl-ca.conf \
           -revoke users/$USERNAME/${USERNAME}-cert.pem

echo ""
echo "Step 2: Generating Certificate Revocation List (CRL)..."
openssl ca -config ca/openssl-ca.conf \
           -gencrl \
           -out ca/crl/crl.pem

echo ""
echo "Step 3: Viewing CRL contents..."
openssl crl -in ca/crl/crl.pem -noout -text

echo ""
echo "Certificate Revoked Successfully"
echo "Updated CRL: ca/crl/crl.pem"