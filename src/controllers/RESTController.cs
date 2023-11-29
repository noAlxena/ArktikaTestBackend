using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace arktiktest{
    /// <summary>
    /// Базовый класс контроллера API
    /// </summary>
    /// <typeparam name="TObject">тип объекта</typeparam>
    /// <typeparam name="DTObject">тип объекта передачи данных</typeparam>
    public abstract class RESTController<TObject,DTObject>:ControllerBase where TObject:DataObject where DTObject:IDataTransferObject<TObject>{
        DbRepository<TObject,DTObject> rp; 
        IMediator mediator;
        ILogger<RESTController<TObject,DTObject>> logger;
        IValidator<DTObject> validator;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public RESTController(IMediator mediator, IValidator<DTObject> validator, DbRepository<TObject,DTObject> rp,ILogger<RESTController<TObject,DTObject>> logger){
            this.mediator = mediator;
            this.rp = rp;
            this.logger = logger;
            this.validator = validator;
        }

        /// <summary>
        /// Функция возвращающая запрос на получение всех объектов
        /// </summary>
        /// <param name="rp">Репозиторий из которого необходимо взять объекты</param>
        /// <returns>Запрос на получение всех объектов</returns>
        protected abstract IRequest<List<TObject>> GetAllRequest(DbRepository<TObject,DTObject> rp);

        /// <summary>
        /// Функция возвращающая запрос на получение одного объекта
        /// </summary>
        /// <param name="rp">Репозиторий из которого необходимо взять объект</param>
        /// <param name="id">Id получаемого объекта</param>
        /// <returns>Запрос на получение одного объекта</returns>
        protected abstract IRequest<TObject?> GetOneRequest(DbRepository<TObject,DTObject> rp, int id);

        /// <summary>
        /// Функция возвращающая запрос на добавление объекта
        /// </summary>
        /// <param name="rp">Репозиторий в который необходимо добавить объект</param>
        /// <param name="obj">Объект который необходимо добавить</param>
        /// <returns>Запрос на добавление объекта</returns>
        protected abstract IRequest<TObject?> PostRequest(DbRepository<TObject,DTObject> rp, DTObject obj);

        /// <summary>
        /// Функция возвращающая запрос на изменение объекта
        /// </summary>
        /// <param name="rp">Репозиторий в котором необходимо изменить объект</param>
        /// <param name="id">Id изменяемого объекта</param>
        /// <param name="obj">Объект который необходимо изменить</param>
        /// <returns>Запрос на изменение объекта</returns>
        protected abstract IRequest<TObject?> PutRequest(DbRepository<TObject,DTObject> rp,int id, DTObject obj);

        /// <summary>
        /// Функция возвращающая запрос на удаление объекта
        /// </summary>
        /// <param name="rp">Репозиторий из которого необходимо удалить объект</param>
        /// <param name="id">Id удаляемого объекта</param>
        /// <returns>Запрос на удаление объекта</returns>
        protected abstract IRequest<TObject?> DeleteRequest(DbRepository<TObject,DTObject> rp, int id);

        /// <summary>
        /// Функция возвращающая запроса на валидацию объекта
        /// </summary>
        /// <param name="obj">Объект который необходимо валидировать</param>
        /// <param name="valid">Валидатор объекта</param>
        /// <returns>Запроса на валидацию объекта</returns>
        protected abstract IRequest<ValidationResult> ValidateRequest(IValidator<DTObject> valid, DTObject obj);
        
        /// <summary>
        /// Запрос возвращает список объектов
        /// </summary>
        /// <response code="200">Возвращает список объектов</response>
        /// <returns>Список объектов из бд</returns>
        [HttpGet]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetAll(){
            logger.LogInformation($"getAll request at {DateTime.Now.ToLongTimeString()}");
            return Ok(await mediator.Send(GetAllRequest(rp)));
        }
        
        /// <summary>
        /// Запрос возвращает объект с заданым id
        /// </summary>
        /// <response code="200">Возвращает найденный объект</response>
        /// <response code="404">Объект не найден</response>
        /// <param name="id">id объекта</param>
        /// <returns>Объект из бд</returns>
        [HttpGet]
        [Route("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Get(int id){
            logger.LogInformation($"getOne request id-{id} at {DateTime.Now.ToLongTimeString()}");
            TObject? res = await mediator.Send(GetOneRequest(rp,id));
            return (res == null) ? NotFound() : Ok(res);    
        }

        /// <summary>
        /// Запрос добаляет данный объект в базу данных
        /// </summary>
        /// <response code="201">Возвращает созданный объект</response>
        /// <response code="400">Параметры объекта заданны неверно</response>
        /// <response code="404">Объект не найден</response>
        /// <param name="obj">Добавляемый объект</param>
        /// <returns>Добаленный объект</returns>
        [HttpPost]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Post(DTObject obj){
            logger.LogInformation($"Post request {obj} at {DateTime.Now.ToLongTimeString()}");
            var validationResult = await mediator.Send(ValidateRequest(validator, obj)); 
            if (!validationResult.IsValid) 
                return BadRequest(validationResult.ToDictionary());
            TObject? res = await mediator.Send(PostRequest(rp,obj));
            return (res == null) ? NotFound(obj) : Created("{res.Id}",res);    
        }

        /// <summary>
        /// Запрос обновляет объект с заданным id
        /// </summary>
        /// <response code="200">Возвращает обновленный объект</response>
        /// <response code="400">Параметры объекта заданны неверно</response>
        /// <response code="404">Объект не найден</response>
        /// <param name="id">Id обновляемого объекта</param>
        /// <param name="obj">Новые данные обновляемого объекта</param>
        /// <returns>Обновленный объект</returns>
        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Put(int id, DTObject obj){
            logger.LogInformation($"Put request id={id} {obj} at {DateTime.Now.ToLongTimeString()}");
            var validationResult = await mediator.Send(ValidateRequest(validator, obj)); 
            if (!validationResult.IsValid) 
                return BadRequest(validationResult.ToDictionary());
            TObject? res = await mediator.Send(PutRequest(rp,id,obj));
            return (res == null) ? NotFound(obj) : Ok(res);    
        }

        /// <summary>
        /// Запрос удаляет объект с заданным id
        /// </summary>
        /// <response code="200">Возвращает удаленный объект</response>
        /// <response code="404">Объект не найден</response>
        /// <returns>Удаленный объект</returns>
        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Delete(int id){
            logger.LogInformation($"delete request id={id} at {DateTime.Now.ToLongTimeString()}");
            TObject? res = await mediator.Send(DeleteRequest(rp,id));
            return (res == null) ? NotFound(id) : Ok(res);    
        }
    }
}