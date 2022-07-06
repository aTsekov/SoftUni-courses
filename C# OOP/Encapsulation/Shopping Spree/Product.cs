﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Spree
{
   
    public class Product
    {
        private string name;
        private decimal cost;
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public decimal Cost
        {
            get { return cost; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                cost = value;
            }
        }
    }
}
