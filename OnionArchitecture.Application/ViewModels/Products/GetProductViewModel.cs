namespace OnionArchitecture.Application.ViewModels.Products
{
    public class GetProductViewModel
    {
        public string Name { get; set; } = default!;
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; } = default!;
    }
}
