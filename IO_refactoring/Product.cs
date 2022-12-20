namespace IO_refactoring
{
    class Product
    {
        public string? Name { get; set; }
        public ProductCategory Category { get; set; }
        public float Price { get; set; }
        public int Weight { get; set; }

        public static Product[] generateSampleProducts()
        {
            return new Product[] { new Product()
            {
                Name = "Banan",
                Category = ProductCategory.Fruit,
                Price = 20.99f,
                Weight = 20
            },

            new Product()
            {
                Name = "Fasola",
                Category = ProductCategory.Vegetable,
                Price = 20.123f,
                Weight = 10
            },

            new Product()
            {
                Name = "Kiwi",
                Category = ProductCategory.Fruit,
                Price = 123,
                Weight = 10
            } };
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Product p = (Product)obj;
                return (Name == p.Name) && (Category == p.Category) && (Price == p.Price) && (Weight == p.Weight);
            }
        }

        public override int GetHashCode() => 37 * Name!.GetHashCode() + Category.GetHashCode();
    }
}
