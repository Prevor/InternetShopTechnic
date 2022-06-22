using InternetShopTechnic.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            ComboBoxCategory.SelectedItem = Category.пралки;
            this.tovar = item;

            // Перевірка на порожній об'єкт 
            if (tovar != null && tovar.Characteristics != null)
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
                ComboBoxCategory.IsEnabled = false;
                texBoxNumber.Text = tovar.Number.ToString();

                buttonTovar.Content = "Редагувати";
                LableHeader.Content = "Редагувати товар";
            }

        }
        
        // Додавання товару
        private void Button_Click_AddTovar(object sender, RoutedEventArgs e)
        {
            if (Validate_empty_box("boxTovar"))
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
                MessageBox.Show("Поля порожні!", "Помилка");
            }
        }

        // Вихід з вікна товару
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        // Вибір категорії товару
        private void ComboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Label> labels = new List<Label> { lable1, lable2, lable3, lable4 };
            string[] lableCharacPralki = new string[] { "Габарити", "Вага", "Макс. швидкість", "Завантаження" };
            string[] lableCharacHolod = new string[] { "Габарити", "Вага", "Об'єм камери", "Рівень шуму" };
            string[] lableCharacTv = new string[] { "Габарити", "Вага", "Діагональ", "Рік випуску" };
            string[] lableCharacProg = new string[] { "Габарити", "Вага", "Рік випуску", "HDMI" };


            switch (ComboBoxCategory.SelectedItem)
            {
                case Category.пралки:
                    for (int i = 0; i < labels.Count(); i++)
                    {
                        labels[i].Content = lableCharacPralki[i];
                    }

                    imageTovar.Source = new BitmapImage(new Uri("Images/washingMachine.png", UriKind.Relative));
                    break;
                case Category.холодильники:
                    for (int i = 0; i < labels.Count(); i++)
                    {
                        labels[i].Content = lableCharacHolod[i];
                    }
                    imageTovar.Source = new BitmapImage(new Uri("Images/refrigerator.png", UriKind.Relative));
                    break;
                case Category.телевізори:
                    for (int i = 0; i < labels.Count(); i++)
                    {
                        labels[i].Content = lableCharacTv[i];
                    }
                    imageTovar.Source = new BitmapImage(new Uri("Images/tv.png", UriKind.Relative));
                    break;
                case Category.програвачі:
                    for (int i = 0; i < labels.Count(); i++)
                    {
                        labels[i].Content = lableCharacProg[i];
                    }
                    imageTovar.Source = new BitmapImage(new Uri("Images/player.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }

        #region Validate Tovar

        // Метод, який повертає всі користувацькі елементи управління
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
        public bool Validate_empty_box(string tag)
        {
            return FindVisualChilds<TextBox>(this).Where(x => x.Tag != null && x.Tag.ToString() == tag).All(v => v.Text != string.Empty);
        }

        private bool Validate(Regex reg, string st)
        {
            return reg.IsMatch(st);
        }

        public void validateBox(Regex reg, TextBox tb, string st, Button bt)
        {
            if (Validate(reg, st))
            {
                tb.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 130, 0));
                tb.BorderThickness = new Thickness(0, 0, 0, 3);
                bt.IsEnabled = true;
            }
            else
            {
                tb.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                tb.BorderThickness = new Thickness(0, 0, 0, 3);
                bt.IsEnabled = false;
            }
        }

        private void texBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateBox(new Regex(@"^[A-Z a-z \W \- 0-9]{2,15}$"), texBoxName, texBoxName.Text, buttonTovar);
        }

        private void texBoxPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateBox(new Regex(@"^\d{4,5}(\,\d{1,2})?$"), texBoxPrice, texBoxPrice.Text, buttonTovar);
        }

        private void texBoxProduced_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateBox(new Regex(@"^[A-Za-z]{2,15}$"), texBoxProduced, texBoxProduced.Text, buttonTovar);
        }

        private void texBoxAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateBox(new Regex(@"^[A-Z \W a-z]{2,20}$"), texBoxAddress, texBoxAddress.Text, buttonTovar);
        }

        private void texBoxValue1_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateBox(new Regex(@"^[0-9x]{5,13}$"), texBoxValue1, texBoxValue1.Text, buttonTovar);
        }

        private void texBoxValue2_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateBox(new Regex(@"^[0-9 \,]{1,4}$"), texBoxValue2, texBoxValue2.Text, buttonTovar);
        }

        private void texBoxValue3_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateBox(new Regex(@"^[0-9]{1,4}$"), texBoxValue3, texBoxValue3.Text, buttonTovar);
        }

        private void texBoxValue4_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateBox(new Regex(@"^[0-9x]{1,9}$"), texBoxValue4, texBoxValue4.Text, buttonTovar);
        }

        private void texBoxNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateBox(new Regex(@"^[0-9]{1,2}$"), texBoxNumber, texBoxNumber.Text, buttonTovar);
        }
        #endregion
    }
}
