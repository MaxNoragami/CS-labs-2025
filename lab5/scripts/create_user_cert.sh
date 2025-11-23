#!/bin/bash

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR/../pki"

# Generate user certificate

# Check if username provided
if [ -z "$1" ]; then
    echo "Usage: ./create_user_cert.sh <username>"
    echo "Example: ./create_user_cert.sh maxim"
    exit 1
fi

USERNAME=$1

echo "Creating Certificate for User: $USERNAME"
echo ""

mkdir -p users/$USERNAME

echo "Step 1: Generating user private key (2048 bits RSA)..."
openssl genrsa -out users/$USERNAME/${USERNAME}-key.pem 2048

echo ""
echo "Step 2: Creating Certificate Signing Request (CSR)..."
# Generate CSR - this contains the user's public key and identity info
openssl req -config ca/openssl-ca.conf \
            -new \
            -key users/$USERNAME/${USERNAME}-key.pem \
            -out users/$USERNAME/${USERNAME}-csr.pem \
            -subj "/C=MD/ST=Chisinau/L=Chisinau/O=ExampleOrg/OU=IT/CN=$USERNAME"

echo ""
echo "Step 3: CA signing the certificate..."
# CA signs the CSR to create the certificate
openssl ca -config ca/openssl-ca.conf \
           -extensions usr_cert \
           -days 365 \
           -notext \
           -batch \
           -in users/$USERNAME/${USERNAME}-csr.pem \
           -out users/$USERNAME/${USERNAME}-cert.pem

echo ""
echo "Step 4: Verifying user certificate..."
openssl x509 -noout -text -in users/$USERNAME/${USERNAME}-cert.pem

echo ""
echo "Step 5: Verifying certificate chain..."
# Verify that user cert is properly signed by CA
openssl verify -CAfile ca/certs/ca-cert.pem users/$USERNAME/${USERNAME}-cert.pem

echo ""
echo "Certificate Creation Complete"
echo "User private key: users/$USERNAME/${USERNAME}-key.pem"
echo "User certificate: users/$USERNAME/${USERNAME}-cert.pem"
echo "User CSR: users/$USERNAME/${USERNAME}-csr.pem"