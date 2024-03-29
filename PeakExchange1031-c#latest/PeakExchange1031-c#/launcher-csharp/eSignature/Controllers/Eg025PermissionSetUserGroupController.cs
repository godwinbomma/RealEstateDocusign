﻿using System.Collections.Generic;
using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using DocuSign.CodeExamples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DocuSign.eSign.Model;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace DocuSign.CodeExamples.Controllers
{
    [Area("eSignature")]
    [Route("Eg025")]
    public class Eg025PermissionSetUserGroupController : EgController
    {
        public Eg025PermissionSetUserGroupController(DSConfiguration config, IRequestItemsService requestItemsService, IDocumentService documentService)
            : base(config, requestItemsService,documentService)
        {
        }

        public override string EgName => "Eg025";

        protected override void InitializeInternal()
        {
            // Data for this method
            // Permission profiles
            // User groups
            var basePath = RequestItemsService.Session.BasePath + "/restapi";
            var accessToken = RequestItemsService.User.AccessToken; // Represents your {ACCESS_TOKEN}
            var accountId = RequestItemsService.Session.AccountId; // Represents your {ACCOUNT_ID}
            var apiClient = new ApiClient(basePath);
            apiClient.Configuration.DefaultHeader.Add("Authorization", "Bearer " + accessToken);

            var accountsApi = new AccountsApi(apiClient);
            var groupsApi = new GroupsApi(apiClient);
            var permissions = accountsApi.ListPermissions(accountId);
            var userGroups = groupsApi.ListGroups(accountId);

            // List all available permission profiles
            ViewBag.PermissionProfiles =
                permissions.PermissionProfiles.Select(pr => new SelectListItem
                {
                    Text = pr.PermissionProfileName,
                    Value = pr.PermissionProfileId
                });

            // List all available user groups
            ViewBag.UserGroups =
                userGroups.Groups.Select(pr => new SelectListItem
                {
                    Text = $"{pr.GroupName}",
                    Value = pr.GroupId
                });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SetProfile(string permissionProfileId, string userGroupId)
        {
            // Check the minimal buffer time.
            bool tokenOk = CheckToken(3);
            if (!tokenOk)
            {
                // We could store the parameters of the requested operation so it could be 
                // restarted automatically. But since it should be rare to have a token issue
                // here, we'll make the user re-enter the form data after authentication.
                RequestItemsService.EgName = EgName;
                return Redirect("../ds/mustAuthenticate");
            }

            // Uri of rest api
            var basePath = RequestItemsService.Session.BasePath + "/restapi";

            // Step 1. Obtain your OAuth token
            var accessToken = RequestItemsService.User.AccessToken; // Represents your {ACCESS_TOKEN}
            var accountId = RequestItemsService.Session.AccountId; // Represents your {ACCOUNT_ID}

            // Step 2. Construct your API headers
            var apiClient = new ApiClient(basePath);
            apiClient.Configuration.DefaultHeader.Add("Authorization", "Bearer " + accessToken);
            var groupsApi = new GroupsApi(apiClient);

            // Step 3. Construct your request body
            var editedGroup = new Group
            {
                GroupId = userGroupId,
                PermissionProfileId = permissionProfileId
            };
            var requestBody = new GroupInformation { Groups = new List<Group> { editedGroup } };

            //Step 4. Call the eSignature REST API
            var result = groupsApi.UpdateGroups(accountId, requestBody);
            var errorDetails = result.Groups.FirstOrDefault()?.ErrorDetails;

            if (errorDetails is null)
            {
                ViewBag.h1 = "The permission profile was successfully set to the user group";
                ViewBag.message = "The permission profile was successfully set to the user group!";
            }
            else
            {
                ViewBag.h1 = "The permission profile failed to set to the user group";
                ViewBag.message = "The permission profile failed to set to the user group.<br /> " +
                                  $"Reason: {errorDetails.Message}";
            }

            return View("example_done");
        }
    }
}