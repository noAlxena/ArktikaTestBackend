using Microsoft.EntityFrameworkCore;
namespace arktiktest{
    class GetAllSelHandler : GetAllHandler<Seller,SellerDTO>{}
    class GetOneSelHandler : GetOneHandler<Seller,SellerDTO>{}
    class PostSelHandler : PostHandler<Seller,SellerDTO>{}
    class PutSelHandler : PutHandler<Seller,SellerDTO>{}
    class DeleteSelHandler : DeleteHandler<Seller,SellerDTO>{}
    class ValidateSelHandler : ValidateHandler<Seller,SellerDTO>{}
}