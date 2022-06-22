using System;

namespace InternetShopTechnic.model
{
    public class Order                                // Клас "Ордер"   
    {
        public int Id { get; set; }                   // Унікальний ID замовлення
        public DateTime Date { get; set; }            // Дата створення замовлення
        public int TovarId { get; set; }              // Зовнішній ключ з Товаром
        public Tovar Tovar { get; set; }              // Товар в замовленні 
        public int CustomerId { get; set; }           // Зовнішній ключ з Користувачем
        public Customer Customer { get; set; }        // Користувач в замовленні
        public int Number { get; set; }               // Кількість замовлень
        public Status Status { get; set; }            // Статус замовлень 
        public string DateAndAddress { get; set; }    // Дата і адреса доставки
    }

    public enum Status                                // Перерахування статусів замовлень
    {
        обробка, зібрано, доставлено
    }
}
