﻿using lab12.Models;
using lab12.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace lab12.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CalculationService _calculationService;

        public HomeController(ILogger<HomeController> logger, CalculationService calculationService)
        {
            _logger = logger;
            _calculationService = calculationService;
        }

        private string ParseData()
        {
            try
            {
                int firstNumber = int.Parse(Request.Form["firstNumber"]);
                int secondNumber = int.Parse(Request.Form["secondNumber"]);
                string operation = Request.Form["operation"];
                return _calculationService.Calculation(firstNumber, secondNumber, operation);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manual()
        {
            if (Request.Method == "GET")
            {
                return View("inputForm");
            }
            else
            {
                ViewData["result"] = ParseData();
                return View("result");
            }
        }

        [HttpGet, ActionName("ManualSeparate")]
        public IActionResult ManualSeparateGet()
        {
            return View("inputForm");
        }

        [HttpPost, ActionName("ManualSeparate")]
        public IActionResult ManualSeparatePost()
        {
            ViewData["result"] = ParseData();
            return View("result");
        }

        [HttpGet]
        public IActionResult ModelBindingSeparate()
        {
            return View("inputForm");
        }

        [HttpPost]
        public IActionResult ModelBindingSeparate(int firstNumber, int secondNumber, string operation)
        {
            ViewData["result"] = _calculationService.Calculation(firstNumber, secondNumber, operation);
            return View("result");
        }

        [HttpGet]
        public IActionResult ModelBinding()
        {
            return View("inputForm");
        }

        [HttpPost]
        public IActionResult ModelBinding(CalculationExpressionModel expressionModel)
        {
            ViewData["result"] = _calculationService.Calculation(expressionModel);
            return View("result");
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
