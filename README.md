# QR-ROM
A technology to store multiple files on a single QR code, including a scanner.
## Specifications
QR-ROM stores a base64-encoded ZIP file on the code. This file is decoded, then extracted, and finally mounted as a virtual drive. All QR-ROM codes begin with "iso:" to tell them apart from regular QR codes.
