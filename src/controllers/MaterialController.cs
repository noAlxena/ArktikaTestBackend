using Microsoft.AspNetCore.Mvc;

namespace arktiktest{
    [Route("Materials")]
    [ApiController]
    public class MaterialController:RESTController<Material>{
        public MaterialController():base(){}
        override public async Task<IActionResult> GetAll() => await base.GetAll();
        override public async Task<IActionResult> Get(int id) => await base.Get(id);
        override public async Task<IActionResult> Post(Material obj) => await base.Post(obj);
        override public async Task<IActionResult> Put(int id, Material obj) => await base.Put(id,obj);
        override public async Task<IActionResult> Delete(int id) => await base.Delete(id);
    }
}