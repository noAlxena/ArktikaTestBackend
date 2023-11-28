using MediatR;
using FluentValidation.Results;
namespace arktiktest{
    public abstract class GetAllHandler<TObject,DTObject> : IRequestHandler<getAllRequest<TObject,DTObject>, List<TObject>> where TObject:DataObject where DTObject:IDataTransferObject<TObject>
    {
        public virtual async Task<List<TObject>> Handle(getAllRequest<TObject,DTObject>  request, CancellationToken cancellationToken) =>
            await request._cs.GetAll();
    }
    class GetOneHandler<TObject,DTObject> : IRequestHandler<GetOneRequest<TObject,DTObject>, TObject?>where TObject:DataObject where DTObject:IDataTransferObject<TObject>
    {
        public virtual async Task<TObject?> Handle(GetOneRequest<TObject,DTObject>  request, CancellationToken cancellationToken) =>
            await request._cs.GetOne(request._id);
    }

    class PostHandler<TObject,DTObject> : IRequestHandler<PostRequest<TObject,DTObject>, TObject?> where TObject:DataObject where DTObject:IDataTransferObject<TObject>
    {
        public virtual async Task<TObject?> Handle(PostRequest<TObject,DTObject> request, CancellationToken cancellationToken) =>
            await request._cs.Post(request._req);
    }

    class PutHandler<TObject, DTObject> : IRequestHandler<PutRequest<TObject, DTObject>, TObject?>where TObject:DataObject where DTObject:IDataTransferObject<TObject>
    {
        public virtual async Task<TObject?> Handle(PutRequest<TObject,DTObject> request, CancellationToken cancellationToken)=>
            await request._cs.Put(request._id,request._req);
    }

    class DeleteHandler<TObject,DTObject> : IRequestHandler<DeleteRequest<TObject,DTObject>, TObject?>where TObject:DataObject where DTObject:IDataTransferObject<TObject>
    {
        public virtual async Task<TObject?> Handle(DeleteRequest<TObject,DTObject> request, CancellationToken cancellationToken)=>
            await request._cs.Delete(request._id);
    }
    class ValidateHandler<TObject, DTObject> : IRequestHandler<ValidateRequest<TObject,DTObject>, ValidationResult>where TObject:DataObject where DTObject:IDataTransferObject<TObject>
    {
        public virtual async Task<ValidationResult> Handle(ValidateRequest<TObject,DTObject> request, CancellationToken cancellationToken) =>
            await request._valid.ValidateAsync(request._req);
    }
}