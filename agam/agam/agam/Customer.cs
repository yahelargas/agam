using System;
using System.Collections.Generic;
using System.Text;

namespace agam
{
    class Customer : Person
    {
        private Stack<Product> PurchasedItems;
        public Customer(bool CustomerIsolated, bool CustomerHasMask, string CustomernName, int CustomerBodyTemperature) : base(CustomerIsolated, CustomerHasMask, CustomernName, CustomerBodyTemperature)
        {
            this.PurchasedItems = new Stack<Product>();
        }


        public bool addItemsToPurchase(Product itemToPurchase)
        {
            
            if(itemToPurchase.getName().Length > 0)
            {
                this.PurchasedItems.Push(itemToPurchase);
                Console.WriteLine("Item added successfully.");
                return true;
            }

            Console.WriteLine("Item name is not valid!");
            return false;
        }

        public void showCustomer()
        {
            Console.WriteLine("Customer name: " + this.Name);
            Console.WriteLine("Customer body temperature: " + this.BodyTemperature);
            Console.WriteLine("Customer has a mask: " + this.HasMask);
            Console.WriteLine("Customer is isolated: " + this.Isolated);
        }

        public void CustomerProducts()
        {
            if (this.PurchasedItems.Count > 0) //check if the stack is empty
            {
                Console.WriteLine("Customer's Products:");
                foreach (Product p in this.PurchasedItems)
                {
                    Console.WriteLine("Product: " + p.getName());
                }
            }

            else
            {
                Console.WriteLine("Customer did not buy any products.");
            }
           
        }

        public void BuyProducts()
        {
            while (true)
            {
                Console.WriteLine("Enter Product's name (type stop if you finished purchsing products):");
                string productName = Console.ReadLine();
                if (String.Equals(productName, "stop"))
                {
                    break;
                }
                else
                {
                    Product productToBuy = new Product(productName);
                    this.addItemsToPurchase(productToBuy);
                }

            }

        }

    }
}
