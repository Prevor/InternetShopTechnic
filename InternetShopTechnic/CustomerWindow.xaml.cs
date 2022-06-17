using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public Customer customer;

        public CustomerWindow(Customer item)
        {
            InitializeComponent();

            this.customer = item;
            
            if (customer != null)
            {
                textBoxName.Text = customer.Name;
                textBoxAddress.Text = customer.Address;
                textBoxPhone.Text = customer.Phone;
                textBoxEmail.Text = customer.Email;

                buttonCustomer.Content = "Редагувати";
                LableHeader.Content = "Редагування користувача";
            }
        }
        
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_AddCustomer(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != String.Empty && textBoxAddress.Text != String.Empty && textBoxPhone.Text != String.Empty && textBoxEmail.Text != String.Empty)
            {
                this.customer.Name = textBoxName.Text;
                this.customer.Address = textBoxAddress.Text;
                this.customer.Phone = textBoxPhone.Text;
                this.customer.Email = textBoxEmail.Text;
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Поля порожні!");
            }
            
        }

        private TovarWindow tovarWindow = new TovarWindow(null);

        private void textBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            tovarWindow.validateBox(new Regex(@"^[A-Z a-z \W \- 0-9 А-Яа-яёЁЇїІіЄєҐґ]{2,30}$"), textBoxName, textBoxName.Text, buttonCustomer);
        }

        private void textBoxAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            tovarWindow.validateBox(new Regex(@"^[А-Яа-яёЁЇїІіЄєҐґA-Za-z\W\,\.\d]{2,30}$"), textBoxAddress, textBoxAddress.Text, buttonCustomer);
        }

        private void textBoxPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            tovarWindow.validateBox(new Regex(@"^(?:\+38)?(0[1-9][0-9]\d{7})$"), textBoxPhone, textBoxPhone.Text, buttonCustomer);
        }

        private void textBoxEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            tovarWindow.validateBox(new Regex(@"[a-z0-9]+@[a-z\-]+\.[a-z]{2,3}"), textBoxEmail, textBoxEmail.Text, buttonCustomer);
        }
    }
}
