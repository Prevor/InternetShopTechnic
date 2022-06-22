using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InternetShopTechnic.model
{
    public class Customer                           // Клас "Користувач"                     
    {                                               
        public int Id { get; set; }                 // Унікальний ID користувача
        public string Name { get; set; }            // Ім'я та прізвище користувача
        public string Address { get; set; }         // Адреса користувача
        public string Phone { get; set; }           // Телефон користувача
        public string Email { get; set; }           // Електронна адреса користувача
        public List<Order> Order { get; set; }      // Замовлення користувача

    }
}
