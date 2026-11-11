

namespace Q1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ElectronicsProduct laptop = new ElectronicsProduct(
                1, "Laptop Pro", 1200, "Dell", 24);

            ElectronicsProduct headphones = new ElectronicsProduct(
                2, "Wireless Headphones", 150, "Sony", 12);

            ElectronicsProduct smartWatch = new ElectronicsProduct(
                3, "Smart Watch", 299.99, "Garmin", 12);

            DiscountManager manager = new DiscountManager(PrintDiscount);

            manager.AddProduct(laptop);
            manager.AddProduct(headphones);
            manager.AddProduct(smartWatch);

            manager.ApplyDiscountToProduct(1, 10);
            manager.ApplyDiscountToProduct(2, 15);
            manager.ApplyDiscountToProduct(3, 20);

            try
            {
                manager.ApplyDiscountToProduct(1, 150);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n=== Products Under 500.0 ===");

            List<ElectronicsProduct> products = manager.GetProductsUnder(500.0);

            int index = 1;
            foreach (ElectronicsProduct product in products)
            {
                Console.WriteLine(
                    $"{index}. {product.Name} | Brand: {product.Brand} | " +
                    $"Price: {product.Price:F2} | Category: {product.GetCategory()}");

                index++;
            }
        }

        public static void PrintDiscount(string productName, double discountPercent)
        {
            Console.WriteLine($"[DISCOUNT]: {productName} received {discountPercent:F1}% discount");
        }
    }
}
