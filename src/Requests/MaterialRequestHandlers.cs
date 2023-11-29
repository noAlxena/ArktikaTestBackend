namespace arktiktest{

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    class GetAllMatHandler : GetAllHandler<Material, MaterialDTO>{}

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    class GetOneMatHandler : GetOneHandler<Material, MaterialDTO>{}

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    class PostMatHandler : PostHandler<Material, MaterialDTO>{}

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    class PutMatHandler : PutHandler<Material, MaterialDTO>{}

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    class DeleteMatHandler : DeleteHandler<Material, MaterialDTO>{}

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    class ValidateMatHandler : ValidateHandler<Material, MaterialDTO>{}
}