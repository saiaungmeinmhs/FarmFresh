namespace FarmFresh.Dto.ProductDto
{
    public class CreateProductRequest
    {
        public string Name {get;set;}
        public string ProductUrl{get;set;}
        public string Description {get;set;}
        public int CategoryId {get;set;}
        public int UnitId {get;set;}

    }
}