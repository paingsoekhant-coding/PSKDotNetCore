using Microsoft.AspNetCore.Mvc;

namespace PSKDotNetCore.MvcChartApp.Controllers
{
    public class CanvasJsController : Controller
    {
        public IActionResult DashedLineChart()
        {
            return View();
        }

        public IActionResult LiveColumnChart()
        {
            return View();
        }

        public IActionResult BubbleChart()
        {
            return View();
        }
    }
}
