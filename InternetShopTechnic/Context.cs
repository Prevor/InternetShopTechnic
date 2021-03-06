using InternetShopTechnic.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InternetShopTechnic
{
    public class MyAppContext : DbContext
    {
        // Поля для доступу в базі даних сутностей: товару, користувача, ордерів 
        public DbSet<Tovar> Tovar { get; set; }         
        public DbSet<Customer> Customer { get;  set; }  
        public DbSet<Order> Orders { get;  set; }      

        // Конфігурація підключення 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB;Trusted_Connection=True;");
        }

    }
}
