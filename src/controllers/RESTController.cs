using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace arktiktest{
    public abstract class RESTController<TObject,DTObject>:ControllerBase where TObject:DataObject where DTObject:IDataTransferObject<TObject>{
        DbRepository<TObject,DTObject> rp; 
        IMediator mediator;
        ILogger<RESTController<TObject,DTObject>> logger;
        IValidator<DTObject> validator;
        public RESTController(IMediator mediator, IValidator<DTObject> validator, DbRepository<TObject,DTObject> rp,ILogger<RESTController<TObject,DTObject>> logger){
            this.mediator = mediator;
            this.rp = rp;
            this.logger = logger;
            this.validator = validator;
        }

        protected abstract IRequest<List<TObject>> GetAllRequest(DbRepository<TObject,DTObject> cs);
        protected abstract IRequest<TObject?> GetOneRequest(DbRepository<TObject,DTObject> cs, int id);
        protected abstract IRequest<TObject?> PostRequest(DbRepository<TObject,DTObject> cs, DTObject obj);
        protected abstract IRequest<TObject?> PutRequest(DbRepository<TObject,DTObject> cs,int id, DTObject obj);
        protected abstract IRequest<TObject?> DeleteRequest(DbRepository<TObject,DTObject> cs, int id);
        protected abstract IRequest<ValidationResult> ValidateRequest(IValidator<DTObject> valid, DTObject obj);
        [HttpGet]
        [Route("")]
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
        /// <returns>Материал из бд</returns>
        [HttpGet]
        [Route("{id:int}")]
        public virtual async Task<IActionResult> Get(int id){
            logger.LogInformation($"getOne request id-{id} at {DateTime.Now.ToLongTimeString()}");
            TObject? res = await mediator.Send(GetOneRequest(rp,id));
            return (res == null) ? NotFound() : Ok(res);    
        }

        /// <summary>
        /// Запрос создаёт объект
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
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
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
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
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public virtual async Task<IActionResult> Delete(int id){
            logger.LogInformation($"delete request id={id} at {DateTime.Now.ToLongTimeString()}");
            TObject? res = await mediator.Send(DeleteRequest(rp,id));
            return (res == null) ? NotFound(id) : Ok(res);    
        }
    }
}