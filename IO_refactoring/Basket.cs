namespace IO_refactoring
{
    internal class Basket
    {
        public Product[] products = new Product[3];
        public float ProductsPrice { get; set; }
        public int ProductsWeight => products.Sum(p => p.Weight);
        public float BaseProductsPrice => products.Sum(p => p.Price);
        public float ProductsPriceAfterDiscount { get; set; }
        public float ProductsPriceAfterRoleDiscount { get; set; }
        public float ProductsPriceByWeight { get; set; }
        public float ProductsPriceWithExtraCosts { get; set; }
        public float ProductsPriceWithMargin { get; set; }

        public float CalcBasketSum(int extraCosts = 0, int margin = 0, bool productPriceDependsOnWeight = true, UserRoles role = UserRoles.Regular)
        {
            ProductsPrice = products[0].Price < float.Epsilon ? float.Epsilon : BaseProductsPrice;
            CountDiscount(role);
            ProductsPrice = productPriceDependsOnWeight ? CountPriceByWeight() : ProductsPrice;
            ProductsPriceWithExtraCosts = ProductsPrice += extraCosts;
            ProductsPriceWithMargin = ProductsPrice += margin;
            if (margin > 100) Console.WriteLine("Brawo, podwyżka się należy!");

            return ProductsPrice;
        }

        public void CountDiscount(UserRoles role)
        {
            switch (ProductsPrice)
            {
                case > 5000:
                    ProductsPriceAfterDiscount = (float)(0.7f * ProductsPrice);
                    break;
                case > 1000:
                    ProductsPriceAfterDiscount = (float)(0.8f * ProductsPrice);
                    break;
                case > 500:
                    ProductsPriceAfterDiscount = (float)(0.85f * ProductsPrice);
                    break;
                case > 100:
                    ProductsPriceAfterDiscount = (float)(0.9f * ProductsPrice);
                    break;
            }
            ProductsPrice = ProductsPriceAfterRoleDiscount = ((role == UserRoles.VIP) || (role == UserRoles.Admin)) ? (int)(0.9f * ProductsPriceAfterDiscount) : ProductsPriceAfterDiscount;
        }
        public float CountPriceByWeight()
        {
            return ProductsPrice = ProductsPriceByWeight = ProductsWeight >= 1000 ?
                products.All(p => p.Category.Equals(ProductCategory.Fruit)) ? ProductsPrice + 45
                : products.All(p => p.Category.Equals(ProductCategory.Vegetable)) ? ProductsPrice + 35 : ProductsPrice + 25
                : ProductsWeight >= 500 ? ProductsPrice + 15
                : ProductsWeight >= 100 ? ProductsPrice + 10
                : ProductsWeight >= 50 ? ProductsPrice + 5
                : ProductsWeight >= 15 ? ProductsPrice + 2 : ProductsPrice;
        }
    }
}
