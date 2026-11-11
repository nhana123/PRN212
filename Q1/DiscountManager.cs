using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class DiscountManager
    {
        private List<ElectronicsProduct> _products; 
        private DiscountAppliedCallback _onDiscountApplied;

        public DiscountManager(DiscountAppliedCallback callback)
        {
            _products = new List<ElectronicsProduct>();
            _onDiscountApplied = callback;
        }

        public void AddProduct(ElectronicsProduct product) { 
           _products.Add(product);
        }
        public void ApplyDiscountToProduct(int productId, double percent) { 
        ElectronicsProduct? product = _products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                throw new InvalidOperationException($"Product not found: {productId}");
            }
            product.ApplyDiscount(percent);
            _onDiscountApplied(product.Name, percent);
        }
        public List<ElectronicsProduct> GetProductsUnder(double maxPrice)
        {
            return _products
                   .Where(product => product.Price < maxPrice)
                   .OrderBy(product => product.Price)
                   .ToList();
        }
    }
}
