using Newtonsoft.Json;

namespace PSKDotNetCore.RestApiWithNLayer.Features.Birds
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        //private readonly BirdsModel _data;

        private async Task<BirdsModel> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("Birds.json");
            var model = JsonConvert.DeserializeObject<BirdsModel>(jsonStr);
            return model;

        }

        [HttpGet]
        public async Task<IActionResult> Birds()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_Bird);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Description(int id)
        {
            int newNum = id;
            newNum--;
            var model = await GetDataAsync();
            if(id > 20)
            {
                return NotFound("No Birds Found");
            }
            return Ok(model.Tbl_Bird[newNum]);
        }

    }
}
