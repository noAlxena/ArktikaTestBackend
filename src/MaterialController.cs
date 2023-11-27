using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace arktiktest{
    [Route("Materials")]
    [ApiController]
    public class MaterialController:ControllerBase{
        public MaterialController(){}
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll() => Ok();
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id) => Ok();
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(Material obj) => Ok();
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put(int id, Material obj) => Ok();
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id) => Ok();
    }
}