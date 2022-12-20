
using IO_refactoring;

User regularUser;
User vipUser;
Basket regUserBacket = new();
Basket vipUserBacket = new();
Product product1;
Product product2;
Product product3;

initUserData();
initProducts();


addProductsToBasket(vipUserBacket, product1, product2, product3);
vipUserBacket.DisplayBasket();

addProductsToBasket(regUserBacket, product1, product2, product3);
regUserBacket.DisplayBasket();

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
    regUserBacket.Owner = regularUser;
    vipUserBacket.Owner = vipUser;
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
    if (list.Length > 0 && list.Length <= 3) basket.Products = list;
    else Console.WriteLine("Można dodać od 1 do 3 przedmiotów");
}