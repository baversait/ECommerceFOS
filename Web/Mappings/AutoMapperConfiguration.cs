using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Model.Models;
using Web.Models.DTOs;

namespace Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Address, AddressDTO>()
                    .ForMember(
                        dest => dest.CityID,
                        opt => opt.MapFrom(src => src.Town.CityID))
                        .ForMember(
                        dest => dest.CountryID,
                        opt => opt.MapFrom(src => src.Town.City.CountryID));

                x.CreateMap<AddressDTO, Address>();

                x.CreateMap<Town, TownDTO>();
                x.CreateMap<TownDTO, Town>();

                x.CreateMap<City, CityDTO>()
                    .ForMember(
                        dest => dest.Towns,
                        opt => opt.Ignore());
                x.CreateMap<CityDTO, City>();
                x.CreateMap<Country, CountryDTO>()
                    .ForMember(
                        dest => dest.Cities,
                        opt => opt.Ignore());
                x.CreateMap<CountryDTO, Country>();

                x.CreateMap<Company, CompanyDTO>();
                x.CreateMap<CompanyDTO, Company>();

                x.CreateMap<CompanyInfo, CompanyInfoDTO>()
                .ForMember(
                    dest => dest.CountryID,
                    opt => opt.MapFrom(src => src.Address.Town.City.CountryID))
                .ForMember(
                    dest => dest.CityID,
                    opt => opt.MapFrom(src => src.Address.Town.CityID))
                .ForMember(
                    dest => dest.TownID,
                    opt => opt.MapFrom(src => src.Address.TownID))
                .ForMember(
                        dest => dest.ImagePath,
                        opt => opt.ResolveUsing(src => (src.LogoImages != null && src.LogoImages.Count > 0) ? src.LogoImages.ToList()[0].ImagePath : null));

                x.CreateMap<CompanyInfoDTO, CompanyInfo>();

                x.CreateMap<ProductDetail, ProductDetailDTO>()
                .ForMember(
                    dest => dest.ColorName,
                    opt => opt.MapFrom(src => src.Color.ColorName))
                    .ForMember(
                        dest => dest.ProductName,
                        opt => opt.MapFrom(src => src.Product.ProductName))
                 .ForMember(
                    dest => dest.CurrentUnitPrice,
                    opt => opt.MapFrom(src => src.UnitPrice * (100 - src.Discount) / 100));

                x.CreateMap<ProductDetailDTO, ProductDetail>();

                x.CreateMap<Product, ProductDTO>()
                    .ForMember(
                        dest => dest.SubCategoryName,
                        opt => opt.MapFrom(src => src.SubCategory.SubCategoryName))
                    .ForMember(
                        dest => dest.CategoryID,
                        opt => opt.MapFrom(src => src.SubCategory.CategoryID))
                    .ForMember(
                        dest => dest.BrandName,
                        opt => opt.MapFrom(src => src.Brand.BrandName))
                    .ForMember(
                        dest => dest.SupplierName,
                        opt => opt.MapFrom(src => src.Supplier.CompanyName))
                     .ForMember(
                        dest => dest.ProductDetails,
                        opt => opt.MapFrom(src => src.ProductDetails));

                x.CreateMap<ProductDTO, Product>();

                x.CreateMap<FrontPageBanner, FrontPageBannerDTO>();

                x.CreateMap<FrontPageBannerDTO, FrontPageBanner>();


                x.CreateMap<ShippingType, ShippingTypesDTO>();
                x.CreateMap<ShippingTypesDTO, ShippingType>();

                x.CreateMap<Category, CategoryDTO>();
                x.CreateMap<CategoryDTO, Category>();

                x.CreateMap<SubCategory, SubCategoryDTO>()
                    .ForMember(
                        dest => dest.CategoryName,
                        opt => opt.MapFrom(src => src.Category.CategoryName));
                x.CreateMap<SubCategoryDTO, SubCategory>();

                x.CreateMap<Image, ImageDTO>();
                x.CreateMap<ImageDTO, Image>();

                x.CreateMap<Brand, BrandDTO>()
                    .ForMember(
                        dest => dest.ImagePath,
                        opt => opt.ResolveUsing(src => (src.Images != null && src.Images.Count > 0) ? src.Images.ToList()[0].ImagePath : null));
                x.CreateMap<BrandDTO, Brand>();

                x.CreateMap<User, UserDTO>();
                x.CreateMap<UserDTO, User>();

                x.CreateMap<Currency, CurrencyDTO>();
                x.CreateMap<CurrencyDTO, Currency>();

                x.CreateMap<Cart, CartDTO>();
                x.CreateMap<CartDTO, Cart>();

                x.CreateMap<CartDetailDTO, CartDetail>();
                x.CreateMap<CartDetail, CartDetailDTO>()
                    .ForMember(
                        dest => dest.TotalPrice,
                        opt => opt.MapFrom(src => src.UnitPrice * src.Quantity));

                x.CreateMap<Coupons, CouponsDTO>()
                    .ForMember(
                        dest => dest.CategoryName,
                        opt => opt.MapFrom(src => src.Category.CategoryName))
                    .ForMember(
                        dest => dest.CategoryID,
                        opt => opt.MapFrom(src => src.Category.CategoryID))
                    .ForMember(
                        dest => dest.CustomerID,
                        opt => opt.MapFrom(src => src.User.UserID))
                    .ForMember(
                        dest => dest.CustomerName,
                        opt => opt.MapFrom(src => src.User.Name + " " + src.User.LastName + " " + src.User.Email));

                x.CreateMap<CouponsDTO, Coupons>();

                x.CreateMap<FeaturedProduct, FeaturedProductDTO>()
                    .ForMember(
                        dest => dest.ProductID,
                        opt => opt.MapFrom(src => src.ProductDetail.ProductID))
                    .ForMember(
                        dest => dest.ProductName,
                        opt => opt.MapFrom(src => src.ProductDetail.Product.ProductName));

                x.CreateMap<FeaturedProductDTO, FeaturedProduct>();

                x.CreateMap<Order, OrderDTO>()
                    .ForMember(
                        dest => dest.OrderDateStr,
                        opt => opt.MapFrom(src => src.OrderDate.ToLongDateString()))
                    .ForMember(
                        dest => dest.ShippedDateStr,
                        opt => opt.MapFrom(src => src.ShippedDate != null ? ((DateTime)src.ShippedDate).ToLongDateString() : null));
                x.CreateMap<OrderDTO, Order>();

                x.CreateMap<OrderDetail, OrderDetailDTO>()
                    .ForMember(
                        dest => dest.Order,
                        opt => opt.Ignore());
                x.CreateMap<OrderDetailDTO, OrderDetail>();

            });
        }
    }
}