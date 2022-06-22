using OnionArchitecture.Domain.Entities.Common;

namespace OnionArchitecture.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;
        public ICollection<Product> Products { get; set; } = default!;
    }
}
