using System;
using System.Collections.Generic;
using System.Text;

namespace agam
{
    public class Product
    {
        private string nameOfProduct;
        //private int cost;
        public Product(string nameOfProduct)
        {
            this.nameOfProduct = nameOfProduct;
        }

        public string getName()
        {
            return this.nameOfProduct;
        }

        public void setName(string nameOfProduct)
        {
            this.nameOfProduct = nameOfProduct;
        }
    }
}
