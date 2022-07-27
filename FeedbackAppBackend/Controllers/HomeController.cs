using FeedbackAppBackend.EFC;
using FeedbackAppBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackAppBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FeedbackDbContext context;

        public HomeController(ILogger<HomeController> logger, FeedbackDbContext context)
        {
            this.context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var feedbacks = this.context.Feedbacks.Select(m => new FeedbackViewModel { 
            Text = m.Text,
            Subject = m.Subject,
            Rating = m.Rating
            }).ToList();
            return View(feedbacks);
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
