using System.Configuration;
using Microsoft.AspNetCore.Mvc;
namespace arktiktest{
    public abstract class RESTController<TObject,DTObject>:ControllerBase where TObject:DataObject where DTObject:IDataTransferObject<TObject>{
        DbRepository<TObject,DTObject> _rp;
        public RESTController(DbRepository<TObject,DTObject> rp){
            _rp = rp;
        }
        [HttpGet]
        [Route("")]
        virtual public async Task<IActionResult> GetAll() => Ok(await _rp.GetAll());
        [HttpGet]
        [Route("{id:int}")]
        virtual public async Task<IActionResult> Get(int id) => Ok(await _rp.GetOne(id));
        [HttpPost]
        [Route("")]
        virtual public async Task<IActionResult> Post(DTObject obj) => Ok(await _rp.Post(obj));
        [HttpPut]
        [Route("{id:int}")]
        virtual public async Task<IActionResult> Put(int id, DTObject obj) => Ok(await _rp.Put(id,obj));
        [HttpDelete]
        [Route("{id:int}")]
        virtual public async Task<IActionResult> Delete(int id) => Ok(await _rp.Delete(id));
    }
}