using Microsoft.AspNetCore.Mvc;
namespace arktiktest{
    [Route("Sellers")]
    [ApiController]
    public class SellerController:RESTController<Seller>{
        public SellerController():base(){}
        override public async Task<IActionResult> GetAll() => await base.GetAll();
        override public async Task<IActionResult> Get(int id) => await base.Get(id);
        override public async Task<IActionResult> Post(Seller obj) => await base.Post(obj);
        override public async Task<IActionResult> Put(int id, Seller obj) => await base.Put(id,obj);
        override public async Task<IActionResult> Delete(int id) => await base.Delete(id);
    }
}