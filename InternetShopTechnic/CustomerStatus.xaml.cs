using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using InternetShopTechnic.model;

namespace InternetShopTechnic
{
    /// <summary>
    /// Логика взаимодействия для CustomerStatus.xaml
    /// </summary>
    public partial class CustomerStatus : Window
    {
        public CustomerStatus(MyAppContext db, Customer customer)
        {
            InitializeComponent();

            var result = from Orders in db.Orders
                join Customer in db.Customer on Orders.CustomerId equals Customer.Id
                join Tovar in  db.Tovar on Orders.TovarId equals Tovar.Id 
                where Orders.CustomerId == customer.Id
                    select new
                    {
                        Date = Orders.Date.ToString("g"),
                        Customer = Customer.Name,
                        Tovar = Tovar.Name,
                        Number = Orders.Number,
                        Price = Math.Round(Tovar.Price * Orders.Number, 2),
                        DateAndAddress = Orders.DateAndAddress,
                        Status = Orders.Status

                    };

            statusList.ItemsSource = result.ToList();

        }

        private void CloseStatusWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
