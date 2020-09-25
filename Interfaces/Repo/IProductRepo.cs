using System.Collections.Generic;
using System.Threading.Tasks;
using FarmFresh.Dto;
using FarmFresh.Dto.ProductDto;

namespace FarmFresh.Interfaces.Repo
{
    public interface IProductRepo
    {
         Task<List<GetProductListResponse>> GetProductList(GetProductListRequest request);
         Task<List<GetCategoryListResponse>> GetCategoryList();
         Task<ResponseStatus> CreateProduct(CreateProductRequest request);
         Task<ResponseStatus> UpdateProduct(UpdateProductRequest request);
         Task<ResponseStatus> DeleteProduct(int productId);
    }
}