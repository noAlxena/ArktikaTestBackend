using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace arktiktest{
    
    /// <summary>
    /// Класс запроса на получение всех объектов
    /// </summary>
    /// <typeparam name="TObject">тип объекта</typeparam>
    /// <typeparam name="DTObject">тип объекта передачи данных</typeparam>
    public class getAllRequest<TObject,DTObject> : IRequest<List<TObject>> where TObject:DataObject where DTObject:IDataTransferObject<TObject>{

        /// <summary>
        /// Репозиторий из которого необходимо взять объекты
        /// </summary>
        public DbRepository<TObject,DTObject> rp;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="rp">Репозиторий из которого необходимо взять объекты</param>
        public getAllRequest(DbRepository<TObject,DTObject> rp){
            this.rp = rp;
        }
    }

    /// <summary>
    /// Класс запроса на получение одного объекта
    /// </summary>
    /// <typeparam name="TObject">тип объекта</typeparam>
    /// <typeparam name="DTObject">тип объекта передачи данных</typeparam>
    public class GetOneRequest<TObject,DTObject> : IRequest<TObject> where TObject:DataObject where DTObject:IDataTransferObject<TObject>{

        /// <summary>
        /// Id получаемого объекта
        /// </summary>
        public int id;

        /// <summary>
        /// Репозиторий из которого необходимо взять объект
        /// </summary>
        public DbRepository<TObject,DTObject> rp;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="rp">Репозиторий из которого необходимо взять объект</param>
        /// <param name="id">Id получаемого объекта</param>
        public GetOneRequest(DbRepository<TObject,DTObject> rp, int id){
            this.rp = rp;
            this.id = id;
        }
    }

    /// <summary>
    /// Класс запроса на добавление объекта
    /// </summary>
    /// <typeparam name="TObject">тип объекта</typeparam>
    /// <typeparam name="DTObject">тип объекта передачи данных</typeparam>
    public class PostRequest<TObject,DTObject> : IRequest<TObject> where TObject:DataObject where DTObject:IDataTransferObject<TObject>{
        
        /// <summary>
        /// Объект который необходимо добавить
        /// </summary>
        public DTObject obj;

        /// <summary>
        /// Репозиторий в который необходимо добавить объект
        /// </summary>
        public DbRepository<TObject,DTObject> rp;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="rp">Репозиторий в который необходимо добавить объект</param>
        /// <param name="obj">Объект который необходимо добавить</param>
        public PostRequest(DbRepository<TObject,DTObject> rp, DTObject obj){
            this.rp = rp;
            this.obj = obj;
        }
    }

    /// <summary>
    /// Класс запроса на изменение объекта
    /// </summary>
    /// <typeparam name="TObject">тип объекта</typeparam>
    /// <typeparam name="DTObject">тип объекта передачи данных</typeparam>
    public class PutRequest<TObject,DTObject> : IRequest<TObject> where TObject:DataObject where DTObject:IDataTransferObject<TObject>{

        /// <summary>
        /// Новые данные объекта
        /// </summary>
        public DTObject obj;

        /// <summary>
        /// Id изменяемого объекта
        /// </summary>
        public int id;

        /// <summary>
        /// Репозиторий в котором необходимо изменить объект
        /// </summary>
        public DbRepository<TObject,DTObject> rp;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="rp">Репозиторий в котором необходимо изменить объект</param>
        /// <param name="id">Id изменяемого объекта</param>
        /// <param name="obj">Объект который необходимо изменить</param>
        public PutRequest(DbRepository<TObject,DTObject> rp, int id, DTObject obj){
            this.id = id;
            this.rp = rp;
            this.obj = obj;
        }
    }

    /// <summary>
    /// Класс запроса на удаление объекта
    /// </summary>
    /// <typeparam name="TObject">тип объекта</typeparam>
    /// <typeparam name="DTObject">тип объекта передачи данных</typeparam>
    public class DeleteRequest<TObject,DTObject> : IRequest<TObject> where TObject:DataObject where DTObject:IDataTransferObject<TObject>{

        /// <summary>
        /// Id удаляемого объекта
        /// </summary>
        public int id;

        /// <summary>
        /// Репозиторий из которого необходимо удалить объект
        /// </summary>
        public DbRepository<TObject,DTObject> rp;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="rp">Репозиторий из которого необходимо удалить объект</param>
        /// <param name="id">Id удаляемого объекта</param>
        public DeleteRequest (DbRepository<TObject,DTObject> rp, int id){
            this.rp = rp;
            this.id = id;
        }
    }

    /// <summary>
    /// Класс запроса на валидацию объекта
    /// </summary>
    /// <typeparam name="TObject">тип объекта</typeparam>
    /// <typeparam name="DTObject">тип объекта передачи данных</typeparam>
    public class ValidateRequest<TObject,DTObject> : IRequest<ValidationResult> where TObject:DataObject where DTObject:IDataTransferObject<TObject>{

        /// <summary>
        /// Объект который необходимо валидировать
        /// </summary>
        public DTObject obj;

        /// <summary>
        /// Валидатор объекта
        /// </summary>
        public IValidator<DTObject> valid;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="obj">Объект который необходимо валидировать</param>
        /// <param name="valid">Валидатор объекта</param>
        public ValidateRequest (IValidator<DTObject> valid, DTObject obj){
            this.obj = obj;
            this.valid = valid;
        }
    }
}