using System;
using System.Collections.Generic;
using System.Text;

namespace agam
{
    class CashRegister
    {
        private Queue<Customer> CustomersInLine;
        private Stack<string> CashierActivations;
        private Queue<Cashier> CashierWorkedCashRegister;
        private Cashier currCashier;


        public CashRegister()
        {
            this.CashierActivations = new Stack<string>();
            this.CustomersInLine = new Queue<Customer>();
            this.CashierWorkedCashRegister = new Queue<Cashier>();
            this.currCashier = null;
        }
        public CashRegister(Cashier currCashier)
        {
            this.CashierActivations = new Stack<string>();
            this.CustomersInLine = new Queue<Customer>();
            this.CashierWorkedCashRegister = new Queue<Cashier>();
            this.currCashier = currCashier;
            this.addCashierToQueue(currCashier);
            this.cashierActivation();
        }

        //customer but at agamacolet
        public void CustomerBuyAtCashregister(Customer customer)
        {
            this.CustomersInLine.Enqueue(customer);
            this.currCashier.addServedCustomers(customer);
            Console.WriteLine("Thank you for buying at AgaMacolet!");
            this.CustomersInLine.Dequeue();
        }

        //add the new cashier to a queue so we can remember that he worked at this cash register
        public void addCashierToQueue(Cashier CashierToAdd)
        {
            if(!this.checkIfCashierWorkedOnThisCashRegister(CashierToAdd))
            {
                this.CashierWorkedCashRegister.Enqueue(CashierToAdd);
            }
        }

        public Queue<Customer> getCustomersInLine()
        {
            return this.CustomersInLine;
        }

        //check if the cashier we want to add is already worked on this cash register
        public bool checkIfCashierWorkedOnThisCashRegister(Cashier cashierToCheck)
        {
            foreach(Cashier cashier in this.CashierWorkedCashRegister)
            {
                if(cashier == cashierToCheck)
                {
                    return true;
                }
            }
            return false;
        }

        //log every cashier that is working
        public void cashierActivation()
        {
            DateTime activationTime = DateTime.Now;
            this.CashierActivations.Push("The " + this.currCashier.getName() + " activate the cash register at " + activationTime.ToString());

        }

        //set new cashier at the cash register when it is free
        public void setNewCashierAtCashRegister(Cashier cashier)
        {
            if(!this.checkIfCashierWorkedOnThisCashRegister(cashier))
            {
                Console.WriteLine("addad");
                this.addCashierToQueue(cashier);
            }
            this.currCashier = cashier;

            this.cashierActivation();
            Console.WriteLine(this.currCashier.getName());
        }

        //check is the cash register is free
        public bool checkCashRegisterAvailable()
        {
            if(this.currCashier == null)
            {
                return true;
            }

            return false;
        }

        public void showCashiersLogs()
        {
            if(this.CashierActivations.Count > 0)
            {
                foreach(string cashierActivation in this.CashierActivations)
                {
                    Console.WriteLine(cashierActivation);
                    Console.WriteLine("###################");
                }
            }
            else
            {
                Console.WriteLine("No cashier worked at this Cash register");
            }
        }


        //show customers that bought at this cash register
        public void showRecordOfCustomersOfCashRegister()
        {
            

            if (this.CashierWorkedCashRegister.Count > 0) //check if the Queue of cashiers is empty
            {
                foreach (Cashier cashierThatWorkedOnThisCashRegister in this.CashierWorkedCashRegister)
                {

                    if(cashierThatWorkedOnThisCashRegister.getCustomerCashierServed().Count > 0)
                    {
                        Console.WriteLine(cashierThatWorkedOnThisCashRegister.getName() + " customers:");
                        foreach (Customer currCustomer in cashierThatWorkedOnThisCashRegister.getCustomerCashierServed())
                        {
                            currCustomer.showCustomer();
                            currCustomer.CustomerProducts();
                        }
                    }
                    else
                    {
                        Console.WriteLine(cashierThatWorkedOnThisCashRegister.getName() + " Served 0 customers.");
                    }
                    Console.WriteLine("####################################");
                    
                }

                
            }

            else
            {
                Console.WriteLine("0 cashier worked at this cash register");
            }
        }

        public bool CustomerWithCorona(Customer customer)
        {
            foreach(Cashier cashier in this.CashierWorkedCashRegister)
            {
                foreach(Customer customerTheCashierServed in cashier.getCustomerCashierServed())
                {
                    if(customer == customerTheCashierServed)
                    {
                        cashier.IsolateByCustomerCorona();
                        return true;
                    }
                }
            }
            return false;
        }

        //get cashier by name
        public Cashier GetCashierByName(string name)
        {
            foreach(Cashier cashier in this.CashierWorkedCashRegister)
            {
                if(cashier.getName() == name)
                {
                    return cashier;
                }
            }
            return null;
        }


    }
}
