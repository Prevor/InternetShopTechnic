using InternetShopTechnic.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace InternetShopTechnic
{
    /// <summary>
    /// Логика взаимодействия для TovarWindow.xaml
    /// </summary>
    public partial class TovarWindow : Window
    {
        public Tovar tovar;

        public TovarWindow(Tovar item)
        {
            InitializeComponent();

            ComboBoxCategory.ItemsSource = Enum.GetValues(typeof(Category));

            this.tovar = item;

            // Перевірка на порожній об'єкт 
            if (tovar.Id != 0)
            {
                var characteristic = tovar.GetCharacteristics();

                texBoxValue1.Text = characteristic.here[0];
                texBoxValue2.Text = characteristic.here[1];
                texBoxValue3.Text = characteristic.here[2];
                texBoxValue4.Text = characteristic.here[3];

                texBoxName.Text = tovar.Name;
                texBoxAddress.Text = tovar.Address;
                texBoxProduced.Text = tovar.Producer;
                texBoxPrice.Text = tovar.Price.ToString();
                ComboBoxCategory.SelectedValue = tovar.Category;
                texBoxNumber.Text = tovar.Number.ToString();

                buttonTovar.Content = "Редагувати";
                LableHeader.Content = "Редагувати товар";
            }


        }
        

        public static IEnumerable<T> FindVisualChilds<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChilds<T>(ithChild)) yield return childOfChild;
            }
        }

        // Перевірка на порожнє поле
        private bool Validate_empty_box()
        {
            return FindVisualChilds<TextBox>(this).Where(x => x.Tag != null && x.Tag.ToString() == "box").All(v => v.Text != string.Empty);
        }

        private void Button_Click_AddTovar(object sender, RoutedEventArgs e)
        {
            if (Validate_empty_box())
            {
                this.tovar.Name = texBoxName.Text;
                this.tovar.Category = (Category)ComboBoxCategory.SelectedValue;
                this.tovar.Address = texBoxAddress.Text;
                this.tovar.Producer = texBoxProduced.Text;
                this.tovar.Price = Convert.ToDouble(texBoxPrice.Text);
                this.tovar.Characteristics = new Characteristics() { here = new[] { texBoxValue1.Text, texBoxValue2.Text, texBoxValue3.Text, texBoxValue4.Text } }.ToString();
                this.tovar.Number = Convert.ToInt32(texBoxNumber.Text);
                this.DialogResult = true;
                this.Close();

            }
            else
            {
                MessageBox.Show("Error", "");
            }


        }


        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
