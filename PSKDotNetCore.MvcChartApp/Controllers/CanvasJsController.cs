using Microsoft.AspNetCore.Mvc;

namespace PSKDotNetCore.MvcChartApp.Controllers
{
    public class CanvasJsController : Controller
    {
        private readonly ILogger<CanvasJsController> _logger;

		public CanvasJsController(ILogger<CanvasJsController> logger)
		{
			_logger = logger;
		}

		public IActionResult DashedLineChart()
        {
            _logger.LogInformation("Dashed Line Chart");
            return View();
        }

        public IActionResult LiveColumnChart()
        {
			_logger.LogInformation("Live Column Chart");
			return View();
        }

        public IActionResult BubbleChart()
        {
			_logger.LogInformation("Bubble Chart");
			return View();
        }
    }
}
