﻿using System.Globalization;

using DocuSign.CodeExamples.Common;
using DocuSign.CodeExamples.Controllers;
using DocuSign.CodeExamples.Models;
using DocuSign.CodeExamples.Rooms.Models;
using DocuSign.Rooms.Api;
using DocuSign.Rooms.Client;
using DocuSign.Rooms.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DocuSign.CodeExamples.Rooms.Controllers
{
    [Area("Rooms")]
    [Route("Eg05")]
    public class Eg05GetRoomsWithFiltersController : EgController
    {
        public Eg05GetRoomsWithFiltersController(
            DSConfiguration dsConfig,
            IRequestItemsService requestItemsService, IDocumentService documentService)
            : base(dsConfig, requestItemsService,documentService)
        {
        }

        public override string EgName => "Eg05";

        [BindProperty]
        public RoomFilterModel RoomFilterModel { get; set; }

        protected override void InitializeInternal()
        {
            RoomFilterModel = new RoomFilterModel();
        }

        [MustAuthenticate]
        [Route("ExportData")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExportData(RoomFilterModel roomFilterModel)
        {
            // Step 1. Obtain your OAuth token
            string accessToken = RequestItemsService.User.AccessToken; // Represents your {ACCESS_TOKEN}
            var basePath = $"{RequestItemsService.Session.RoomsApiBasePath}/restapi"; // Base API path

            // Step 2: Construct your API headers
            var apiClient = new ApiClient(basePath);
            apiClient.Configuration.DefaultHeader.Add("Authorization", "Bearer " + accessToken);
            var roomsApi = new RoomsApi(apiClient);

            string accountId = RequestItemsService.Session.AccountId; // Represents your {ACCOUNT_ID}

            try
            {
                // Step 3: Prepare your request parameters
                var fieldDataChangedStartDate = roomFilterModel.FieldDataChangedStartDate.ToString(CultureInfo.InvariantCulture);
                var fieldDataChangedEndDate = roomFilterModel.FieldDataChangedEndDate.ToString(CultureInfo.InvariantCulture);

                // Step 4: Call the Rooms API to get rooms with filters
                RoomSummaryList rooms = roomsApi.GetRooms(accountId, new RoomsApi.GetRoomsOptions
                {
                    fieldDataChangedStartDate = fieldDataChangedStartDate,
                    fieldDataChangedEndDate = fieldDataChangedEndDate
                });

                ViewBag.h1 = "The rooms with filters was loaded";
                ViewBag.message = $"Results from the Rooms: GetRooms method. FieldDataChangedStartDate: " +
                                  $"{ roomFilterModel.FieldDataChangedStartDate.Date.ToShortDateString() }, " +
                                  $"FieldDataChangedEndDate: { roomFilterModel.FieldDataChangedEndDate.Date.ToShortDateString() } :";
                ViewBag.Locals.Json = JsonConvert.SerializeObject(rooms, Formatting.Indented);

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