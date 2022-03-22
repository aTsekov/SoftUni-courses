using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Store_Boxes
{
    class Program
    {
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }

        public decimal PriceOfABox
        {
            get
            {
                return this.ItemQuantity * this.Item.Price;
            }
        }
    }
    static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<Box> BoxInfo = new List<Box>();

            while (command[0] != "end")
            {
                int serialNumber = int.Parse(command[0]);
                string itemName = command[1];
                int itemQuantity = int.Parse(command[2]);
                decimal itemPrice = decimal.Parse(command[3]);

                decimal priceForOneBox = itemPrice * itemQuantity;

                // правим нов обект от въведеното в конзолата: 

                Box boxObject = new Box()
                {
                    SerialNumber = serialNumber,
                        Item = new Item()
                        {
                            Name = itemName,
                            Price = itemPrice
                        },
                    ItemQuantity = itemQuantity,
                    //PriceOfABox = priceForOneBox,
                    


                };
                BoxInfo.Add(boxObject);

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            List<Box> orderedBoxes = BoxInfo.OrderByDescending(x => x.PriceOfABox).ToList();


            foreach (Box box in orderedBoxes)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceOfABox:f2}"); ;
            }
            
        }
    }
}
