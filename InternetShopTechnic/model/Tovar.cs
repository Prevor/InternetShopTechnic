using System;
using System.Collections.Generic;


namespace InternetShopTechnic.model
{
    public class Tovar
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public Category Category { get; set; }

        public double Price { get; set; }

        public string Producer { get; set; }

        public string Address { get; set; }

        public string Characteristics { get; set; }

        private int number;

        public bool Available { get; set; }
        public int Number
        {
            set
            {
                if (value > 0)
                {
                    Available = true;
                    number = value;
                }
                else
                {
                    Available = false;
                }

            }
            get { return number; }
        }

        public List<Order> Order { get; set; }

        public Characteristics GetCharacteristics()
        {
            return new Characteristics() { here = Characteristics.Split("*") };
        }
    }

    public enum Category
    {
        телевізори, програвачі, холодильники, пралки
    }

    public class Characteristics
    {
        public string[] here { get; set; }


        public override string ToString()
        {
            return String.Join("*", here);
        }
    }
}
