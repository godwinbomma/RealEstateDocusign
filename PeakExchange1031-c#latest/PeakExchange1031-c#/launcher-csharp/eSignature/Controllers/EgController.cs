

using DocuSign.CodeExamples.Data;
using DocuSign.CodeExamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocuSign.CodeExamples.Controllers
{
    public abstract class EgController : Controller
    {
        public const string SessionUserid = "_Userid";
        public const string SessionDocid = "_Docid";
        public const string SessionEnvid = "_Envid";
        public abstract string EgName { get; }
        protected DSConfiguration Config { get; }
        protected IRequestItemsService RequestItemsService{ get; }
        protected IDocumentService DocumentService { get; }
       // public  IDocumentService DocumentService;

        public EgController(DSConfiguration config, IRequestItemsService requestItemsService, IDocumentService documentService)
        {
            Config = config;          
            RequestItemsService = requestItemsService;
            DocumentService = documentService;
           
          
        }

        [HttpGet]
        public virtual IActionResult Get(string Userid,string DocumentID,string EnvID)
        
       {
            // Check that the token is valid and will remain valid for awhile to enable the
            // user to fill out the form. If the token is not available, now is the time
            // to have the user authenticate or re-authenticate.
            bool tokenOk = CheckToken();
         ;
            if (!string.IsNullOrEmpty(Userid))
            {
            
                HttpContext.Session.SetString(SessionUserid, Userid);
                HttpContext.Session.SetString(SessionDocid, DocumentID);
               
                var obj = DocumentService.UserDetails(Userid, DocumentID);
                ViewBag.Eg002Model = obj;
                // HttpContext.Session.SetInt32(SessionKeyAge, 773);
            }
            if (!string.IsNullOrEmpty(EnvID))
            {
                HttpContext.Session.SetString(SessionEnvid, EnvID);
                ViewBag.envelopeOk = EnvID != null;
            }
            if (HttpContext.Session.GetString(SessionDocid) != "" && Userid==null)
            {
                var Userid1 = HttpContext.Session.GetString(SessionUserid);
                var DocumentID1 = HttpContext.Session.GetString(SessionDocid);
                var obj = DocumentService.UserDetails(Userid1, DocumentID1);

                ViewBag.Eg002Model = obj;
            }
            if (tokenOk)
            {
                //addSpecialAttributes(model);

                ViewBag.documentsOk = RequestItemsService.EnvelopeDocuments != null;
                ViewBag.documentOptions = RequestItemsService.EnvelopeDocuments?.Documents;
                ViewBag.gatewayOk = Config.GatewayAccountId != null && Config.GatewayAccountId.Length > 25;
                ViewBag.templateOk = RequestItemsService.TemplateId != null;
                ViewBag.source = CreateSourcePath();
                ViewBag.documentation = Config.documentation + EgName;
                ViewBag.showDoc =true;
                //ViewBag.pausedEnvelopeOk = RequestItemsService.PausedEnvelopeId != null;
                ViewBag.DocID = DocumentID;

                if (!string.IsNullOrEmpty(Userid))
                {
                    HttpContext.Session.SetString(SessionUserid, Userid);
                    HttpContext.Session.SetString(SessionDocid, DocumentID);
                    var obj = DocumentService.UserDetails(Userid, DocumentID);

                    ViewBag.Eg002Model = obj;
                    // HttpContext.Session.SetInt32(SessionKeyAge, 773);
                }
                if (!string.IsNullOrEmpty(EnvID))
                {
                    HttpContext.Session.SetString(SessionEnvid, EnvID);
                    ViewBag.envelopeOk = EnvID != null;
                }
                    //var Userid = HttpContext.Session.GetString(SessionUserid);
                    //var DocumentID = HttpContext.Session.GetString(SessionDocid);
                
                InitializeInternal();
               
               
                //var obj = new Eg002ViewModel() { SignerEmail = "godwinabishekp@gmail.com", SignerNamew = "godwin", SignerCC = "godwinbomma@gmail.com", SignerCCname = "c" };
              
               // return RedirectToAction("create", "eg002", obj);

                return View(EgName, this);
            }

            RequestItemsService.EgName = EgName;

            return Redirect("../ds/mustAuthenticate");
        }

        protected virtual void InitializeInternal()
        {
        }

        public dynamic CreateSourcePath()
       {
            var uri = Config.githubExampleUrl;
            if (ControllerContext.RouteData.Values["area"] != null)
            {
                uri = $"{uri}/{ControllerContext.RouteData.Values["area"]}";
            }
            if (EgName == "eg001")
            {
                return $"{uri}/launcher-csharp/{this.GetType().Name}.cs";
            }
            else
            {
                return $"{uri}/launcher-csharp/eSignature/Controllers/{this.GetType().Name}.cs";
            }
        }

        protected bool CheckToken(int bufferMin = 60)
        {
            return RequestItemsService.CheckToken(bufferMin);
        }
    }
}