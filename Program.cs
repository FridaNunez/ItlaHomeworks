using PlantStore.dbcontext;
using PlantStore.model;
using PlantStore.services;
using System;

namespace PlantStore
{
    internal class Program
    {
        // ---------------------------
        // MENÚS VISUALES
        // ---------------------------

        public static void ShowMenuPlants()
        {
            Console.WriteLine("\n--- Plants Menu ---");
            Console.WriteLine("------------------------");
            Console.WriteLine("| 1. Add Plant         |");
            Console.WriteLine("| 2. View Plants       |");
            Console.WriteLine("| 3. Update Plant      |");
            Console.WriteLine("| 4. Delete Plant      |");
            Console.WriteLine("| 5. Back to Menu      |");
            Console.WriteLine("------------------------");
        }

        public static void ShowMenuCategories()
        {
            Console.WriteLine("\n--- Categories Menu ---");
            Console.WriteLine("------------------------");
            Console.WriteLine("| 1. Add Category      |");
            Console.WriteLine("| 2. View Categories   |");
            Console.WriteLine("| 3. Update Category   |");
            Console.WriteLine("| 4. Delete Category   |");
            Console.WriteLine("| 5. Back to Menu      |");
            Console.WriteLine("------------------------");
        }

        public static void ShowMenuClients()
        {
            Console.WriteLine("\n--- Clients Menu ---");
            Console.WriteLine("------------------------");
            Console.WriteLine("| 1. Add Client        |");
            Console.WriteLine("| 2. View Clients      |");
            Console.WriteLine("| 3. Update Client     |");
            Console.WriteLine("| 4. Delete Client     |");
            Console.WriteLine("| 5. Back to Menu      |");
            Console.WriteLine("------------------------");
        }

        public static void ShowMenuOrders()
        {
            Console.WriteLine("\n--- Orders Menu ---");
            Console.WriteLine("------------------------");
            Console.WriteLine("| 1. Create Order      |");
            Console.WriteLine("| 2. View Orders       |");
            Console.WriteLine("| 3. Update Order      |");
            Console.WriteLine("| 4. Delete Order      |");
            Console.WriteLine("| 5. Back to Menu      |");
            Console.WriteLine("------------------------");
        }

        // ---------------------------
        // PROGRAMA PRINCIPAL
        // ---------------------------

