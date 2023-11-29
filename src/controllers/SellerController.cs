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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public SellerController(IMediator mediator, IValidator<SellerDTO> validator, DbMain db,ILogger<RESTController<Seller,SellerDTO>> logger):base(mediator,validator,new SellerRepository(db),logger){}

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        override protected IRequest<List<Seller>> GetAllRequest(DbRepository<Seller,SellerDTO> cs) => new getAllRequest<Seller,SellerDTO>(cs);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        override protected IRequest<Seller?> GetOneRequest(DbRepository<Seller,SellerDTO> cs, int id) => new GetOneRequest<Seller,SellerDTO>(cs, id);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        override protected IRequest<Seller?> PostRequest(DbRepository<Seller,SellerDTO> cs, SellerDTO obj) => new PostRequest<Seller,SellerDTO>(cs, obj);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        override protected IRequest<Seller?> PutRequest(DbRepository<Seller,SellerDTO> cs, int id, SellerDTO obj) => new PutRequest<Seller,SellerDTO>(cs,id, obj);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        override protected  IRequest<Seller?> DeleteRequest(DbRepository<Seller,SellerDTO> cs, int id) => new DeleteRequest<Seller,SellerDTO>(cs, id);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        override protected IRequest<ValidationResult> ValidateRequest(IValidator<SellerDTO> valid, SellerDTO obj) => new ValidateRequest<Seller,SellerDTO>(valid,obj);

        /// <summary>
        /// Запрос возвращает список продавцов
        /// </summary>
        /// <response code="200">Возвращает список продавцов</response>
        /// <returns>Список продавцов из бд</returns>
        override public async Task<IActionResult> GetAll() => await base.GetAll();
        
        /// <summary>
        /// Запрос возвращает продавца с заданым id
        /// </summary>
        /// <response code="200">Возвращает найденного продавца</response>
        /// <response code="404">продавец не найден</response>
        /// <param name="id">id продавца</param>
        /// <returns>продавец из бд</returns>
        override public async Task<IActionResult> Get(int id) => await base.Get(id);

        /// <summary>
        /// Запрос добаляет данного продавца в базу данных
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Sellers
        ///     {
        ///        "name": "Seller1"
        ///     } 
        ///
        /// </remarks> 
        /// <response code="201">Возвращает созданного продавца</response>
        /// <response code="400">Параметры продавца заданны неверно</response>
        /// <response code="404">продавец не найден</response>
        /// <param name="obj">Добавляемый продавец</param>
        /// <returns>Добаленный продавец</returns>
        override public async Task<IActionResult> Post(SellerDTO obj) => await base.Post(obj);

        /// <summary>
        /// Запрос обновляет продавца с заданным id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Sellers/{id}
        ///     {
        ///        "name": "Seller1"
        ///     } 
        ///
        /// </remarks> 
        /// <response code="200">Возвращает обновленного продавца</response>
        /// <response code="400">Параметры продавца заданны неверно</response>
        /// <response code="404">продавец не найден</response>
        /// <param name="id">Id обновляемого продавца</param>
        /// <param name="obj">Новые данные обновляемого продавца</param>
        /// <returns>Обновленный продавец</returns>
        override public async Task<IActionResult> Put(int id, SellerDTO obj) => await base.Put(id,obj);

        /// <summary>
        /// Запрос удаляет продавца с заданным id
        /// </summary>
        /// <response code="200">Возвращает удаленного продавца</response>
        /// <response code="404">продавец не найден</response>
        /// <returns>Удаленный продавец</returns>
        override public async Task<IActionResult> Delete(int id) => await base.Delete(id);
    }
}