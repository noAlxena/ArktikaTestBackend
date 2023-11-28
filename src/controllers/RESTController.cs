using Microsoft.AspNetCore.Mvc;
namespace arktiktest{
    public abstract class RESTController<TObject>:ControllerBase where TObject:DataObject{
        public RESTController(){}
        [HttpGet]
        [Route("")]
        virtual public async Task<IActionResult> GetAll() => Ok();
        [HttpGet]
        [Route("{id:int}")]
        virtual public async Task<IActionResult> Get(int id) => Ok();
        [HttpPost]
        [Route("")]
        virtual public async Task<IActionResult> Post(TObject obj) => Ok();
        [HttpPut]
        [Route("{id:int}")]
        virtual public async Task<IActionResult> Put(int id, TObject obj) => Ok();
        [HttpDelete]
        [Route("{id:int}")]
        virtual public async Task<IActionResult> Delete(int id) => Ok();
    }
}