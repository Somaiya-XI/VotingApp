using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VotingApp.Areas.Admin.BusinessLogic;
using VotingApp.Areas.Admin.Models;

namespace VotingApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VoteController : Controller
    {
        private readonly ILogger<VoteController> _logger;

        public VoteController(ILogger<VoteController> logger)
        {
            _logger = logger;
        }

        public IActionResult List()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View(new VoteModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(VoteModel model)
        {

            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            Console.WriteLine("Straight to the database!");
            VoteManager manager = new VoteManager();
            bool saved = manager.Save(model);
            if (saved)
            {
                VoteOptionManager optionManager = new VoteOptionManager();
                foreach (var option in model.voteOptions)
                {
                    option.voteId = model.voteId;
                    option.voteObj = model;
                    optionManager.Save(option);
                }
                Console.WriteLine("All data saved to DB");

            }
            return View("List", model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }

}