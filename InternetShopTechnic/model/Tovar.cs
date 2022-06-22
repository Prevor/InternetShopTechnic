using System;
using System.Collections.Generic;


namespace InternetShopTechnic.model
{
    public class Tovar                                 // Клас "Товар"
    {                                                 
        public int Id { get; set; }                    // Унікальний ID товару
        public string Name { get; set; }               // Назва товару
        public Category Category { get; set; }         // Категорія товару
        public double Price { get; set; }              // Ціна товару
        public string Producer { get; set; }           // Виробник товару
        public string Address { get; set; }            // Адрес збірки товару
        public string Characteristics { get; set; }    // Характеристика товару
        private int _number;                           // Приватне поле для підрахунку кількості товару
        public bool Available { get; set; }            // Наявність товару
        public int Number                              // Кількість товару
        {
            set
            {
                if (value > 0)
                {
                    Available = true;
                    _number = value;
                }
                else
                {
                    Available = false;
                }

            }
            get => _number;
        }

        public List<Order> Order { get; set; }       // Замовлення товару

        public Characteristics GetCharacteristics()  // Метод, який повертає клас характеристик
        {
            return new Characteristics() { here = Characteristics.Split("*") };
        }
    }

    public enum Category                            // Перерахування категорій товару
    {
        телевізори, програвачі, холодильники, пралки
    }

    public class Characteristics                     // Клас характеристик
    {
        public string[] here { get; set; }           // Поле, що зберігає масив характеристик


        public override string ToString()            // Перевантажений метод, який повертає строку характеристик через *
        {
            return String.Join("*", here);           
        }
    }
}
