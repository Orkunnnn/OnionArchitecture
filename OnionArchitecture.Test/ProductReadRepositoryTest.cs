using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnionArchitecture.Application.Enums;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistence.Contexts;
using OnionArchitecture.Persistence.Repositories.Products;

namespace OnionArchitecture.Test
{
    public class ProductReadRepositoryTest
    {
        private DbContextOptions<OnionArchitectureDbContext> _dbContextOptions;
        private readonly IConfiguration _configuration;

        public ProductReadRepositoryTest(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private ProductReadRepository _productReadRepository;
        private Guid _productId;

        [SetUp]
        public void Setup()
        {
            _productId = Guid.NewGuid();
            var databaseName = $"OnionArchitectureTest_{DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<OnionArchitectureDbContext>().UseInMemoryDatabase(databaseName).EnableSensitiveDataLogging().Options;
            var context = new OnionArchitectureDbContext(_dbContextOptions, _configuration);
            var category = new Category { Id = Guid.NewGuid(), Name = "Fruits" };
            context.Categories.Add(category);
            context.Products.AddRange(new List<Product> { new Product { Id = _productId, Name = "Apple", Stock = 12, Price = 10, Category = category }, new Product { Id = Guid.NewGuid(), Name = "Banana", Stock = 10, Price = 9, Category = new Category { Id = Guid.NewGuid(), Name = "Vegetables" } } });
            context.SaveChanges();
            _productReadRepository = new ProductReadRepository(context);
        }

        [Test]
        public void Get_Products()
        {
            var products = _productReadRepository.GetAll(TrackingState.NoTracking);
            products.Should().NotBeNull().And.HaveCount(2);
        }

        [Test]
        public void Get_Product_By_Id()
        {
            var product = _productReadRepository.GetById(_productId, TrackingState.NoTracking);
            product.Should().NotBeNull();
        }

        [Test]
        public void Get_Product_By_Filter()
        {
            var product = _productReadRepository.GetByFilter(p => p.Name == "Apple", TrackingState.NoTracking);
            product.Should().NotBeNull();
        }

        [Test]
        public void Get_Product_Category()
        {
            var product = _productReadRepository.GetById(_productId);
            product?.Category.Name.Should().NotBeNull().And.Be("Fruits");
        }

        [Test]
        public void Get_Products_By_Filter()
        {
            var products = _productReadRepository.GetAllByFilter(p => p.Category.Name == "Fruits");
            products.Should().NotBeNull().And.HaveCount(1);
        }
    }
}
