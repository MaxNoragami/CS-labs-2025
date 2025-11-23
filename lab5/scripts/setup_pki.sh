#!/bin/bash

# Initialize PKI directory structure

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR/.."

# Create main PKI directory
mkdir -p pki
cd pki

# Create subdirectories for CA operations
mkdir -p ca/private ca/certs ca/newcerts ca/crl
mkdir -p users/private users/certs users/csr
mkdir -p signed_documents

# Set secure permissions for private key directories
# Only owner can read/write/execute
chmod 700 ca/private users/private

# Create index file for tracking issued certificates
touch ca/index.txt

# Create serial number file (starts at 1000)
echo "1000" > ca/serial

# Create CRL serial number file
echo "1000" > ca/crlnumber

echo "PKI directory structure created successfully!"
echo "Location: $(pwd)"