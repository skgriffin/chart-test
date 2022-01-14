using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using test.Models;
using Newtonsoft.Json;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        [HttpPost]
        public JsonResult GetChartData()
        {
            //dummy data
            double[] sparklineData = {9.1, 9.1, 9.4, 9.2, 9.3, 9.55};
            string[] dateData = {"11/3/21", "11/15/21", "11/22/21", "12/7/21", "1/5/22", "1/10/22" };

            Random rnd = new Random();

            double[] vault = sparklineData.OrderBy(x=> rnd.Next()).ToArray();    
            double[] bars = sparklineData.OrderBy(x=> rnd.Next()).ToArray();    
            double[] beam = sparklineData.OrderBy(x=> rnd.Next()).ToArray();  
            double[] floor = sparklineData.OrderBy(x=> rnd.Next()).ToArray();  
            try
            {
                decimal[] SeriesVal = { 50.55M, 55, 41, 17 };
                string[] LabelsVal = { "11/22/21", "12/7/21", "1/5/22", "1/10/22" };
                return Json(new { success = true, 
                                  vaultScores = vault, 
                                  barScores = bars, 
                                  beamScores = beam, 
                                  floorScores = floor, 
                                  labels = dateData, 
                                  message = "success.!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Some thing went Wrong.! unsuccessfull!" });
            }
        }

        [HttpPost]
        public JsonResult GetDonutChartData()
        {
            try
            {
                decimal[] SeriesVal = { 15, 30, 10, 3 };
                string[] LabelsVal = { "XL-Bronze", "XL-Silver", "XL-Gold", "AAU-Level 6" };
                return Json(new { success = true, series = SeriesVal, labels = LabelsVal, message = "success.!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Some thing went Wrong.! unsuccessfull!" });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
