using System;






namespace agam
{
    
    class Program
    {
        static int Menu()
        {

            int Option = -1;
            string userInput;
            while (true)
            {
                Console.WriteLine("Welcome to AgaMacolet!");
                Console.WriteLine("1 - Enter a new costumer to the store.");
                Console.WriteLine("2 - Enter X of new costumers to the store.");
                Console.WriteLine("3 - Show the customers in the store.");
                Console.WriteLine("4 - To create a new cashier.");
                Console.WriteLine("5 - Show purchases record at cash registers");
                Console.WriteLine("6 - Show cashier activation logs at cash registers");
                Console.WriteLine("7 - Old customer has a corona");
                Console.WriteLine("8 - Customer exit the store.");
                Console.WriteLine("9 - Switch between Cashiers");
                Console.WriteLine("10 - Check if cashier ia able to work");
                Console.WriteLine("11 - Exit");
                userInput = Console.ReadLine();
                
                if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5" || userInput == "6" || userInput == "7" || userInput == "8" || userInput == "9" || userInput == "10" || userInput == "11")
                {
                    Option = Convert.ToInt32(userInput);
                    break;

                }
            }
            
            return Option;

        }

        static Customer AddNewCostumer()
        {
            Console.WriteLine("Enter Costumer's name:");
            string CostumerName = Console.ReadLine();

            Console.WriteLine("Enter Costumer's temperature:");
            int CostumerBodyTemperature = 0;
            bool CostumerBodyTemperatureBool = int.TryParse(Console.ReadLine(), out CostumerBodyTemperature);
            while (!(CostumerBodyTemperatureBool))
            {
                Console.WriteLine("Enter Costumer's temperature:");
                CostumerBodyTemperatureBool = int.TryParse(Console.ReadLine(), out CostumerBodyTemperature);
            }

            Console.WriteLine("The Costumer has a mask (type yes for true and no for false):");
            string HasMask = Console.ReadLine();
            bool CostumerHasMask;
            while (true)
            {
                if(String.Equals(HasMask, "yes"))
                {
                    CostumerHasMask = true;
                    break;
                }
                else if(String.Equals(HasMask, "no"))
                {
                    CostumerHasMask = false;
                    break;
                }
                else
                {
                    Console.WriteLine("The Costumer has a mask (type yes for true and no for false):");
                    HasMask = Console.ReadLine();
                }
            }

            Console.WriteLine("The Costumer is isolated (type yes for true and no for false):");
            string Isolated = Console.ReadLine();
            bool CostumerIsolated;
            while (true)
            {
                if (String.Equals(Isolated, "yes"))
                {
                    CostumerIsolated = true;
                    break;
                }
                else if (String.Equals(Isolated, "no"))
                {
                    CostumerIsolated = false;
                    break;
                }
                else
                {
                    Console.WriteLine("The Costumer is isolated (type yes for true and no for false):");
                    Isolated = Console.ReadLine();
                }
            }

            Customer newCostumer = new Customer(CostumerIsolated, CostumerHasMask, CostumerName, CostumerBodyTemperature);
            return newCostumer;
             

        }






