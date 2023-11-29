using MediatR;
using FluentValidation.Results;
namespace arktiktest{

    /// <summary>
    /// Класс для обработки запроса на получение всех объектов
    /// </summary>
    /// <typeparam name="TObject">тип объекта</typeparam>
    /// <typeparam name="DTObject">тип объекта передачи данных</typeparam>
    public abstract class GetAllHandler<TObject,DTObject> : IRequestHandler<getAllRequest<TObject,DTObject>, List<TObject>> where TObject:DataObject where DTObject:IDataTransferObject<TObject>
    {

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual async Task<List<TObject>> Handle(getAllRequest<TObject,DTObject>  request, CancellationToken cancellationToken) =>
            await request.rp.GetAll();
    }

    /// <summary>
    /// Класс для обработки запроса на получение одного объекта
    /// </summary>
    /// <typeparam name="TObject">тип объекта</typeparam>
    /// <typeparam name="DTObject">тип объекта передачи данных</typeparam>
    class GetOneHandler<TObject,DTObject> : IRequestHandler<GetOneRequest<TObject,DTObject>, TObject?>where TObject:DataObject where DTObject:IDataTransferObject<TObject>
    {

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual async Task<TObject?> Handle(GetOneRequest<TObject,DTObject>  request, CancellationToken cancellationToken) =>
            await request.rp.GetOne(request.id);
    }

    /// <summary>
    /// Класс для обработки запроса на добавление объекта
    /// </summary>
    /// <typeparam name="TObject">тип объекта</typeparam>
    /// <typeparam name="DTObject">тип объекта передачи данных</typeparam>
    class PostHandler<TObject,DTObject> : IRequestHandler<PostRequest<TObject,DTObject>, TObject?> where TObject:DataObject where DTObject:IDataTransferObject<TObject>
    {

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual async Task<TObject?> Handle(PostRequest<TObject,DTObject> request, CancellationToken cancellationToken) =>
            await request.rp.Post(request.obj);
    }

    /// <summary>
    /// Класс для обработки запроса на обновление объекта
    /// </summary>
    /// <typeparam name="TObject">тип объекта</typeparam>
    /// <typeparam name="DTObject">тип объекта передачи данных</typeparam>
    class PutHandler<TObject, DTObject> : IRequestHandler<PutRequest<TObject, DTObject>, TObject?>where TObject:DataObject where DTObject:IDataTransferObject<TObject>
    {

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual async Task<TObject?> Handle(PutRequest<TObject,DTObject> request, CancellationToken cancellationToken)=>
            await request.rp.Put(request.id,request.obj);
    }

    /// <summary>
    /// Класс для обработки запроса на удаление объекта
    /// </summary>
    /// <typeparam name="TObject">тип объекта</typeparam>
    /// <typeparam name="DTObject">тип объекта передачи данных</typeparam>
    class DeleteHandler<TObject,DTObject> : IRequestHandler<DeleteRequest<TObject,DTObject>, TObject?>where TObject:DataObject where DTObject:IDataTransferObject<TObject>
    {

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual async Task<TObject?> Handle(DeleteRequest<TObject,DTObject> request, CancellationToken cancellationToken)=>
            await request.rp.Delete(request.id);
    }

    /// <summary>
    /// Класс для обработки запроса на валидацию объекта
    /// </summary>
    /// <typeparam name="TObject">тип объекта</typeparam>
    /// <typeparam name="DTObject">тип объекта передачи данных</typeparam>
    class ValidateHandler<TObject, DTObject> : IRequestHandler<ValidateRequest<TObject,DTObject>, ValidationResult>where TObject:DataObject where DTObject:IDataTransferObject<TObject>
    {

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual async Task<ValidationResult> Handle(ValidateRequest<TObject,DTObject> request, CancellationToken cancellationToken) =>
            await request.valid.ValidateAsync(request.obj);
    }
}