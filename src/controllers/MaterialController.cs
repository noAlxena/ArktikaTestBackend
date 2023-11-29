using Microsoft.AspNetCore.Mvc;
using MediatR;
using FluentValidation;
using FluentValidation.Results;

namespace arktiktest{

    /// <summary>
    /// Контроллер материалов
    /// </summary>
    [Route("Materials")]
    [ApiController]
    public class MaterialController:RESTController<Material,MaterialDTO>{

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public MaterialController(IMediator mediator, IValidator<MaterialDTO> validator, DbMain db,ILogger<RESTController<Material,MaterialDTO>> logger):base(mediator,validator,new MaterialRepository(db),logger){}

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        override protected IRequest<List<Material>> GetAllRequest(DbRepository<Material,MaterialDTO> cs) => new getAllRequest<Material,MaterialDTO>(cs);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        override protected IRequest<Material?> GetOneRequest(DbRepository<Material,MaterialDTO> cs, int id) => new GetOneRequest<Material,MaterialDTO>(cs,id);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        override protected IRequest<Material?> PostRequest(DbRepository<Material,MaterialDTO> cs,MaterialDTO obj) => new PostRequest<Material,MaterialDTO>(cs,obj);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        override protected IRequest<Material?> PutRequest(DbRepository<Material,MaterialDTO> cs, int id, MaterialDTO obj) => new PutRequest<Material,MaterialDTO>(cs,id, obj);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        override protected  IRequest<Material?> DeleteRequest(DbRepository<Material,MaterialDTO> cs, int id) => new DeleteRequest<Material,MaterialDTO>(cs,id);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        override protected IRequest<ValidationResult> ValidateRequest(IValidator<MaterialDTO> valid, MaterialDTO obj) => new ValidateRequest<Material,MaterialDTO>(valid,obj);

        /// <summary>
        /// Запрос возвращает список материалов
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
        /// Запрос добаляет данный материал в базу данных
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Materials
        ///     {
        ///        "name": "material",
        ///        "price": 12,
        ///        "sellerId": 1
        ///     } 
        ///
        /// </remarks> 
        /// <response code="201">Возвращает созданный материал</response>
        /// <response code="400">Параметры материала заданны неверно</response>
        /// <response code="404">Материал не найден</response>
        /// <param name="obj">Добавляемый материал</param>
        /// <returns>Добаленный материал</returns>
        override public async Task<IActionResult> Post(MaterialDTO obj) => await base.Post(obj);

        /// <summary>
        /// Запрос обновляет материал с заданным id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Materials/{id}
        ///     {
        ///        "name": "material",
        ///        "price": 12,
        ///        "sellerId": 1
        ///     } 
        ///
        /// </remarks> 
        /// <response code="200">Возвращает обновленный материал</response>
        /// <response code="400">Параметры материала заданны неверно</response>
        /// <response code="404">Материал не найден</response>
        /// <param name="id">Id обновляемого материала</param>
        /// <param name="obj">Новые данные обновляемого материала</param>
        /// <returns>Обновленный материал</returns>
        override public async Task<IActionResult> Put(int id, MaterialDTO obj) => await base.Put(id,obj);

        /// <summary>
        /// Запрос удаляет материал с заданным id
        /// </summary>
        /// <response code="200">Возвращает удаленный материал</response>
        /// <response code="404">материал не найден</response>
        /// <returns>Удаленный материал</returns>
        override public async Task<IActionResult> Delete(int id) => await base.Delete(id);
    }
}