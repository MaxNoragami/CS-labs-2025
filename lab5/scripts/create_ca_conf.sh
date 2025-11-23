#!/bin/bash

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR/.."

# OpenSSL configuration for CA
cat > pki/ca/openssl-ca.conf << 'EOF'
# OpenSSL CA Configuration File

[ ca ]
default_ca = CA_default

[ CA_default ]
# Directory and file locations
dir              = ./ca
database         = $dir/index.txt
serial           = $dir/serial
crlnumber        = $dir/crlnumber
private_key      = $dir/private/ca-key.pem
certificate      = $dir/certs/ca-cert.pem
new_certs_dir    = $dir/newcerts
crl_dir          = $dir/crl
crl              = $dir/crl/crl.pem

# Settings
default_crl_days = 30
default_md       = sha256
default_days     = 365
policy           = policy_loose

[ policy_loose ]
# Loose policy - all fields optional except Common Name
countryName             = optional
stateOrProvinceName     = optional
localityName            = optional
organizationName        = optional
organizationalUnitName  = optional
commonName              = supplied
emailAddress            = optional

[ req ]
# Certificate request settings
default_bits        = 2048
distinguished_name  = req_distinguished_name
x509_extensions     = v3_ca
default_md          = sha256
prompt              = no

[ req_distinguished_name ]
# Field descriptions
countryName                     = Country Name
stateOrProvinceName             = State or Province Name
localityName                    = Locality Name
0.organizationName              = Organization Name
organizationalUnitName          = Organizational Unit Name
commonName                      = Common Name

[ v3_ca ]
# Extensions for CA certificate
subjectKeyIdentifier   = hash
authorityKeyIdentifier = keyid:always,issuer
basicConstraints       = critical, CA:true
keyUsage               = critical, keyCertSign, cRLSign

[ v3_user ]
# Extensions for user certificates
subjectKeyIdentifier   = hash
authorityKeyIdentifier = keyid,issuer
basicConstraints       = CA:FALSE
keyUsage               = critical, digitalSignature
EOF

echo "CA configuration file created at pki/ca/openssl-ca.conf"