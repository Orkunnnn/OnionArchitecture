namespace OnionArchitecture.Application.ViewModels.Products
{
    public class AddProductViewModel
    {
        public string Name { get; set; } = default!;
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
