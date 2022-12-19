
using IO_refactoring;

User regularUser;
User vipUser;
Basket regUserBacket = new();
Basket vipUserBacket = new();
Product product1;
Product product2;
Product product3;

initProducts();
initUserData();

addProductsToBasket(vipUserBacket, product1, product2, product3);
addProductsToBasket(regUserBacket, product1, product2, product3);

DisplayBasket(regularUser);
DisplayBasket(vipUser);

void initUserData()
{
    regularUser = new()
    {
        FirstName = "Framek",
        LastName = "Kączak",
        Basket = regUserBacket
    };

    vipUser = new()
    {
        FirstName = "Antonio",
        LastName = "Kowalski",
        Basket = vipUserBacket,
        Role = UserRoles.VIP
    };
}
void initProducts()
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
void addProductsToBasket(Basket basket, params Product[] list)
{
    if (list.Length > 0 && list.Length <= 3) basket.products = list;
    else Console.WriteLine("Można dodać od 1 do 3 przedmiotów");
}

void DisplayBasket(User user, int extraCosts = 0, int margin = 0, bool productPriceDependsOnWeight = true)
{
    Console.WriteLine($"Koszyk użytkownika {user.FirstName} {user.LastName} ({user.Role})");
    user.Basket.CalcBasketSum(extraCosts, margin, productPriceDependsOnWeight, user.Role!);
    Console.WriteLine($"Cena produktów: {String.Format("{0:0.00}", user.Basket.BaseProductsPrice)}");
    Console.WriteLine($"Cena produktów po zniżce: {String.Format("{0:0.00}", user.Basket.ProductsPriceAfterDiscount)}");
    Console.WriteLine($"Cena produktów dla grupy użytkownika: {String.Format("{0:0.00}", user.Basket.ProductsPriceAfterRoleDiscount)}");
    Console.WriteLine($"Waga produktów: {user.Basket.ProductsWeight}");
    Console.WriteLine($"Cena produktów zgodnie z wagą: {String.Format("{0:0.00}", user.Basket.ProductsPriceByWeight)}");
    Console.WriteLine($"Cena produktów + dodatkowe koszty: {String.Format("{0:0.00}", user.Basket.ProductsPriceWithExtraCosts)}");
    Console.WriteLine($"Cena produktów + marża: {String.Format("{0:0.00}", user.Basket.ProductsPriceWithMargin)}\n");
}