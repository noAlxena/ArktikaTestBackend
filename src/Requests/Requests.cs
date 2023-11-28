using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace arktiktest{
    
    public class getAllRequest<TObject,DTObject> : IRequest<List<TObject>> where TObject:DataObject where DTObject:IDataTransferObject<TObject>{
        public DbRepository<TObject,DTObject> _cs;
        public getAllRequest(DbRepository<TObject,DTObject> cs){
            _cs = cs;
        }
    };

    public class GetOneRequest<TObject,DTObject> : IRequest<TObject> where TObject:DataObject where DTObject:IDataTransferObject<TObject>{
        public int _id;
        public DbRepository<TObject,DTObject> _cs;
        public GetOneRequest(DbRepository<TObject,DTObject> cs, int id){
            _cs = cs;
            _id = id;
        }
    };

    public class PostRequest<TObject,DTObject> : IRequest<TObject> where TObject:DataObject where DTObject:IDataTransferObject<TObject>{
        public DTObject _req;
        public DbRepository<TObject,DTObject> _cs;
        public PostRequest(DbRepository<TObject,DTObject> cs, DTObject req){
            _cs = cs;
            _req = req;
        }
    };

    public class PutRequest<TObject,DTObject> : IRequest<TObject> where TObject:DataObject where DTObject:IDataTransferObject<TObject>{
        public DTObject _req;
        public int _id;
        public DbRepository<TObject,DTObject> _cs;
        public PutRequest(DbRepository<TObject,DTObject> cs, int id, DTObject req){
            _id = id;
            _cs = cs;
            _req = req;
        }
    };

    public class DeleteRequest<TObject,DTObject> : IRequest<TObject> where TObject:DataObject where DTObject:IDataTransferObject<TObject>{
        public int _id;
        public DbRepository<TObject,DTObject> _cs;
        public DeleteRequest (DbRepository<TObject,DTObject> cs, int id){
            _cs = cs;
            _id = id;
        }
    };

    public class ValidateRequest<TObject,DTObject> : IRequest<ValidationResult> where TObject:DataObject where DTObject:IDataTransferObject<TObject>{
        public DTObject _req;
        public IValidator<DTObject> _valid;
        public ValidateRequest (IValidator<DTObject> valid, DTObject req){
            _req = req;
            _valid = valid;
        }
    };
}