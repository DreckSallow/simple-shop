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


        var houseCategory = new Category
        {
            Name = "house",
            Products = new Product[]{
            new Product
            {
                Brand= new Brand(){Name="smart"},
                Name = "Smart Thermostat",
                Price = 99.99m,
                Description = "Energy-efficient smart thermostat for home climate control.",
                Discount = 8
            },
            new Product
            {
                Brand= new Brand(){Name="smart"},
                Name = "Robot Vacuum Cleaner",
                Price = 199.99m,
                Description = "Automated vacuum cleaner with smart navigation technology.",
                Discount = 15
            },
            new Product
            {
                Brand= new Brand(){Name="mostaf"},
                Name = "Cookware Set",
                Price = 79.99m,
                Description = "High-quality non-stick cookware set for the kitchen.",
                Discount = 10
            },
            new Product
            {
                Brand= new Brand(){Name="mostaf"},
                Name = "Memory Foam Mattress",
                Price = 499.99m,
                Description = "Comfortable memory foam mattress for a good night's sleep.",
                Discount = 5
            },
            new Product
            {
                Brand= new Brand(){Name="mostaf"},
                Name = "Home Security Camera System",
                Price = 149.99m,
                Description = "Surveillance camera system for enhanced home security.",
                Discount = 12
            },
            },
        };

        var phonesCategory = new Category
        {
            Name = "phones",
            Products = new Product[]{
            new Product
            {
                Brand= new Brand(){Name="galaxi"},
                Name = "iPhone 13",
                Price = 999.99m,
                Description = "The latest iPhone with advanced features.",
                Discount = 10
            },
            new Product
            {
                Brand= new Brand(){Name="galaxi"},
                Name = "Samsung Galaxy S21",
                Price = 899.99m,
                Description = "Powerful Android phone with stunning display.",
                Discount = 5
            },
            new Product
            {
                Brand= new Brand(){Name="google"},
                Name = "Google Pixel 6",
                Price = 799.99m,
                Description = "Top-notch camera and pure Android experience.",
                Discount = 8
            },
            new Product
            {
                Brand= new Brand(){Name="google"},
                Name = "OnePlus 9",
                Price = 749.99m,
                Description = "Flagship killer with fast performance.",
                Discount = 12
            },
            new Product
            {
                Brand= new Brand(){Name="xiaomi"},
                Name = "Xiaomi Mi 11",
                Price = 699.99m,
                Description = "Affordable yet powerful smartphone.",
                Discount = 15
            }            },
        };
        var clothingCategory = new Category
        {
            Name = "clothing",
            Products = new Product[]{
            new Product
            {
                Brand= new Brand(){Name="gucci"},
                Name = "Men's Denim Jeans",
                Price = 49.99m,
                Description = "Classic blue denim jeans for men.",
                Discount = 15
            },
            new Product
            {
                Brand= new Brand(){Name="gucci"},
                Name = "Women's Leather Jacket",
                Price = 129.99m,
                Description = "Stylish black leather jacket for women.",
                Discount = 10
            },
            new Product
            {
                Brand= new Brand(){Name="gucci"},
                Name = "Sports Hoodie",
                Price = 34.99m,
                Description = "Comfortable hoodie for sports enthusiasts.",
                Discount = 20
            },
            new Product
            {
                Brand= new Brand(){Name="prada"},
                Name = "Formal Dress Shirt",
                Price = 39.99m,
                Description = "Crisp white dress shirt for formal occasions.",
                Discount = 5
            },
            new Product
            {
                Brand= new Brand(){Name="prada"},
                Name = "Running Shoes",
                Price = 59.99m,
                Description = "Lightweight running shoes for active lifestyles.",
                Discount = 12
            }

                  },
        };
        appContext.Categories.AddRange(houseCategory, phonesCategory, clothingCategory);
        appContext.Users.Add(new User()
        {
            FirstName = "Dikson",
            LastName = "Aranda",
            Email = "dikson@test.com",
            Password = "dikson-4076",
            Role = UserRole.Admin,
        });
        appContext.SaveChanges();
    }
}
