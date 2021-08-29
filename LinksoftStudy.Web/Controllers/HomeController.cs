using LinksoftStudy.Common.Services;
using LinksoftStudy.Services.Models;
using LinksoftStudy.Services.Services;
using LinksoftStudy.Web.Interfaces;
using LinksoftStudy.Web.Models;
using LinksoftStudy.Web.Processors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LinksoftStudy.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        private readonly IInputDataProcessor inputDataProcessor;

        private readonly IPersonProcessor personProcessor;

        public HomeController(
            ILogger<HomeController> logger,
            IInputDataProcessor inputDataProcessor,
            IPersonProcessor personProcessor)
        {
            this.logger = logger;
            this.inputDataProcessor = inputDataProcessor;
            this.personProcessor = personProcessor;
        }

        public async Task<IActionResult> Index()
        {
            //var filePath = @"c:\Temp\network-data.txt";
            //this.inputDataProcessor.Process(filePath);

            var resp = this.personProcessor.GetUsersStatistics();
            if (resp == null)
            {
                // log error - return error view
            }

            var result = new UserStatistics()
            {
                TotalUsers = resp?.Result?.TotalUsers ?? 0,
                AverageFriendshipsPerUser = resp?.Result?.AverageFriendshipsPerUser ?? 0
            };

            return View(resp.Result);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles([FromBody] AttachmentsPayload payload)
        {
            var txtFileContent = payload.Attachments
                .Select(x => x.Data)
                .FirstOrDefault();

            var resp = await this.inputDataProcessor.Process(txtFileContent);

            return resp 
                ? new OkResult() 
                : new StatusCodeResult(422);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
