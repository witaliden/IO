
using IO_refactoring;

User regularUser;
User vipUser;
Product[] products;

initializeUsers();
products = Product.generateSampleProducts();

startShopping(regularUser, products[0], products[1]);
finilizeShopping(regularUser);

startShopping(vipUser, products[0], products[1], products[2]);
finilizeShopping(vipUser);


void startShopping(User user, params Product[] list)
{
    if (list.Length > 0 && list.Length <= 3)
    user.Basket.addProductsToBasket(list);
    else Console.WriteLine("Można dodać od 1 do 3 przedmiotów");
}
void finilizeShopping(User user, int margin = 0, int extraCost = 0, bool productPriceDependsOnWeight = true)
{
    Console.WriteLine($"Koszyk użytkownika {user.FirstName} {user.LastName} ({user.Role}):");
    regularUser.Basket.DisplayBasket(user.Role);
}
void initializeUsers()
{
    regularUser = new()
    {
        FirstName = "Framek",
        LastName = "Kączak",
        Basket = new Basket()
    };

    vipUser = new()
    {
        FirstName = "Antonio",
        LastName = "Kowalski",
        Basket = new Basket(),
        Role = UserRoles.VIP
    };
}