namespace FarmFresh.Dto.ProductDto
{
    public class GetProductListRequest : PaginationRequest
    {
        public string ProductName {get;set;}
        public int CategoryId {get;set;}
    }
}