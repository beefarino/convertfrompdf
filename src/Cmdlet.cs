using System;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace PowerShell.PDF
{
    [Cmdlet( VerbsData.ConvertFrom, "PDF" )]
    public class ConvertFromPDF : PSCmdlet
    {
        [Parameter( ValueFromPipeline = true, Mandatory = true )]
        public string PDFFile { get; set; }
        
        protected override void ProcessRecord()
        {
            ProviderInfo pi;
            var path = SessionState.Path.GetResolvedProviderPathFromPSPath(PDFFile, out pi).FirstOrDefault();
            var parser = new PDFParser();
            using( Stream s = new MemoryStream() )
            {
                if( ! parser.ExtractText(File.OpenRead(path), s) )
                {
                    WriteError( 
                        new ErrorRecord(
                            new ApplicationException(),
                            "failed to extract text from pdf",
                            ErrorCategory.ReadError,
                            PDFFile
                        )    
                    );

                    return;
                }

                s.Position = 0;
                using( StreamReader reader = new StreamReader( s ) )
                {
                    WriteObject( reader.ReadToEnd() );
                }
            }
        }
    }
}
