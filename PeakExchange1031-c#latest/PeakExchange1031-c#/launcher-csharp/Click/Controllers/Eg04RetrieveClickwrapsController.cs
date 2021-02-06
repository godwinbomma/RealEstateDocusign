﻿using System.Text;

using DocuSign.Click.Api;
using DocuSign.Click.Client;
using DocuSign.CodeExamples.Common;
using DocuSign.CodeExamples.Controllers;
using DocuSign.CodeExamples.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DocuSign.CodeExamples.Click.Controllers
{
    [Area("Click")]
    [Route("[area]/Eg06")]
    public class Eg06RetrieveClickwrapsController : EgController
    {
        public Eg06RetrieveClickwrapsController
            (DSConfiguration dsConfig,
             IRequestItemsService requestItemsService, IDocumentService documentService)
            : base(dsConfig, requestItemsService,documentService)
        {
        }

        public override string EgName => "Eg06";
        protected override void InitializeInternal()
        {
            ViewBag.ClickwrapId = RequestItemsService.ClickwrapId;
            ViewBag.AccountId = RequestItemsService.Session.AccountId;
        }
    
    [MustAuthenticate]
        [Route("Retrieve")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Retrieve()
        {
            // Step 1. Obtain your OAuth token
            var accessToken = RequestItemsService.User.AccessToken;
            var basePath = $"{RequestItemsService.Session.BasePath}/clickapi"; // Base API path

            // Step 2: Construct your API headers
            var apiClient = new ApiClient(basePath);
            apiClient.Configuration.DefaultHeader.Add("Authorization", "Bearer " + accessToken);
            var clickAccountApi = new AccountsApi(apiClient);

            var accountId = RequestItemsService.Session.AccountId;

            try
            {
                // Step 3: Call the Click API to get the clickwraps
                var clickwraps = clickAccountApi.GetClickwraps(accountId);

                var messageBuilder = new StringBuilder();
                clickwraps.Clickwraps.ForEach(cw => messageBuilder.AppendLine($"Clickwrap ID:{cw.ClickwrapId}, Clickwrap Version: {cw.VersionNumber}"));

                //Show results
                ViewBag.h1 = "Clickwraps were successfully retreived";
                ViewBag.message = $"The clickwraps retrieved: {messageBuilder.ToString()}.";
                ViewBag.Locals.Json = JsonConvert.SerializeObject(clickwraps.Clickwraps, Formatting.Indented);

                return View("example_done");
            }
            catch (ApiException apiException)
            {
                ViewBag.errorCode = apiException.ErrorCode;
                ViewBag.errorMessage = apiException.Message;

                return View("Error");
            }
        }
    }
}