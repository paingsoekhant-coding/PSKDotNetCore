using Microsoft.AspNetCore.Mvc;

namespace PSKDotNetCore.MvcChartApp.Controllers
{
    public class HighChart : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }

        public IActionResult AreaChart() 
        {
            return View();
        }

        public IActionResult BarRaceChart()
        {
            return View();
        }
    }
}
