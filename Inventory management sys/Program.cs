using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management_sys
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            int choice;

            do
            {
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1. Add New Item");
                Console.WriteLine("2. Display All Items");
                Console.WriteLine("3. Find Item by ID");
                Console.WriteLine("4. Update Item");
                Console.WriteLine("5. Delete Item");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                Console.WriteLine();
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        inventory.AddItem();
                        break;
                    case 2:
                        inventory.DisplayItems();
                        break;
                    case 3:
                        inventory.FindItemById();
                        break;
                    case 4:
                        inventory.UpdateItem();
                        break;
                    case 5:
                        inventory.DeleteItem();
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine();
                        break;
                }
            } while (choice != 6);
        }
    }

    class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem()
        {
            Console.Write("Enter Item ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Item Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Item Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter Item Price: ");
            double price = double.Parse(Console.ReadLine());

            Item newItem = new Item(id, name, quantity, price);
            items.Add(newItem);
            Console.WriteLine();
            Console.WriteLine("Item added successfully.");
            Console.WriteLine("**************************************************************");
            Console.WriteLine();

        }

        public void DisplayItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("**************************************************************");
            Console.WriteLine();
        }

        public void FindItemById()
        {
            Console.Write("Enter Item ID to search: ");
            int id = int.Parse(Console.ReadLine());

            Item item = items.Find(i => i.ID == id);
            if (item != null)
            {
                Console.WriteLine(item);
                Console.WriteLine();
                Console.WriteLine("**************************************************************");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Item not found.");
                Console.WriteLine();
                Console.WriteLine("**************************************************************");
                Console.WriteLine();
            }
        }

        public void UpdateItem()
        {
            Console.Write("Enter Item ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Item item = items.Find(i => i.ID == id);
            if (item != null)
            {
                Console.Write("Enter new Item Name: ");
                item.Name = Console.ReadLine();
                Console.Write("Enter new Item Quantity: ");
                item.Quantity = int.Parse(Console.ReadLine());
                Console.Write("Enter new Item Price: ");
                item.Price = double.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Item updated successfully.");
                Console.WriteLine("**************************************************************");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Item not found.");
                Console.WriteLine("**************************************************************");
                Console.WriteLine();
            }
        }

        public void DeleteItem()
        {
            Console.Write("Enter Item ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            Item item = items.Find(i => i.ID == id);
            if (item != null)
            {
                items.Remove(item);
                Console.WriteLine();
                Console.WriteLine("Item deleted successfully.");
                Console.WriteLine("**************************************************************");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Item not found.");
                Console.WriteLine("**************************************************************");
                Console.WriteLine();
            }
        }
    }

    class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Item(int id, string name, int quantity, double price)
        {
            ID = id;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Quantity: {Quantity}, Price: {Price}";
        }
    }
}
