using Microsoft.Extensions.Logging;
using saaz.Catalog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace saaz.Catalog.Data
{
    public class CatalogDbContextSeed
    {
        public static async Task SeedAsync(CatalogDbContext dbContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!dbContext.CatalogBrands.Any())
                {
                    dbContext.CatalogBrands.AddRange(GetCatalogBrands());
                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.CatalogTypes.Any())
                {
                    dbContext.CatalogTypes.AddRange(GetCatalogTypes());
                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.CatalogCategories.Any())
                {
                    dbContext.CatalogCategories.AddRange(GetCatalogCategories());
                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.CatalogSubCategories.Any())
                {
                    dbContext.CatalogSubCategories.AddRange(GetCatalogSubCategories());
                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.CatalogItems.Any())
                {
                    dbContext.CatalogItems.AddRange(GetCatalogItems());
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CatalogDbContextSeed>();
                    log.LogError(ex.Message);

                    //retry seeding
                    await SeedAsync(dbContext, loggerFactory, retryForAvailability);
                }
            }
        }

        #region private seed-methods

        static IEnumerable<CatalogBrand> GetCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand { Id = 1, BrandName = "Nazzan" },
                new CatalogBrand { Id = 2, BrandName = "Organix" },
                new CatalogBrand { Id = 3, BrandName = "NuFarms" },
                new CatalogBrand { Id = 4, BrandName = "NikNaks" },
                new CatalogBrand { Id = 5, BrandName = "Zesty" }
            };
        }

        static IEnumerable<CatalogType> GetCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType { Id = 1, TypeName = "Organic" },
                new CatalogType { Id = 2, TypeName = "Fresh" },
                new CatalogType { Id = 3, TypeName = "Frozen" },
                new CatalogType { Id = 4, TypeName = "Exotic/Gourmet" },
                new CatalogType { Id = 5, TypeName = "HealthPro" }
            };
        }

        static IEnumerable<CatalogCategory> GetCatalogCategories()
        {
            return new List<CatalogCategory>()
            {
                new CatalogCategory { Id = 1, CategoryName = "Fruits & Vegetables" },
                new CatalogCategory { Id = 2, CategoryName = "Meat, Seafood & Eggs" },
                new CatalogCategory { Id = 3, CategoryName = "Grocery & Staples" },
                new CatalogCategory { Id = 4, CategoryName = "Snacks & Beverages" },
                new CatalogCategory { Id = 5, CategoryName = "Bakery & Dairy" }
            };
        }

        static IEnumerable<CatalogSubCategory> GetCatalogSubCategories()
        {
            return new List<CatalogSubCategory>()
            {
                new CatalogSubCategory { Id = 1, CategoryId = 1, SubCategoryName = "Fruits" },
                new CatalogSubCategory { Id = 2, CategoryId = 1, SubCategoryName = "Vegetables" },
                new CatalogSubCategory { Id = 3, CategoryId = 1, SubCategoryName = "Herbs" },

                new CatalogSubCategory { Id = 4, CategoryId = 2, SubCategoryName = "Poultry" },
                new CatalogSubCategory { Id = 5, CategoryId = 2, SubCategoryName = "Lamb & Mutton" },
                new CatalogSubCategory { Id = 6, CategoryId = 2, SubCategoryName = "Fish & Other Seafood" },
                new CatalogSubCategory { Id = 7, CategoryId = 2, SubCategoryName = "Marinades" },

                new CatalogSubCategory { Id = 8, CategoryId = 3, SubCategoryName = "Flours, Grains & Pulses" },
                new CatalogSubCategory { Id = 9, CategoryId = 3, SubCategoryName = "Noodles, Pasta & Vermicelli" },
                new CatalogSubCategory { Id = 10, CategoryId = 3, SubCategoryName = "Sugar, Salt & Spices" },
                new CatalogSubCategory { Id = 11, CategoryId = 3, SubCategoryName = "Oils" },

                new CatalogSubCategory { Id = 12, CategoryId = 4, SubCategoryName = "Biscuits & Cookies" },
                new CatalogSubCategory { Id = 13, CategoryId = 4, SubCategoryName = "Chocolates & Candies" },
                new CatalogSubCategory { Id = 14, CategoryId = 4, SubCategoryName = "Tea & Coffee" },
                new CatalogSubCategory { Id = 15, CategoryId = 4, SubCategoryName = "Fruit Juices & Soft Drinks" },
                new CatalogSubCategory { Id = 16, CategoryId = 4, SubCategoryName = "Health Drinks & Supplements" },

                new CatalogSubCategory { Id = 17, CategoryId = 5, SubCategoryName = "Milk & Yogurt" },
                new CatalogSubCategory { Id = 18, CategoryId = 5, SubCategoryName = "Butter & Cheese" },
                new CatalogSubCategory { Id = 19, CategoryId = 5, SubCategoryName = "Breads, Cakes & Pastries" },
                new CatalogSubCategory { Id = 20, CategoryId = 5, SubCategoryName = "Ice Creams & Desserts" }
            };
        }

        static IEnumerable<CatalogItem> GetCatalogItems()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem { Id = 1, BrandId = 2, TypeId = 1, CategoryId = 1, SubCategoryId = 1, ItemName = "Apple", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 2, BrandId = 2, TypeId = 1, CategoryId = 1, SubCategoryId = 1, ItemName = "Orange", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 3, BrandId = 3, TypeId = 2, CategoryId = 1, SubCategoryId = 1, ItemName = "Banana", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 4, BrandId = 3, TypeId = 2, CategoryId = 1, SubCategoryId = 1, ItemName = "Mango", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 5, BrandId = 3, TypeId = 2, CategoryId = 1, SubCategoryId = 1, ItemName = "Pear", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 6, BrandId = 3, TypeId = 2, CategoryId = 1, SubCategoryId = 2, ItemName = "Potato", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 7, BrandId = 3, TypeId = 2, CategoryId = 1, SubCategoryId = 2, ItemName = "Onion", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 8, BrandId = 3, TypeId = 2, CategoryId = 1, SubCategoryId = 2, ItemName = "Tomato", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 9, BrandId = 2, TypeId = 1, CategoryId = 1, SubCategoryId = 2, ItemName = "Carrot", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 10, BrandId = 2, TypeId = 1, CategoryId = 1, SubCategoryId = 2, ItemName = "Radish", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 11, BrandId = 3, TypeId = 2, CategoryId = 1, SubCategoryId = 2, ItemName = "Brinjal", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 12, BrandId = 3, TypeId = 2, CategoryId = 1, SubCategoryId = 2, ItemName = "Cabbage", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 13, BrandId = 3, TypeId = 2, CategoryId = 1, SubCategoryId = 2, ItemName = "Cucumber", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 14, BrandId = 2, TypeId = 1, CategoryId = 1, SubCategoryId = 3, ItemName = "Coriander", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 15, BrandId = 2, TypeId = 1, CategoryId = 1, SubCategoryId = 3, ItemName = "Mint", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 16, BrandId = 5, TypeId = 2, CategoryId = 2, SubCategoryId = 4, ItemName = "Chicken (Whole)", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 17, BrandId = 2, TypeId = 1, CategoryId = 2, SubCategoryId = 4, ItemName = "Chicken (Boneless)", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 18, BrandId = 5, TypeId = 2, CategoryId = 2, SubCategoryId = 4, ItemName = "Chicken (Curry)", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 19, BrandId = 5, TypeId = 2, CategoryId = 2, SubCategoryId = 4, ItemName = "Eggs (Regular)", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 20, BrandId = 2, TypeId = 1, CategoryId = 2, SubCategoryId = 4, ItemName = "Eggs (Brown)", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 21, BrandId = 5, TypeId = 4, CategoryId = 2, SubCategoryId = 5, ItemName = "Mutton (Chops)", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 22, BrandId = 5, TypeId = 3, CategoryId = 2, SubCategoryId = 5, ItemName = "Mutton (Mince)", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 23, BrandId = 5, TypeId = 2, CategoryId = 2, SubCategoryId = 5, ItemName = "Mutton (Curry)", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 24, BrandId = 5, TypeId = 4, CategoryId = 2, SubCategoryId = 5, ItemName = "Lamb (Chops)", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 25, BrandId = 5, TypeId = 4, CategoryId = 2, SubCategoryId = 5, ItemName = "Lamb (Steak)", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 26, BrandId = 5, TypeId = 2, CategoryId = 2, SubCategoryId = 6, ItemName = "Rohu", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 27, BrandId = 5, TypeId = 2, CategoryId = 2, SubCategoryId = 6, ItemName = "Catla", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 28, BrandId = 5, TypeId = 4, CategoryId = 2, SubCategoryId = 6, ItemName = "Salmon", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 29, BrandId = 5, TypeId = 3, CategoryId = 2, SubCategoryId = 6, ItemName = "Prawns", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 30, BrandId = 5, TypeId = 3, CategoryId = 2, SubCategoryId = 6, ItemName = "Crab", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 31, BrandId = 5, TypeId = 3, CategoryId = 2, SubCategoryId = 7, ItemName = "Chicken Tandoor", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 32, BrandId = 5, TypeId = 3, CategoryId = 2, SubCategoryId = 7, ItemName = "Schezuan Chicken", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 33, BrandId = 5, TypeId = 3, CategoryId = 2, SubCategoryId = 7, ItemName = "Greek Goat Chops", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 34, BrandId = 5, TypeId = 3, CategoryId = 2, SubCategoryId = 7, ItemName = "Lemon Pepper Fish", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 35, BrandId = 5, TypeId = 3, CategoryId = 2, SubCategoryId = 7, ItemName = "Mediterranean Prawns", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 36, BrandId = 3, TypeId = 2, CategoryId = 3, SubCategoryId = 8, ItemName = "Aata", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 37, BrandId = 3, TypeId = 2, CategoryId = 3, SubCategoryId = 8, ItemName = "Sooji", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 38, BrandId = 3, TypeId = 2, CategoryId = 3, SubCategoryId = 8, ItemName = "Basmati Rice", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 39, BrandId = 3, TypeId = 2, CategoryId = 3, SubCategoryId = 8, ItemName = "Sona Masoori Rice", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 40, BrandId = 3, TypeId = 2, CategoryId = 3, SubCategoryId = 8, ItemName = "Chana Dal", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 41, BrandId = 3, TypeId = 2, CategoryId = 3, SubCategoryId = 8, ItemName = "Toor Dal", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 42, BrandId = 1, TypeId = 2, CategoryId = 3, SubCategoryId = 9, ItemName = "Hakka Noodles", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 43, BrandId = 1, TypeId = 4, CategoryId = 3, SubCategoryId = 9, ItemName = "Rice Noodles", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 44, BrandId = 1, TypeId = 4, CategoryId = 3, SubCategoryId = 9, ItemName = "Spaghetti", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 45, BrandId = 1, TypeId = 4, CategoryId = 3, SubCategoryId = 9, ItemName = "Macaroni", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 46, BrandId = 3, TypeId = 2, CategoryId = 3, SubCategoryId = 10, ItemName = "Sugar", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 47, BrandId = 3, TypeId = 2, CategoryId = 3, SubCategoryId = 10, ItemName = "Salt", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 48, BrandId = 3, TypeId = 2, CategoryId = 3, SubCategoryId = 10, ItemName = "Chilli Powder", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 49, BrandId = 3, TypeId = 2, CategoryId = 3, SubCategoryId = 10, ItemName = "Cumin Powder", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 50, BrandId = 3, TypeId = 2, CategoryId = 3, SubCategoryId = 10, ItemName = "Turmeric Powder", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 51, BrandId = 3, TypeId = 2, CategoryId = 3, SubCategoryId = 10, ItemName = "Garam Masala", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 52, BrandId = 3, TypeId = 2, CategoryId = 3, SubCategoryId = 11, ItemName = "Sunflower Oil", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 53, BrandId = 3, TypeId = 2, CategoryId = 3, SubCategoryId = 11, ItemName = "Mustard Oil", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 54, BrandId = 3, TypeId = 2, CategoryId = 3, SubCategoryId = 11, ItemName = "Canola Oil", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 55, BrandId = 1, TypeId = 4, CategoryId = 3, SubCategoryId = 11, ItemName = "Olive Oil", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 56, BrandId = 2, TypeId = 1, CategoryId = 4, SubCategoryId = 11, ItemName = "Cow Ghee", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 57, BrandId = 4, TypeId = 2, CategoryId = 4, SubCategoryId = 12, ItemName = "Oreo", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 58, BrandId = 4, TypeId = 2, CategoryId = 4, SubCategoryId = 12, ItemName = "Marie", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 59, BrandId = 4, TypeId = 2, CategoryId = 4, SubCategoryId = 12, ItemName = "Bourbon", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 60, BrandId = 4, TypeId = 2, CategoryId = 4, SubCategoryId = 12, ItemName = "Little Hearts", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 61, BrandId = 4, TypeId = 5, CategoryId = 4, SubCategoryId = 12, ItemName = "Nutri Choice", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 62, BrandId = 4, TypeId = 2, CategoryId = 4, SubCategoryId = 13, ItemName = "Gems", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 63, BrandId = 4, TypeId = 2, CategoryId = 4, SubCategoryId = 13, ItemName = "KitKat", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 64, BrandId = 4, TypeId = 2, CategoryId = 4, SubCategoryId = 13, ItemName = "Munch", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 65, BrandId = 4, TypeId = 2, CategoryId = 4, SubCategoryId = 13, ItemName = "Dairy Milk", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 66, BrandId = 3, TypeId = 2, CategoryId = 4, SubCategoryId = 14, ItemName = "Tea", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 67, BrandId = 1, TypeId = 5, CategoryId = 4, SubCategoryId = 14, ItemName = "Green Tea", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 68, BrandId = 1, TypeId = 5, CategoryId = 4, SubCategoryId = 14, ItemName = "Herbal Tea", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 69, BrandId = 3, TypeId = 2, CategoryId = 4, SubCategoryId = 14, ItemName = "Coffee", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 70, BrandId = 3, TypeId = 2, CategoryId = 4, SubCategoryId = 14, ItemName = "Filter Coffee", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 71, BrandId = 1, TypeId = 2, CategoryId = 4, SubCategoryId = 15, ItemName = "Orange Juice", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 72, BrandId = 1, TypeId = 2, CategoryId = 4, SubCategoryId = 15, ItemName = "Pineapple Juice", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 73, BrandId = 1, TypeId = 2, CategoryId = 4, SubCategoryId = 15, ItemName = "Mixed Fruit Juice", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 74, BrandId = 1, TypeId = 2, CategoryId = 4, SubCategoryId = 15, ItemName = "Limca", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 75, BrandId = 1, TypeId = 2, CategoryId = 4, SubCategoryId = 15, ItemName = "ThumsUp", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 76, BrandId = 1, TypeId = 2, CategoryId = 4, SubCategoryId = 16, ItemName = "Horlicks", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 77, BrandId = 1, TypeId = 2, CategoryId = 4, SubCategoryId = 16, ItemName = "Complan", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 78, BrandId = 1, TypeId = 2, CategoryId = 4, SubCategoryId = 16, ItemName = "Bournvita", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 79, BrandId = 1, TypeId = 5, CategoryId = 4, SubCategoryId = 16, ItemName = "Protinex", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 80, BrandId = 1, TypeId = 4, CategoryId = 4, SubCategoryId = 16, ItemName = "Gatorade", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 81, BrandId = 3, TypeId = 2, CategoryId = 5, SubCategoryId = 17, ItemName = "Milk", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 82, BrandId = 3, TypeId = 2, CategoryId = 5, SubCategoryId = 17, ItemName = "Dahi", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 83, BrandId = 3, TypeId = 4, CategoryId = 5, SubCategoryId = 17, ItemName = "Almond Milk", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 84, BrandId = 3, TypeId = 4, CategoryId = 5, SubCategoryId = 17, ItemName = "Greek Yogurt", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 85, BrandId = 3, TypeId = 2, CategoryId = 5, SubCategoryId = 17, ItemName = "Fresh Cream", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 86, BrandId = 3, TypeId = 2, CategoryId = 5, SubCategoryId = 18, ItemName = "Butter (Plain)", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 87, BrandId = 3, TypeId = 2, CategoryId = 5, SubCategoryId = 18, ItemName = "Butter (Salted)", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 88, BrandId = 3, TypeId = 4, CategoryId = 5, SubCategoryId = 18, ItemName = "Peanut Butter", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 89, BrandId = 3, TypeId = 4, CategoryId = 5, SubCategoryId = 18, ItemName = "Mozarella", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 90, BrandId = 3, TypeId = 4, CategoryId = 5, SubCategoryId = 18, ItemName = "Cheddar", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 91, BrandId = 4, TypeId = 2, CategoryId = 5, SubCategoryId = 19, ItemName = "Milk Bread", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 92, BrandId = 4, TypeId = 2, CategoryId = 5, SubCategoryId = 19, ItemName = "Brown Bread", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 93, BrandId = 4, TypeId = 2, CategoryId = 5, SubCategoryId = 19, ItemName = "Coffee Cake", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 94, BrandId = 4, TypeId = 2, CategoryId = 5, SubCategoryId = 19, ItemName = "Fruit Cake", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 95, BrandId = 4, TypeId = 4, CategoryId = 5, SubCategoryId = 19, ItemName = "Croissant", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 96, BrandId = 1, TypeId = 3, CategoryId = 5, SubCategoryId = 20, ItemName = "Vanilla IceCream", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 97, BrandId = 1, TypeId = 3, CategoryId = 5, SubCategoryId = 20, ItemName = "Strawberry IceCream", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 98, BrandId = 1, TypeId = 3, CategoryId = 5, SubCategoryId = 20, ItemName = "Malai Kulfi IceCream", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 99, BrandId = 1, TypeId = 2, CategoryId = 5, SubCategoryId = 20, ItemName = "Gulab Jamun", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 },
                new CatalogItem { Id = 100, BrandId = 1, TypeId = 2, CategoryId = 5, SubCategoryId = 20, ItemName = "Shrikhand", ItemDesc = null, PictureUri = null, PictureFileName = null, Price = 0, AvailableStock = 50, RestockThreshold = 5, MaxStockThreshold = 100 }
            };
        }

        #endregion
    }
}