        static void Main(string[] args)
        {
            int option=0;
            AgaMacolet agamacolet = new AgaMacolet();

            while(option != 11)
            {
                option = Menu();
                switch (option)
                {
                    case 1: //add new costumer to the store
                        agamacolet.addCostumerToQueue(AddNewCostumer()); //try to add a costumer to the agamacolet
                        break;
                    case 2: // add X of new costumers to the store

                        Console.WriteLine("Enter number of new customers to add:");
                        int numberOfCustomersToAdd = 0;
                        bool numberOfCustomersToAddBool = int.TryParse(Console.ReadLine(), out numberOfCustomersToAdd);
                        while (!(numberOfCustomersToAddBool))
                        {
                            Console.WriteLine("Enter number of new customers to add:");
                            numberOfCustomersToAddBool = int.TryParse(Console.ReadLine(), out numberOfCustomersToAdd); //make sure the input is valid
                        }

                        for (int i = 0; i < numberOfCustomersToAdd; i++) //add new customers
                        {
                            agamacolet.addCostumerToQueue(AddNewCostumer());
                        }
                        break;
                    case 3: // show the current costumers in the store
                        agamacolet.showCustomers();
                        break;
                    case 4: //create a new cashier
                        Console.WriteLine("Enter Cashier name: ");
                        string newCashierName = Console.ReadLine();
                        Cashier newCashier = new Cashier(false, true, newCashierName, 36);
                        Console.WriteLine("Enter number of the cash register the new cashier will work there (1 ,2 , 3): ");
                        string cashRegisterNumber = Console.ReadLine();
                        while(cashRegisterNumber != "1" && cashRegisterNumber != "2" && cashRegisterNumber != "3")
                        {
                            Console.WriteLine("Enter number of the cash register the new cashier will work there (1 ,2 , 3): ");
                            cashRegisterNumber = Console.ReadLine();
                        }
                        agamacolet.switchCashierCashRegister(Convert.ToInt32(cashRegisterNumber) - 1, newCashier);
                        break;
                    case 5: // show records of customers Purchased items at cash register
                        agamacolet.showEveryPurchasesOfCustomersAtCashRegister();
                        break;
                    case 6: //show cashier activation at cash register
                        agamacolet.showEveryCashRegisterCashierLogs();
                        break;
                    case 7: //past customer had a corona
                        Console.WriteLine("Enter the customer name that have corona: ");
                        string customerNameWithCorona = Console.ReadLine();
                        agamacolet.CustomerWithCorona(customerNameWithCorona);
                        break;
                    case 8: //Customer go to out from the store
                        Console.WriteLine("Enter the customer name(That will exit the store): ");
                        string customerName = Console.ReadLine();
                        agamacolet.removeCustomerFromQueue(agamacolet.GetCustomerByName(customerName));
                        break;
                    case 9: //switch between cashiers
                        Console.WriteLine("Enter Cashier name: ");
                        string CashierName = Console.ReadLine();
                        Cashier cashierToSwitch = agamacolet.GetCashierByName(CashierName);
                        if(cashierToSwitch != null)
                        {
                            Console.WriteLine("Enter number of the cash register the cashier will work there (1 ,2 , 3): ");
                            cashRegisterNumber = Console.ReadLine();
                            while (cashRegisterNumber != "1" && cashRegisterNumber != "2" && cashRegisterNumber != "3") //check validation input 
                            {
                                Console.WriteLine("Enter number of the cash register the cashier will work there (1 ,2 , 3): ");
                                cashRegisterNumber = Console.ReadLine();
                            }
                            agamacolet.switchCashierCashRegister(Convert.ToInt32(cashRegisterNumber) - 1, cashierToSwitch); // get the currect index the user type, that's why it is -1.
                        }
                        else
                        {
                            Console.WriteLine("Could not find the cashier you entered.");
                        }

                        break;
                    case 10://check if a cashier is able to work
                        Console.WriteLine("Enter Cashier name: ");
                        CashierName = Console.ReadLine();
                        Cashier cashierToCheck = agamacolet.GetCashierByName(CashierName);
                        if (cashierToCheck != null)
                        {
                            if(cashierToCheck.allowToEnterAgaMacolet()) //check is the cashier is allowed to work
                            {
                                Console.WriteLine(cashierToCheck.getName() + " can continue working.");
                            }
                            else 
                            {
                                Console.WriteLine(cashierToCheck.getName() + "is not allowed to enter the agamacolet.");
                                Console.WriteLine("He will be deported and fined NIS 40. He will pay off the debt through future working hours an hour of work is worth NIS 30");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Could not find the cashier you entered.");
                        }
                        break;
                    default:
                        break;
                }

            }

            Console.WriteLine("Goodbye!");
            




        }
    }
}
