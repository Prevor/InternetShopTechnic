using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace InternetShopTechnic
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();

        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonToOrder_Click(object sender, RoutedEventArgs e)
        {
            if (tovarWindow.Validate_empty_box("boxOrder") && ComboBoxCustomer.SelectedIndex != -1)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Поля порожні!");
            }
        }

        #region Validate Order

        private TovarWindow tovarWindow = new TovarWindow(null);

        private void textBoxNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            tovarWindow.validateBox(new Regex(@"^[1-9]{1,2}$"), textBoxNumber, textBoxNumber.Text, buttonToOrder);
        }

        private void TextBoxPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            tovarWindow.validateBox(new Regex(@"^\d{4,6}(\,\d{1,2})?$"), TextBoxPrice, TextBoxPrice.Text, buttonToOrder);
        }

        private void textBoxAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            tovarWindow.validateBox(new Regex(@"^[A-Z /W a-z]{2,30}$"), textBoxAddress, textBoxAddress.Text, buttonToOrder);
        }

        private void DateToOrder_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (DateToOrder.Text != String.Empty)
            {
                buttonToOrder.IsEnabled = true;
                DateToOrder.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 130, 0));
                DateToOrder.BorderThickness = new Thickness(0, 0, 0, 3);
            }
            else
            {
                buttonToOrder.IsEnabled = false;
                DateToOrder.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                DateToOrder.BorderThickness = new Thickness(0, 0, 0, 3);
            }
        }
        
        private void ComboBoxCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxCustomer.SelectedIndex != -1)
            {
                buttonToOrder.IsEnabled = true;
                ComboBoxCustomer.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 130, 0));
                ComboBoxCustomer.BorderThickness = new Thickness(0, 0, 0, 3);
            }
            else
            {
                buttonToOrder.IsEnabled = false;
                ComboBoxCustomer.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                ComboBoxCustomer.BorderThickness = new Thickness(0, 0, 0, 3);
            }
        }


        #endregion
        
    }
}
