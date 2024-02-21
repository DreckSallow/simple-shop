using backend.Services;
using backend.Models;

namespace backend.Data;

public static class DbSeed
{
    public static void Init(ApplicationContext appContext)
    {
        if (
            appContext.Users.Any() &&
            appContext.Products.Any() &&
            appContext.Brands.Any() &&
            appContext.Categories.Any()
        )
        {
            return;
        }
        Console.WriteLine(">>>> Seed the DB");


        var HouseCategory = new Category()
        {
            Name = "house"
        };
        var HouseBrands = new[]{
          new Brand(){Name="smart"} ,
          new Brand(){Name="mostaf"} ,
        };
        var HouseProducts = new[]{
            new Product
            {
                Brand=HouseBrands[0],
                Category=HouseCategory,
                Name = "Smart Thermostat",
                Price = 99.99m,
                Description = "Energy-efficient smart thermostat for home climate control.",
                Discount = 8
            },
            new Product
            {
                Brand=HouseBrands[0],
                Category=HouseCategory,
                Name = "Robot Vacuum Cleaner",
                Price = 199.99m,
                Description = "Automated vacuum cleaner with smart navigation technology.",
                Discount = 15
            },
            new Product
            {
                Brand= HouseBrands[1],
                Category=HouseCategory,
                Name = "Cookware Set",
                Price = 79.99m,
                Description = "High-quality non-stick cookware set for the kitchen.",
                Discount = 10
            },
            new Product
            {
                Brand= HouseBrands[1],
                Category=HouseCategory,
                Name = "Memory Foam Mattress",
                Price = 499.99m,
                Description = "Comfortable memory foam mattress for a good night's sleep.",
                Discount = 5
            },
            new Product
            {
                Brand= HouseBrands[0],
                Category=HouseCategory,
                Name = "Home Security Camera System",
                Price = 149.99m,
                Description = "Surveillance camera system for enhanced home security.",
                Discount = 12
            },
        };

        var PhonesCategory = new Category()
        {
            Name = "phones"
        };
        var PhoneBrands = new[]{
          new Brand(){Name="galaxi"} ,
          new Brand(){Name="google"} ,
        };

        var PhonesProducts = new[]{
            new Product
            {
                Brand= PhoneBrands[0],
                Category=PhonesCategory,
                Name = "iPhone 13",
                Price = 999.99m,
                Description = "The latest iPhone with advanced features.",
                Discount = 10
            },
            new Product
            {
                Brand= PhoneBrands[0],
                Category=PhonesCategory,
                Name = "Samsung Galaxy S21",
                Price = 899.99m,
                Description = "Powerful Android phone with stunning display.",
                Discount = 5
            },
            new Product
            {
                Brand= PhoneBrands[1],
                Category=PhonesCategory,
                Name = "Google Pixel 6",
                Price = 799.99m,
                Description = "Top-notch camera and pure Android experience.",
                Discount = 8
            },
            new Product
            {
                Brand= PhoneBrands[1],
                Category=PhonesCategory,
                Name = "OnePlus 9",
                Price = 749.99m,
                Description = "Flagship killer with fast performance.",
                Discount = 12
            },
        };

        var ClothingCategory = new Category()
        {
            Name = "clothing",
        };
        var ClothingBrands = new[] { new Brand { Name = "gucci" }, new Brand { Name = "lana" } };
        var ClothingProducts = new[]{
            new Product
            {
                Brand= ClothingBrands[0],
                Category=ClothingCategory,
                Name = "Men's Denim Jeans",
                Price = 49.99m,
                Description = "Classic blue denim jeans for men.",
                Discount = 15
            },
            new Product
            {
                Brand= ClothingBrands[0],
                Category=ClothingCategory,
                Name = "Women's Leather Jacket",
                Price = 129.99m,
                Description = "Stylish black leather jacket for women.",
                Discount = 10
            },
            new Product
            {
                Brand= ClothingBrands[0],
                Category=ClothingCategory,
                Name = "Sports Hoodie",
                Price = 34.99m,
                Description = "Comfortable hoodie for sports enthusiasts.",
                Discount = 20
            },
            new Product
            {
                Brand= ClothingBrands[1],
                Category=ClothingCategory,
                Name = "Formal Dress Shirt",
                Price = 39.99m,
                Description = "Crisp white dress shirt for formal occasions.",
                Discount = 5
            },
            new Product
            {
                Brand= ClothingBrands[1],
                Category=ClothingCategory,
                Name = "Running Shoes",
                Price = 59.99m,
                Description = "Lightweight running shoes for active lifestyles.",
                Discount = 12
            }
        };

        appContext.Categories.AddRange(HouseCategory, PhonesCategory, ClothingCategory);
        Brand[] brands = HouseBrands.Concat(PhoneBrands).Concat(ClothingBrands).ToArray();
        foreach (Brand brand in brands)
        {
            appContext.Brands.Add(brand);
        }
        Product[] productsList = HouseProducts.Concat(PhonesProducts).Concat(ClothingProducts).ToArray();
        foreach (Product product in productsList)
        {
            appContext.Products.Add(product);
        }
        appContext.Users.Add(new User()
        {
            FirstName = "Dikson",
            LastName = "Aranda",
            Email = "dikson@test.com",
            Password = new UserPasswordHasher().Hash("dikson-4076"),
            Role = UserRole.Admin,
        });
        appContext.SaveChanges();
    }
}
