namespace SpaceStation.Models
{
    using SpaceStation.Models.Bags.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Backpack : IBag

    {
        private List<string> items;
        public Backpack()
        {
            items = new List<string>();
        }
        public ICollection<string> Items => items;
    }
}
