# convertfrompdf

An implementation of a ConvertFrom-PDF cmdlet.  This cmdlet will extract text from a PDF file.  Your mileage may vary depending
on the contents of the PDF.

# Installation

You will need [psake 4.0](https://github.com/psake/psake) to build and install this module.

The following PowerShell script will build the module and install it to your personal module area:

```powershell
import-module psake
invoke-psake install
```

# Use

```powershell
import-module pdfreader
convertfrom-pdf -pdffile ./mypdf.pdf
```
