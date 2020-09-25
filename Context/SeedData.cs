using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FarmFresh.Models;
using System;
using System.Linq;

namespace FarmFresh.Context
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FarmFreshContext(serviceProvider.GetRequiredService<DbContextOptions<FarmFreshContext>>()))
            {
                // Look for any data.

                #region  Unit
                if (!context.Unit.Any())
                {
                   context.Unit.AddRange(
                    new Unit
                    {
                        Name = "Packet",
                        Description ="-",
                        IsDelete =false,
                        CreatedBy =1,// just in case 1 for created user id.
                        CreatedDate = DateTime.Now
                    },
                    new Unit
                    {
                        Name = "Each",
                        Description ="-",
                        IsDelete =false,
                        CreatedBy =1,
                        CreatedDate = DateTime.Now
                    }
                );
                context.SaveChanges();
                }
                #endregion

                #region  Category
                if (!context.Category.Any())
                {
                    context.Category.AddRange(
                    new Category
                    {
                        Name = "On Sale!",
                        Description ="-",
                        IsDelete =false,
                        CreatedBy =1,
                        CreatedDate = DateTime.Now
                    },
                    new Category
                    {
                        Name = "Shop By Store",
                        Description ="-",
                        IsDelete =false,
                        CreatedBy =1,
                        CreatedDate = DateTime.Now
                    },
                    new Category
                    {
                        Name = "Fruit & Veg",
                        Description ="-",
                        IsDelete =false,
                        CreatedBy =1,
                        CreatedDate = DateTime.Now
                    },
                    new Category
                    {
                        Name = "Meat & Seafood",
                        Description ="-",
                        IsDelete =false,
                        CreatedBy =1,
                        CreatedDate = DateTime.Now
                    },
                    new Category
                    {
                        Name = "Dairy and Chilled",
                        Description ="-",
                        IsDelete =false,
                        CreatedBy =1,
                        CreatedDate = DateTime.Now
                    },
                    new Category
                    {
                        Name = "Bakery",
                        Description ="-",
                        IsDelete =false,
                        CreatedBy =1,
                        CreatedDate = DateTime.Now
                    },
                    new Category
                    {
                        Name = "Beverages",
                        Description ="-",
                        IsDelete =false,
                        CreatedBy =1,
                        CreatedDate = DateTime.Now
                    }
                );
                context.SaveChanges();
                }
                #endregion

                #region  Product
                if (!context.Product.Any())
                {
                    //seed data for all category and unit
                int categoryCount=context.Category.Count();
                int unitCount=context.Unit.Count();
                for(int i=1;i<=unitCount;i++)
                {
                    for(int j=1;j<=categoryCount;j++)
                    {
                        context.Product.AddRange(
                        new Product
                        {
                            Name = "Ripe Blue Grape",
                            ProductUrl="images/product/1.png",
                            Description ="-",
                            CategoryId=j,
                            UnitId=i,
                            IsDelete =false,
                            CreatedBy =1,// just in case 1 for created user id.
                            CreatedDate = DateTime.Now
                        },
                        new Product
                        {
                            Name = "Spinach",
                             ProductUrl=$"images/product/2.png",
                            Description ="-",
                            CategoryId=j,
                            UnitId=i,
                            IsDelete =false,
                            CreatedBy =1,// just in case 1 for created user id.
                            CreatedDate = DateTime.Now
                        },
                        new Product
                        {
                            Name = "Salmon",
                             ProductUrl="images/product/3.png",
                            Description ="-",
                            CategoryId=j,
                            UnitId=i,
                            IsDelete =false,
                            CreatedBy =1,// just in case 1 for created user id.
                            CreatedDate = DateTime.Now
                        },
                        new Product
                        {
                            Name = "Capsicum",
                            ProductUrl="images/product/4.png",
                            Description ="-",
                            CategoryId=j,
                            UnitId=i,
                            IsDelete =false,
                            CreatedBy =1,// just in case 1 for created user id.
                            CreatedDate = DateTime.Now
                        },
                        new Product
                        {
                            Name = "Tomato",
                             ProductUrl="images/product/5.png",
                            Description ="-",
                            CategoryId=j,
                            UnitId=i,
                            IsDelete =false,
                            CreatedBy =1,// just in case 1 for created user id.
                            CreatedDate = DateTime.Now
                        },
                        new Product
                        {
                            Name = "Brocolli",
                             ProductUrl="images/product/6.png",
                            Description ="-",
                            CategoryId=j,
                            UnitId=i,
                            IsDelete =false,
                            CreatedBy =1,// just in case 1 for created user id.
                            CreatedDate = DateTime.Now
                        }
                    );
                    context.SaveChanges();
                    }
                }
                }
                #endregion
            }
        }
    }
}