namespace arktiktest{
    class GetAllMatHandler : GetAllHandler<Material, MaterialDTO>{}
    class GetOneMatHandler : GetOneHandler<Material, MaterialDTO>{}
    class PostMatHandler : PostHandler<Material, MaterialDTO>{}
    class PutMatHandler : PutHandler<Material, MaterialDTO>{}
    class DeleteMatHandler : DeleteHandler<Material, MaterialDTO>{}
    class ValidateMatHandler : ValidateHandler<Material, MaterialDTO>{}
}