#!/bin/bash

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR/../pki"

# Initialize Certificate Authority
echo "Step 1: Generating CA Private Key (4096 bits RSA)"
openssl genrsa -out ca/private/ca-key.pem 4096

echo ""
echo "Step 2: Creating CA Self-Signed Certificate"
echo "Certificate will be valid for 3650 days (10 years)..."

openssl req -config ca/openssl-ca.conf \
            -new -x509 \
            -days 3650 \
            -key ca/private/ca-key.pem \
            -out ca/certs/ca-cert.pem \
            -subj "/C=MD/ST=Chisinau/L=Chisinau/O=ChillGuysSRL/OU=IT/CN=RootCA"

echo ""
echo "Step 3: Verifying CA Certificate"
openssl x509 -noout -text -in ca/certs/ca-cert.pem

echo ""
echo "CA Setup Complete"
echo "CA private key: $(pwd)/ca/private/ca-key.pem"
echo "CA certificate: $(pwd)/ca/certs/ca-cert.pem"