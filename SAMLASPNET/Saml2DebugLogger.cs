using Sustainsys.Saml2;
using System;
using System.Diagnostics;

namespace SAMLASPNET
{
    public class Saml2DebugLogger : ILoggerAdapter
    {
        public void WriteError(string message, Exception ex)
        {
            Debug.WriteLine(message);
            if (ex != null && !string.IsNullOrEmpty(ex.Message))
            {
                Debug.WriteLine(ex.Message);
            }   
        }

        public void WriteInformation(string message) => 
            Debug.WriteLine(message);

        public void WriteVerbose(string message) => 
            Debug.WriteLine(message);
    }
}