        static void Main(string[] args)
        {
            string option;

            do
            {
                Console.WriteLine("\nWelcome to Plant Store Management!");
                Console.WriteLine("----------------------------");
                Console.WriteLine("| 1. Manage Plants        |");
                Console.WriteLine("| 2. Manage Categories    |");
                Console.WriteLine("| 3. Manage Clients       |");
                Console.WriteLine("| 4. Manage Orders        |");
                Console.WriteLine("| 5. Exit                 |");
                Console.WriteLine("----------------------------");

                option = Console.ReadLine() ?? "";

                switch (option)
                {
                    // -------------------------
                    // PLANTS
                    // -------------------------
                    case "1":
                        string plantOption;
                        do
                        {
                            ShowMenuPlants();
                            plantOption = Console.ReadLine() ?? "";

                            switch (plantOption)
                            {
                                case "1":
                                    Console.Write("Plant Name: ");
                                    string name = Console.ReadLine() ?? "";

                                    Console.Write("Price: ");
                                    decimal price = decimal.TryParse(Console.ReadLine(), out var p) ? p : 0;

                                    Console.Write("Stock: ");
                                    int stock = int.TryParse(Console.ReadLine(), out var s) ? s : 0;

                                    Console.Write("Category ID: ");
                                    int categoryId = int.TryParse(Console.ReadLine(), out var cId) ? cId : 0;

                                    PlantaService.AddPlant(name, price, stock, categoryId);
                                    break;

                                case "2":
                                    var plants = PlantaService.GetPlants();
                                    foreach (var planta in plants)
                                        Console.WriteLine($"Id: {planta.Id}, Name: {planta.Name}, Price: {planta.Precio}, Stock: {planta.Stock}, CategoryId: {planta.CategoriaId}");
                                    break;

                                case "3":
                                    Console.Write("Enter Plant ID to update: ");
                                    int pid = int.TryParse(Console.ReadLine(), out var pidv) ? pidv : 0;

                                    var plant = PlantaService.GetPlantById(pid);
                                    if (plant != null)
                                    {
                                        Console.Write("New Name: ");
                                        plant.Name = Console.ReadLine() ?? "";

                                        Console.Write("New Price: ");
                                        plant.Precio = decimal.TryParse(Console.ReadLine(), out var np) ? np : plant.Precio;

                                        Console.Write("New Stock: ");
                                        plant.Stock = int.TryParse(Console.ReadLine(), out var ns) ? ns : plant.Stock;

                                        Console.Write("New Category ID: ");
                                        plant.CategoriaId = int.TryParse(Console.ReadLine(), out var nc) ? nc : plant.CategoriaId;

                                        PlantaService.UpdatePlant(plant);
                                    }
                                    else Console.WriteLine("Plant not found.");
                                    break;

                                case "4":
                                    Console.Write("Enter Plant ID to delete: ");
                                    int pdel = int.TryParse(Console.ReadLine(), out var pd) ? pd : 0;
                                    PlantaService.DeletePlant(pdel);
                                    break;
                            }

                        } while (plantOption != "5");
                        break;

                    // -------------------------
                    // CATEGORIES
                    // -------------------------
                    case "2":
                        string catOption;
                        do
                        {
                            ShowMenuCategories();
                            catOption = Console.ReadLine() ?? "";

                            switch (catOption)
                            {
                                case "1":
                                    Console.Write("Category Name: ");
                                    string cname = Console.ReadLine() ?? "";
                                    CategoriaService.AddCategory(cname);
                                    break;

                                case "2":
                                    var categories = CategoriaService.GetCategories();
                                    foreach (var c in categories)
                                        Console.WriteLine($"Id: {c.Id}, Name: {c.Name}");
                                    break;

                                case "3":
                                    Console.Write("ID to update: ");
                                    int cid = int.TryParse(Console.ReadLine(), out var cidv) ? cidv : 0;

                                    var cat = CategoriaService.GetCategoryById(cid);
                                    if (cat != null)
                                    {
                                        Console.Write("New Name: ");
                                        cat.Name = Console.ReadLine() ?? "";
                                        CategoriaService.UpdateCategory(cat);
                                    }
                                    else Console.WriteLine("Category not found.");
                                    break;

                                case "4":
                                    Console.Write("ID to delete: ");
                                    int cdel = int.TryParse(Console.ReadLine(), out var cd) ? cd : 0;
                                    CategoriaService.DeleteCategory(cdel);
                                    break;
                            }

                        } while (catOption != "5");
                        break;

                    // -------------------------
                    // CLIENTS
                    // -------------------------
                    case "3":
                        string clientOption;
                        do
                        {
                            ShowMenuClients();
                            clientOption = Console.ReadLine() ?? "";

                            switch (clientOption)
                            {
                                case "1":
                                    Console.Write("Client Name: ");
                                    string clname = Console.ReadLine() ?? "";

                                    Console.Write("Email: ");
                                    string email = Console.ReadLine() ?? "";

                                    Console.Write("Phone: ");
                                    string telefono = Console.ReadLine() ?? "";

                                    ClienteService.AddClient(clname, email, telefono);
                                    break;

                                case "2":
                                    var clients = ClienteService.GetClients();
                                    foreach (var c in clients)
                                        Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Email: {c.Email}, Phone: {c.Telefono}");
                                    break;

                                case "3":
                                    Console.Write("Client ID: ");
                                    int cidc = int.TryParse(Console.ReadLine(), out var cidcv) ? cidcv : 0;

                                    var client = ClienteService.GetClientById(cidc);
                                    if (client != null)
                                    {
                                        Console.Write("New Name: ");
                                        client.Name = Console.ReadLine() ?? "";

                                        Console.Write("New Email: ");
                                        client.Email = Console.ReadLine() ?? "";

                                        Console.Write("New Phone: ");
                                        client.Telefono = Console.ReadLine() ?? "";

                                        ClienteService.UpdateClient(client);
                                    }
                                    else Console.WriteLine("Client not found.");
                                    break;

                                case "4":
                                    Console.Write("Client ID to delete: ");
                                    int cldel = int.TryParse(Console.ReadLine(), out var cld) ? cld : 0;
                                    ClienteService.DeleteClient(cldel);
                                    break;
                            }

                        } while (clientOption != "5");
                        break;

                    // -------------------------
                    // ORDERS
                    // -------------------------
                    case "4":
                        string orderOption;
                        do
                        {
                            ShowMenuOrders();
                            orderOption = Console.ReadLine() ?? "";

                            switch (orderOption)
                            {
                                case "1":
                                    Console.Write("Client ID: ");
                                    int clientId = int.TryParse(Console.ReadLine(), out var cidv) ? cidv : 0;

                                    Console.Write("Plant ID: ");
                                    int plantId = int.TryParse(Console.ReadLine(), out var pidv) ? pidv : 0;

                                    Console.Write("Quantity: ");
                                    int qty = int.TryParse(Console.ReadLine(), out var q) ? q : 0;

                                    PedidoService.CreateOrder(clientId, plantId, qty);
                                    break;

                                case "2":
                                    var orders = PedidoService.GetOrders();
                                    foreach (var o in orders)
                                    {
                                        Console.WriteLine($"Pedido ID: {o.Id}, ClienteID: {o.ClienteId}, Fecha: {o.Fecha}");
                                        foreach (var item in o.Items)
                                            Console.WriteLine($"\tPlantaID: {item.PlantaId}, Cantidad: {item.Cantidad}");
                                    }
                                    break;

                                case "3":
                                    Console.Write("Order ID: ");
                                    int oid = int.TryParse(Console.ReadLine(), out var o1) ? o1 : 0;

                                    Console.Write("Plant ID to update: ");
                                    int opid = int.TryParse(Console.ReadLine(), out var o2) ? o2 : 0;

                                    Console.Write("New Quantity: ");
                                    int newQty = int.TryParse(Console.ReadLine(), out var nq) ? nq : 0;

                                    PedidoService.UpdateOrderItem(oid, opid, newQty);
                                    break;

                                case "4":
                                    Console.Write("Order ID to delete: ");
                                    int odel = int.TryParse(Console.ReadLine(), out var od) ? od : 0;
                                    PedidoService.DeleteOrder(odel);
                                    break;
                            }

                        } while (orderOption != "5");
                        break;

                    case "5":
                        Console.WriteLine("Exiting...");
                        break;
                }

            } while (option != "5");
        }
    }
}
