using Microsoft.EntityFrameworkCore;
namespace arktiktest{

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    class GetAllSelHandler : GetAllHandler<Seller,SellerDTO>{}

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    class GetOneSelHandler : GetOneHandler<Seller,SellerDTO>{}

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    class PostSelHandler : PostHandler<Seller,SellerDTO>{}

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    class PutSelHandler : PutHandler<Seller,SellerDTO>{}

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    class DeleteSelHandler : DeleteHandler<Seller,SellerDTO>{}

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    class ValidateSelHandler : ValidateHandler<Seller,SellerDTO>{}
}