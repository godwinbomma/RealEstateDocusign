using System;
using System.Collections.Generic;
using System.Text;
using DocuSign.CodeExamples.Data;

namespace DocuSign.CodeExamples
{
    public interface IDocumentService
    {
        Eg002ViewModel UserDetails(string UserID,string Docid);
        bool updateDocumentDetails(string DocID, string EnvID);

        bool updateDocumentStatus(string DocID, string Status);
    }
}
