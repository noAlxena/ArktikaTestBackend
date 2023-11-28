using Microsoft.AspNetCore.Mvc;
using MediatR;
using FluentValidation.Results;
using FluentValidation;

namespace arktiktest{
    /// <summary>
    /// Контроллер продавцов
    /// </summary>
    [Route("Sellers")]
    [ApiController]
    public class SellerController:RESTController<Seller,SellerDTO>{
        public SellerController(IMediator mediator, IValidator<SellerDTO> validator, DbMain db,ILogger<RESTController<Seller,SellerDTO>> logger):base(mediator,validator,new SellerRepository(db),logger){}
        override protected IRequest<List<Seller>> GetAllRequest(DbRepository<Seller,SellerDTO> cs) => new getAllRequest<Seller,SellerDTO>(cs);
        override protected IRequest<Seller?> GetOneRequest(DbRepository<Seller,SellerDTO> cs, int id) => new GetOneRequest<Seller,SellerDTO>(cs, id);
        override protected IRequest<Seller?> PostRequest(DbRepository<Seller,SellerDTO> cs, SellerDTO obj) => new PostRequest<Seller,SellerDTO>(cs, obj);
        override protected IRequest<Seller?> PutRequest(DbRepository<Seller,SellerDTO> cs, int id, SellerDTO obj) => new PutRequest<Seller,SellerDTO>(cs,id, obj);
        override protected  IRequest<Seller?> DeleteRequest(DbRepository<Seller,SellerDTO> cs, int id) => new DeleteRequest<Seller,SellerDTO>(cs, id);
        override protected IRequest<ValidationResult> ValidateRequest(IValidator<SellerDTO> valid, SellerDTO obj) => new ValidateRequest<Seller,SellerDTO>(valid,obj);
        /// <summary>
        /// Запрос возвращает список продавцов
        /// </summary>
        /// <response code="200">Возвращает список материалов</response>
        /// <returns>Список материалов в бд</returns>
        override public async Task<IActionResult> GetAll() => await base.GetAll();
        
        /// <summary>
        /// Запрос возвращает материал с заданым id
        /// </summary>
        /// <response code="200">Возвращает найденный материал</response>
        /// <response code="404">Материал не найден</response>
        /// <param name="id">id материала</param>
        /// <returns>Материал из бд</returns>

        override public async Task<IActionResult> Get(int id) => await base.Get(id);
        /// <summary>
        /// Запрос создаёт новый материал
        /// </summary>
        /// <returns></returns>
        override public async Task<IActionResult> Post(SellerDTO obj) => await base.Post(obj);
        /// <summary>
        /// Запрос обновляет материал с заданным id
        /// </summary>
        /// <returns></returns>
        override public async Task<IActionResult> Put(int id, SellerDTO obj) => await base.Put(id,obj);
        /// <summary>
        /// Запрос удаляет материал с заданным id
        /// </summary>
        /// <returns></returns>
        override public async Task<IActionResult> Delete(int id) => await base.Delete(id);
    }
}