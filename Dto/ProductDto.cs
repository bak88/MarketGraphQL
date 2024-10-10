namespace MarketGraphQL.Dto
{
    public class ProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int? ProductGroupId { get; set; }
    }
}
