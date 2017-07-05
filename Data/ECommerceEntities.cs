using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Configurations;
using Model.Models;

namespace Data
{
    public class ECommerceEntities : DbContext
    {
        public ECommerceEntities() : base("ECommerceEntities")
        {
        }

        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<FrontPageBanner> FrontPageBanners { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<FeaturedProduct> FeaturedProducts { get; set; }
        public DbSet<LastSeenProducts> LastSeenProducts { get; set; }
        public DbSet<Coupons> Coupons { get; set; }
        public DbSet<ShippingType> ShippingTypes { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<WishListDetail> WishListDetails { get; set; }
        public DbSet<Image> Images { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CompanyInfoConfigurations());
            modelBuilder.Configurations.Add(new CurrencyConfigurations());
            modelBuilder.Configurations.Add(new CategoryConfigurations());
            modelBuilder.Configurations.Add(new SubCategoryConfigurations());
            modelBuilder.Configurations.Add(new BrandConfigurations());
            modelBuilder.Configurations.Add(new FrontPageBannerConfigurations());
            modelBuilder.Configurations.Add(new CountryConfigurations());
            modelBuilder.Configurations.Add(new CityConfigurations());
            modelBuilder.Configurations.Add(new TownConfigurations());
            modelBuilder.Configurations.Add(new ColorConfigurations());
            modelBuilder.Configurations.Add(new AddressConfigurations());
            modelBuilder.Configurations.Add(new CompanyConfigurations());
            modelBuilder.Configurations.Add(new ProductConfigurations());
            modelBuilder.Configurations.Add(new ProductDetailConfigurations());
            modelBuilder.Configurations.Add(new UserConfigurations());
            modelBuilder.Configurations.Add(new CartConfigurations());
            modelBuilder.Configurations.Add(new CartDetailConfigurations());
            modelBuilder.Configurations.Add(new OrderConfigurations());
            modelBuilder.Configurations.Add(new OrderDetailConfigurations());
            modelBuilder.Configurations.Add(new FeaturedProductsConfigurations());
            modelBuilder.Configurations.Add(new LastSeenProductsConfigurations());
            modelBuilder.Configurations.Add(new CouponConfigurations());
            modelBuilder.Configurations.Add(new ShippingTypeConfigurations());
            modelBuilder.Configurations.Add(new WishListConfigurations());
            modelBuilder.Configurations.Add(new WishListDetailConfigurations());
            modelBuilder.Configurations.Add(new ImageConfiguration());
        }
    }
}
