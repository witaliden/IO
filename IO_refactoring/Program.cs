
using IO_refactoring;

User regularUser;
User vipUser;
Product product1;
Product product2;
Product product3;

fillProducts();
fillUserData();

addProductsToBasket(vipUser, product1, product2);
addProductsToBasket(regularUser, product1, product2, product3);

DisplayBasket(regularUser);
DisplayBasket(vipUser);


void fillUserData()
{
    regularUser = new()
    {
        FirstName = "Framek",
        LastName = "Kączak"
    };

    vipUser = new()
    {
        FirstName = "Antonio",
        LastName = "Kowalski",
        Role = UserRoles.VIP
    };
}
void fillProducts()
{
    product1 = new()
    {
        Name = "Fasola",
        Category = ProductCategory.Vegetable,
        Price = 20.123f,
        Weight = 10
    };
    product2 = new()
    {
        Name = "Banan",
        Category = ProductCategory.Fruit,
        Price = 20.99f,
        Weight = 20
    };
    product3 = new()
    {
        Name = "Kiwi",
        Category = ProductCategory.Fruit,
        Price = 123,
        Weight = 10
    };
}
void addProductsToBasket(User user, params Product[] list)
{
    if (list.Length > 0 && list.Length <= 3) user.Basket.products = list;
    else Console.WriteLine("Można dodać od 1 do 3 przedmiotów");
}

void DisplayBasket(User user, int extraCosts = 0, int margin = 0, bool productPriceDependsOnWeight = true)
{
    Console.WriteLine($"Cena produktów: {regularUser.Basket.BaseProductsPrice}");
    Console.WriteLine($"Cena produktów po zniżce: {regularUser.Basket.ProductsPriceAfterDiscount}");
    Console.WriteLine($"Cena produktów dla grupy użytkownika: {regularUser.Basket.ProductsPriceAfterRoleDiscount}");
    Console.WriteLine($"Waga produktów: {regularUser.Basket.ProductsWeight}");
    Console.WriteLine($"Cena produktów zgodnie z wagą: {regularUser.Basket.ProductsPriceByWeight}");
    Console.WriteLine($"Cena produktów + dodatkowe koszty: {regularUser.Basket.ProductsPriceWithExtraCosts}");
    Console.WriteLine($"Cena produktów + marża: {regularUser.Basket.ProductsPriceWithMargin}");

}