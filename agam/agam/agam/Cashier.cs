using System;
using System.Collections.Generic;
using System.Text;

namespace agam
{
    class Cashier : Person
    {
        private Queue<Customer> CustomersCashierServed;

        public Cashier(bool CashierIsolated, bool CashierHasMask, string CashierName, int CashierBodyTemperature): base(CashierIsolated, CashierHasMask, CashierName, CashierBodyTemperature)
        {
            this.CustomersCashierServed = new Queue<Customer>();
        }


        public Queue<Customer> getCustomerCashierServed()
        {
            return this.CustomersCashierServed;
        }

        public void addServedCustomers(Customer customer)
        {
            this.CustomersCashierServed.Enqueue(customer);
        }

        // send the cashier and his customers to isolation
        public void IsolateByCustomerCorona()
        {
            this.setIsolated(true);
            foreach (Customer customer in this.CustomersCashierServed)
            {
                customer.setIsolated(true);
            }
        }



    }
}
