using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;



namespace agam
{
    
    class AgaMacolet
    {
        const int NUMBER_OF_CASH_REGISTER = 3;
        Queue<Customer> AgaMacoletCostumers;
        CashRegister[] CashRegisters = new CashRegister[NUMBER_OF_CASH_REGISTER];
        public AgaMacolet()
        {

            this.AgaMacoletCostumers = new Queue<Customer>();
            for (int i = 0; i < NUMBER_OF_CASH_REGISTER; i++)
            {
                // need to create 3 defualts cashiers to have one cashier at every cash register

                Cashier defaultCashier = new Cashier(false, true, "Cashier" + i.ToString(), 34 + i);
                this.CashRegisters[i] = new CashRegister(defaultCashier); //init all cash registers
            }

        }
        
        //public change cahsier of a cash register
        public void switchCashierCashRegister(int indexOfCashRegister, Cashier cashierToSwitch)
        {
            this.CashRegisters[indexOfCashRegister].setNewCashierAtCashRegister(cashierToSwitch);
        }
        public bool addCostumerToQueue(Customer customer)
        {
            if (customer.allowToEnterAgaMacolet())
            {
                Console.WriteLine("New costumer added successfully");
                this.AgaMacoletCostumers.Enqueue(customer);
                customer.BuyProducts();
                this.CashRegisters[this.getIndexOfCashRegisterWithTheLeastCustomers()].CustomerBuyAtCashregister(customer);
                return true;
            }

            Console.WriteLine("To enter AgaMacolet, The customer must have a mask, not isolated and body temp 38 or lower.");
            return false;
        }

        //remove a certain item from the queue
        public void removeCustomerFromQueue(Customer customerToRemove)
        {
            int CustomersInStoreBeforeRemove = this.AgaMacoletCostumers.Count;
            this.AgaMacoletCostumers = new Queue<Customer>(this.AgaMacoletCostumers.Where(customer => customer.getName() != customerToRemove.getName()));
            if(CustomersInStoreBeforeRemove != this.AgaMacoletCostumers.Count)
            {
                Console.WriteLine(customerToRemove.getName() + " exit the store.");
            }

        }

        //show the customers in the store
        public void showCustomers()
        {
            if (this.AgaMacoletCostumers.Count > 0) //check if the Queue is empty
            {
                foreach (Customer CustomerInQueue in this.AgaMacoletCostumers) //print all  cutomers in the store
                {
                    CustomerInQueue.showCustomer();
                    Console.WriteLine("###################"); // Add a separate line between the cutomers
                }
            }
            
            else
            {
                Console.WriteLine("The Agamacolet is Empty.");
            }
        }
        
        //get the cashier by name
        public Cashier GetCashierByName(string cashierName)
        {
            Cashier cashierToReturn = null;
            Cashier temp = null;

            for (int i = 0; i < NUMBER_OF_CASH_REGISTER; i++)
            {
                temp = this.CashRegisters[i].GetCashierByName(cashierName);
                if(temp != null) //save the cashier
                {
                    cashierToReturn = temp;
                }
            }
            return cashierToReturn;
        }


        // get customer by name
        public Customer GetCustomerByName(string CustomerName)
        {
            bool foundTheCustomer = true;
            foreach(Customer customer in this.AgaMacoletCostumers)
            {
                if(customer.getName() == CustomerName)
                {
                    return customer;
                }
            }
            if(foundTheCustomer)
            {
                Console.WriteLine(CustomerName + " is not in the Agamacolet.");
            }

            return null;
        }

        public void showEveryPurchasesOfCustomersAtCashRegister()
        {
            for (int i = 0; i < NUMBER_OF_CASH_REGISTER; i++)
            {
                this.CashRegisters[i].showRecordOfCustomersOfCashRegister();
            }
        }

        // show all cashier logs at every cash register
        public void showEveryCashRegisterCashierLogs()
        {
            for(int i = 0; i < NUMBER_OF_CASH_REGISTER; i++)
            {
                this.CashRegisters[i].showCashiersLogs();
            }
        }
        
        //get the index of cash register with the least customer in line
        public int getIndexOfCashRegisterWithTheLeastCustomers()
        {
            int index = 0;
            int numberOfCustomers = this.CashRegisters[index].getCustomersInLine().Count;
            
            for (int i = 1; i < NUMBER_OF_CASH_REGISTER; i++)
            {
                int nextNumberOfCustomers = this.CashRegisters[index].getCustomersInLine().Count;
                if(nextNumberOfCustomers < numberOfCustomers)
                {
                    index = i;
                    numberOfCustomers = nextNumberOfCustomers;
                }
            }

            return index;
        }

        // send every one in touch with the customer that have corona to isolation
        public void CustomerWithCorona(string name)
        {
            for (int i = 0; i < NUMBER_OF_CASH_REGISTER; i++)
            {
                this.CashRegisters[i].CustomerWithCorona(this.GetCustomerByName(name));
            }
        }

    }
}
