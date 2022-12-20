namespace IO_refactoring
{
    internal class Basket
    {
        internal Product[]? Products { get; set; }
        internal virtual User? Owner { get; set; }
        private float ProductsPrice { get; set; }
        private int ProductsWeight => Products.Sum(p => p.Weight);
        private float BaseProductsPrice => Products.Sum(p => p.Price);
        private float ProductsPriceAfterDiscount { get; set; }
        private float ProductsPriceAfterRoleDiscount { get; set; }
        private float ProductsPriceByWeight { get; set; }
        private float ProductsPriceWithExtraCosts { get; set; }
        private float ProductsPriceWithMargin { get; set; }

        public void DisplayBasket(int extraCosts = 0, int margin = 0, bool productPriceDependsOnWeight = true)
        {
            Console.WriteLine($"Koszyk użytkownika {Owner.FirstName} {Owner.LastName} ({Owner.Role})");
            CalcBasketSum(extraCosts, margin, productPriceDependsOnWeight);
            Console.WriteLine($"Cena produktów: {String.Format("{0:0.00}", BaseProductsPrice)}");
            Console.WriteLine($"Cena produktów po zniżce: {String.Format("{0:0.00}", ProductsPriceAfterDiscount)}");
            Console.WriteLine($"Cena produktów dla grupy użytkownika: {String.Format("{0:0.00}", ProductsPriceAfterRoleDiscount)}");
            Console.WriteLine($"Waga produktów: {ProductsWeight}");
            Console.WriteLine($"Cena produktów zgodnie z wagą: {String.Format("{0:0.00}", ProductsPriceByWeight)}");
            Console.WriteLine($"Cena produktów + dodatkowe koszty: {String.Format("{0:0.00}", ProductsPriceWithExtraCosts)}");
            Console.WriteLine($"Cena produktów + marża: {String.Format("{0:0.00}", ProductsPriceWithMargin)}\n");
            if (margin > 100) Console.WriteLine("Brawo, podwyżka się należy!");
        }

        public void CalcBasketSum(int extraCosts = 0, int margin = 0, bool productPriceDependsOnWeight = true)
        {
            ProductsPrice = Products[0].Price < float.Epsilon ? float.Epsilon : BaseProductsPrice;
            CountDiscount();
            ProductsPrice = ProductsPriceAfterRoleDiscount =
                ((Owner.Role == UserRoles.VIP) || (Owner.Role == UserRoles.Admin)) ? (int)(0.9f * ProductsPriceAfterDiscount) : ProductsPriceAfterDiscount;
            ProductsPrice = productPriceDependsOnWeight ? CountPriceByWeight() : ProductsPrice;
            ProductsPriceWithExtraCosts = ProductsPrice += extraCosts;
            ProductsPriceWithMargin = ProductsPrice += margin;
        }

        private void CountDiscount()
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
        }
        private float CountPriceByWeight()
        {
            return ProductsPrice = ProductsPriceByWeight = ProductsWeight >= 1000 ?
                Products.All(p => p.Category.Equals(ProductCategory.Fruit)) ? ProductsPrice + 45
                : Products.All(p => p.Category.Equals(ProductCategory.Vegetable)) ? ProductsPrice + 35 : ProductsPrice + 25
                : ProductsWeight >= 500 ? ProductsPrice + 15
                : ProductsWeight >= 100 ? ProductsPrice + 10
                : ProductsWeight >= 50 ? ProductsPrice + 5
                : ProductsWeight >= 15 ? ProductsPrice + 2 : ProductsPrice;
        }

    }
}
