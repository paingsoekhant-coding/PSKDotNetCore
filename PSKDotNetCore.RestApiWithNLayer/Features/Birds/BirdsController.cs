using Newtonsoft.Json;

namespace PSKDotNetCore.RestApiWithNLayer.Features.Birds
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        private readonly Birds _data;

        private async Task<Birds> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("Birds.json");
            var model = JsonConvert.DeserializeObject<Birds>(jsonStr);
            return model;

        }

        [HttpGet("birds")]
        public async Task<IActionResult> Birds()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_Bird);
        }

    }

    public class Birds
    {
        public Tbl_Bird[] Tbl_Bird { get; set; }
    }

    public class Tbl_Bird
    {
        public int Id { get; set; }
        public string BirdMyanmarName { get; set; }
        public string BirdEnglishName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }

}
