using Microsoft.AspNetCore.Mvc;
namespace arktiktest{
    [Route("Sellers")]
    [ApiController]
    public class SellerController:RESTController<Seller,SellerDTO>{
        public SellerController(DbMain db):base(new SellerRepository(db)){}
        override public async Task<IActionResult> GetAll() => await base.GetAll();
        override public async Task<IActionResult> Get(int id) => await base.Get(id);
        override public async Task<IActionResult> Post(SellerDTO obj) => await base.Post(obj);
        override public async Task<IActionResult> Put(int id, SellerDTO obj) => await base.Put(id,obj);
        override public async Task<IActionResult> Delete(int id) => await base.Delete(id);
    }
}