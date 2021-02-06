using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocuSign.CodeExamples.Data;
using DocuSign.CodeExamples.UnitofWork;

namespace DocuSign.CodeExamples
{
   public class DocumentService: IDocumentService
    {
      //  private readonly IConfiguration configuration;
        private readonly RealEstateLocalContext realEstatedb;
      //  private readonly IUnitofWork unitofWork;
        public DocumentService( RealEstateLocalContext _realEstatedb)
        {
            realEstatedb = _realEstatedb;
           // unitofWork = _unitofWork;
        }

        public Eg002ViewModel UserDetails(string UserID,string Docid)

        {
            
            using (var context = realEstatedb)
            {
                var Userquery = context.User
                                   .Where(s => s.UserId == Convert.ToInt32(UserID))
                                   .FirstOrDefault<User>();

                var Documentquery = context.Document
                                   .Where(s => s.DocId == Convert.ToInt32(Docid))
                                   .FirstOrDefault<Document>();


                 Eg002ViewModel Model = new Eg002ViewModel();
                        Model.SignerEmail = Userquery.EmailAddress;
                        Model.SignerNamew = Userquery.FullName;
                        Model.SignerCC = Userquery.EmailAddress;
                        Model.SignerCCname = Userquery.FullName;
                        Model.DocumentId = Documentquery.DocId;
                        Model.Documentname = Documentquery.DocumentName;
                        Model.DocumentPath = Documentquery.DocumentPath;

                return Model;
            }

           
        }

        public bool updateDocumentDetails(string DocID,string EnvID)

        {
            
            using (var context = realEstatedb)
            {
                var query = context.Document
                                   .Where(s => s.DocId == Convert.ToInt32(DocID))
                                   .FirstOrDefault<Document>();
                if (query != null)
                {
                   
                    query.DocumentDescription = EnvID;
                    query.DocumentOriginalName = "Sent";
                  
                    context.Document.Attach(query);
                   
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
 
            }

        }

        public bool updateDocumentStatus(string DocID, string Status)

        {

            using (var context = realEstatedb)
            {
                var query = context.Document
                                   .Where(s => s.DocId == Convert.ToInt32(DocID))
                                   .FirstOrDefault<Document>();
                if (query != null)
                {

                    query.DocumentOriginalName = Status;

                    context.Document.Attach(query);

                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

    }
   

}
