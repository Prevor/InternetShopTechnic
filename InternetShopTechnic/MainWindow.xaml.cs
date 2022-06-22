using Bogus;
using InternetShopTechnic.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InternetShopTechnic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyAppContext db;
        List<Label> labels;

        List<Customer> customers = new List<Customer>();
        List<Tovar> tovars = new List<Tovar>();
        List<Order> orders = new List<Order>();

        public MainWindow()
        {
            InitializeComponent();

            for (int n = 0; n < 20; n++)
            {
                var fakerCustomer = new Faker("uk");

                customers.Add(
                    new Customer
                    {
                        Name = fakerCustomer.Name.FirstName(Bogus.DataSets.Name.Gender.Male) + " " + fakerCustomer.Name.LastName(Bogus.DataSets.Name.Gender.Male),
                        Email = fakerCustomer.Person.Email,
                        Address = fakerCustomer.Person.Address.Street,
                        Phone = fakerCustomer.Phone.PhoneNumber("+3801########")
                    });
            }

            var fakerTovar = new Faker();
            tovars.Add(new Tovar { Name = "WHP60SF", Address = fakerTovar.Address.City(), Category = Category.пралки, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "60x85x50", "7", "1200", "55" } }.ToString(), Producer = "Gorenje", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "WW80R42LHFWD", Address = fakerTovar.Address.City(), Category = Category.пралки, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "60x85x45", "8", "1100", "55" } }.ToString(), Producer = "Samsung", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "TDLR 65230", Address = fakerTovar.Address.City(), Category = Category.пралки, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "40x90x60", "6", "1000", "55" } }.ToString(), Producer = "Whirlpool", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "F2J6HSR1W", Address = fakerTovar.Address.City(), Category = Category.пралки, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "59x85x46", "7", "1100", "54" } }.ToString(), Producer = "LG", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "IWUC 40851", Address = fakerTovar.Address.City(), Category = Category.пралки, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "60x85x45", "8", "1000", "55" } }.ToString(), Producer = "Indesit", Number = new Random().Next(0, 5) });

            tovars.Add(new Tovar { Name = "CNF289X", Address = fakerTovar.Address.City(), Category = Category.холодильники, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "186x59x68", "70", "341", "36" } }.ToString(), Producer = "Vestfrost", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "GA-B509SLSM", Address = fakerTovar.Address.City(), Category = Category.холодильники, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "178x59x66", "63", "311", "39" } }.ToString(), Producer = "LG", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "CW286W", Address = fakerTovar.Address.City(), Category = Category.холодильники, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 25000)), Characteristics = new Characteristics() { here = new[] { "203x60x66", "81", "400", "40" } }.ToString(), Producer = "Vestfrost", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "GA-B459SLCM", Address = fakerTovar.Address.City(), Category = Category.холодильники, Price = Convert.ToDouble(fakerTovar.Commerce.Price(40000, 55000)), Characteristics = new Characteristics() { here = new[] { "186x86x81", "121", "682", "42" } }.ToString(), Producer = "LG", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "RB29FSRNDSA", Address = fakerTovar.Address.City(), Category = Category.холодильники, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "203x59x65", "70", "400", "37" } }.ToString(), Producer = "SAMSUNG", Number = new Random().Next(0, 5) });

            tovars.Add(new Tovar { Name = "Mi TV P1 43", Address = fakerTovar.Address.City(), Category = Category.телевізори, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "611x973x187", "7,4", "43", "2021" } }.ToString(), Producer = "Xiaomi", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "Mi TV P1 55", Address = fakerTovar.Address.City(), Category = Category.телевізори, Price = Convert.ToDouble(fakerTovar.Commerce.Price(15000, 40000)), Characteristics = new Characteristics() { here = new[] { "1234x285x782", "11,9", "55", "2022" } }.ToString(), Producer = "Xiaomi", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "OLED55C1", Address = fakerTovar.Address.City(), Category = Category.телевізори, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "1228x251x738", "23", "55", "2021" } }.ToString(), Producer = "LG", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "UE43AU7100", Address = fakerTovar.Address.City(), Category = Category.телевізори, Price = Convert.ToDouble(fakerTovar.Commerce.Price(10000, 20000)), Characteristics = new Characteristics() { here = new[] { "963x627x192", "8,3", "43", "2020" } }.ToString(), Producer = "Samsung", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "XR-55X90J", Address = fakerTovar.Address.City(), Category = Category.телевізори, Price = Convert.ToDouble(fakerTovar.Commerce.Price(20000, 40000)), Characteristics = new Characteristics() { here = new[] { "1233x784x338", "17,4", "55", "2019" } }.ToString(), Producer = "Sony", Number = new Random().Next(0, 5) });

            tovars.Add(new Tovar { Name = "BDP-S3700", Address = fakerTovar.Address.City(), Category = Category.програвачі, Price = Convert.ToDouble(fakerTovar.Commerce.Price(3000, 5000)), Characteristics = new Characteristics() { here = new[] { "23x3x19", "0,8", "2017", "1" } }.ToString(), Producer = "Sony", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "DVP-SR760HPB", Address = fakerTovar.Address.City(), Category = Category.програвачі, Price = Convert.ToDouble(fakerTovar.Commerce.Price(1500, 2000)), Characteristics = new Characteristics() { here = new[] { "27x3x20", "0,95", "2015", "2" } }.ToString(), Producer = "Sony", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "Kardon BDS 2", Address = fakerTovar.Address.City(), Category = Category.програвачі, Price = Convert.ToDouble(fakerTovar.Commerce.Price(10000, 15000)), Characteristics = new Characteristics() { here = new[] { "10x40x26", "6,4", "2013", "1" } }.ToString(), Producer = "Harman", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "DV2X-227-DU", Address = fakerTovar.Address.City(), Category = Category.програвачі, Price = Convert.ToDouble(fakerTovar.Commerce.Price(1000, 1500)), Characteristics = new Characteristics() { here = new[] { "24x4x22", "1", "2015", "0" } }.ToString(), Producer = "Hyundai", Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "DN-V500BD", Address = fakerTovar.Address.City(), Category = Category.програвачі, Price = Convert.ToDouble(fakerTovar.Commerce.Price(15000, 20000)), Characteristics = new Characteristics() { here = new[] { "48x27x4", "2,7", "2016", "0" } }.ToString(), Producer = "Denon", Number = new Random().Next(0, 5) });

            for (int i = 0; i < 5; i++)
            {
                var fakerOrder = new Faker("uk");

                orders.Add(
                   new Order
                   {
                       Tovar = tovars[new Random().Next(0, tovars.Count())],
                       Date = fakerOrder.Date.Past(),
                       Customer = customers[new Random().Next(0, customers.Count())],
                       Status = Status.обробка,
                       Number = new Random().Next(1, 5),
                       DateAndAddress = fakerOrder.Address.City() + ", " + ((DateTime)fakerOrder.Date.Past()).ToString("g"),

                   });
                orders.Add(
                  new Order
                  {
                      Tovar = tovars[new Random().Next(0, tovars.Count())],
                      Date = fakerOrder.Date.Past(),
                      Customer = customers[new Random().Next(0, customers.Count())],
                      Status = Status.доставлено,
                      Number = new Random().Next(1, 5),
                      DateAndAddress = fakerOrder.Address.City() + ", " + ((DateTime)fakerOrder.Date.Past()).ToString("g"),
                  });
                orders.Add(
                  new Order
                  {
                      Tovar = tovars[new Random().Next(0, tovars.Count())],
                      Date = fakerOrder.Date.Past(),
                      Customer = customers[new Random().Next(0, customers.Count())],
                      Status = Status.зібрано,
                      Number = new Random().Next(1, 5),
                      DateAndAddress = fakerOrder.Address.City() + ", " + ((DateTime)fakerOrder.Date.Past()).ToString("g"),

                  });
            }

            db = new MyAppContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            db.Customer.AddRange(customers);
            db.Tovar.AddRange(tovars);
            db.Orders.AddRange(orders);
            db.SaveChanges();
        }

        // Метод виведення товарів, користувачів, замовлень
        public void Show()
        {
            // Виведення на ListViewe товару
            tovarList.ItemsSource = db.Tovar.ToList();

            // Виведення на ListViewe користувачів
            customerList.ItemsSource = db.Customer.ToList();

            // Виведення на ListViewe ордерів
            var result = from p in db.Orders
                         join c in db.Customer on p.CustomerId equals c.Id
                         join t in db.Tovar on p.TovarId equals t.Id
                         select new
                         {
                             Date = p.Date.ToString("d"),
                             Customer = c.Name,
                             Status = p.Status,
                             Tovar = t.Name,
                             Price = Math.Round(t.Price * p.Number, 2),
                             Number = p.Number,
                             DateAndAddress = p.DateAndAddress,
                         };
            orderList.ItemsSource = result.ToList();
        }

        // Метод обробки форми 
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Show();

            // Додавання в ComboBox категорій товару
            ComboBoxCategory.ItemsSource = Enum.GetValues(typeof(Category));

            // Додавання в ComboBox виробників
            ComboBoxProducer.ItemsSource = db.Tovar.Select(t => t.Producer).Distinct().ToList();
        }

        #region Customer

        // Локальна змінна для зберігання вибраного користувача
        Customer selCust = null;

        // Додавання нового користувача
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            CustomerWindow customerWindow = new CustomerWindow(new Customer());

            customerWindow.LableHeader.Content = "Додавання користувача";
            customerWindow.buttonCustomer.Content = "Додати";

            if (customerWindow.ShowDialog() == true)
            {
                db.Customer.Add(customerWindow.customer);
                db.SaveChanges();
                Show();
                MessageBox.Show("Користувача успішно додано до списку користувачів!");
            }
        }

        // Видалення користувача 
        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {
            selCust = (Customer)customerList.SelectedItem;

            if (selCust != null)
            {
                db.Customer.Remove(selCust);
                db.SaveChanges();
                Show();
            }

            customerList.SelectedIndex = 0;
        }

        // Редагування даних користувача
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            selCust = (Customer)customerList.SelectedItem;

            if (selCust != null)
            {
                CustomerWindow customerWindow = new CustomerWindow(selCust);

                if (customerWindow.ShowDialog() == true)
                {
                    db.Customer.Update(customerWindow.customer);
                    db.SaveChanges();
                    Show();
                }
            }
        }

        // Статус замовлень 
        private void Button_Click_Check(object sender, RoutedEventArgs e)
        {
            selCust = (Customer)customerList.SelectedItem;

            if (selCust != null)
            {
                CustomerStatus customerStatus = new CustomerStatus(db, selCust);
                customerStatus.Show();
            }
        }

        #endregion

        #region Tovar

        // Локальна змінна для зберігання вибраного товару
        Tovar selTov = null;

        // Відображення вибраних характеристик товару
        private void tovarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selTov = (Tovar)tovarList.SelectedItem;

            labels = new List<Label> { lable1, lable2, lable3, lable4 };

            string[] lableCharacPralki = new string[] { "Габарити", "Вага", "Макс. швидкість", "Завантаження" };
            string[] lableCharacHolod = new string[] { "Габарити", "Вага", "Об'єм камери", "Рівень шуму" };
            string[] lableCharacTv = new string[] { "Габарити", "Вага", "Діагональ", "Рік випуску" };
            string[] lableCharacProg = new string[] { "Габарити", "Вага", "Рік випуску", "HDMI" };

            if (selTov != null)
            {
                var item = selTov.GetCharacteristics();

                Characteristic1.Text = item.here[0];
                Characteristic2.Text = item.here[1];
                Characteristic3.Text = item.here[2];
                Characteristic4.Text = item.here[3];

                switch (selTov.Category)
                {
                    case Category.пралки:
                        for (int i = 0; i < labels.Count(); i++)
                        {
                            labels[i].Content = lableCharacPralki[i];
                        }
                        ComboBoxCharacteristics.ItemsSource = lableCharacPralki;
                        break;
                    case Category.холодильники:
                        for (int i = 0; i < labels.Count(); i++)
                        {
                            labels[i].Content = lableCharacHolod[i];
                        }
                        ComboBoxCharacteristics.ItemsSource = lableCharacHolod;
                        break;
                    case Category.телевізори:
                        for (int i = 0; i < labels.Count(); i++)
                        {
                            labels[i].Content = lableCharacTv[i];
                        }
                        ComboBoxCharacteristics.ItemsSource = lableCharacTv;
                        break;
                    case Category.програвачі:
                        for (int i = 0; i < labels.Count(); i++)
                        {
                            labels[i].Content = lableCharacProg[i];
                        }
                        ComboBoxCharacteristics.ItemsSource = lableCharacProg;
                        break;
                    default:
                        break;
                }
            }
        }

        //Cписку товарів за категоріями
        private void ComboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxCategory.SelectedValue != null)
            {
                tovarList.ItemsSource = tovars.Where(t =>
                        t.Category == (Category)Enum.Parse(typeof(Category), ComboBoxCategory.SelectedValue.ToString()))
                    .ToList();

            }

            Characteristic1.Text = String.Empty;
            Characteristic2.Text = String.Empty;
            Characteristic3.Text = String.Empty;
            Characteristic4.Text = String.Empty;

            if (labels != null)
            {
                labels.Clear();
            }

            ComboBoxCharacteristics.IsEnabled = false;
            ComboBoxProducer.IsEnabled = false;
            CheckBoxAvailable.IsEnabled = false;
        }

        //Cписку товарів за виробниками
        private void ComboBoxProducer_SelectionProducer(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxProducer.SelectedItem != null)
            {
                tovarList.ItemsSource = tovars.Where(t => t.Producer == ComboBoxProducer.SelectedItem.ToString()).ToList();
            }

            ComboBoxCategory.IsEnabled = false;
            ComboBoxCharacteristics.IsEnabled = false;
            CheckBoxAvailable.IsEnabled = false;
        }

        // Відображення товару, який є в наявності 
        private void CheckBoxAvailable_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxAvailable.IsChecked == true)
            {
                tovarList.ItemsSource = tovars.Where(t => t.Available == true).ToList();
                ComboBoxCategory.IsEnabled = false;
                ComboBoxCharacteristics.IsEnabled = false;
                ComboBoxProducer.IsEnabled = false;
            }
            else if (CheckBoxAvailable.IsChecked == false)
            {
                tovarList.ItemsSource = db.Tovar.ToList();
                ComboBoxCategory.IsEnabled = true;
                ComboBoxCharacteristics.IsEnabled = true;
                ComboBoxProducer.IsEnabled = true;
            }

        }

        // Додавання товару
        private void Button_Click_AddTovar(object sender, RoutedEventArgs e)
        {
            TovarWindow tovarWindow = new TovarWindow(new Tovar());
            tovarWindow.ComboBoxCategory.SelectedItem = Category.пралки;

            if (tovarWindow.ShowDialog() == true)
            {
                db.Tovar.Add(tovarWindow.tovar);
                db.SaveChanges();
                tovarList.ItemsSource = db.Tovar.ToList();
                MessageBox.Show("Товар успішно додано до списку товарів!");
            }
        }

        // Редагування товару
        private void Button_Click_EditTovar(object sender, RoutedEventArgs e)
        {
            selTov = (Tovar)tovarList.SelectedItem;

            if (selTov != null)
            {
                TovarWindow tovarWindow = new TovarWindow(selTov);

                if (tovarWindow.ShowDialog() == true)
                {
                    db.Tovar.Update(tovarWindow.tovar);
                    db.SaveChanges();
                    Show();
                }
            }
            else
            {
                MessageBox.Show("Виберіть товар!");
            }
        }

        // Видалення товару
        private void Button_Click_RemoveTovar(object sender, RoutedEventArgs e)
        {
            selTov = (Tovar)tovarList.SelectedItem;

            if (selTov != null)
            {
                db.Tovar.Remove(selTov);
                db.SaveChanges();
                Show();
            }
            else
            {
                MessageBox.Show("Виберіть товар!");
            }

            tovarList.SelectedIndex = 0;
        }

        // Метод отримання товару за габаритами
        public int GetOBJEM(string str)
        {
            int result = 1;
            var array = str.Split('x');
            for (int i = 0; i < array.Length; i++)
            {
                result *= Convert.ToInt32(array[i]);
            }

            return result;
        }

        public List<Tovar> SortTovar(Tovar tovar, int index) => index switch
        {
            2 => tovars.Where(t => t.Category == tovar.Category).OrderByDescending(t => Convert.ToInt32(t.GetCharacteristics().here[index])).ToList(),
            3 => tovars.Where(t => t.Category == tovar.Category).OrderByDescending(t => Convert.ToInt32(t.GetCharacteristics().here[index])).ToList(),
            1 => tovars.Where(t => t.Category == tovar.Category).OrderByDescending(t => Convert.ToDouble(t.GetCharacteristics().here[index])).ToList(),
            0 => tovars.Where(t => t.Category == tovar.Category).OrderByDescending(t => GetOBJEM(t.GetCharacteristics().here[index])).ToList(),
            _ => db.Tovar.ToList()
        };

        //Cписку товарів за характеристиками
        private void ComboBoxProducer_SelectionCharacteristics(object sender, SelectionChangedEventArgs e)
        {
            selTov = (Tovar)tovarList.SelectedItem;
            if (selTov != null)
            {
                tovarList.ItemsSource = SortTovar(selTov, ComboBoxCharacteristics.SelectedIndex);
                ComboBoxCategory.SelectedItem = null;
            }

            ComboBoxCategory.IsEnabled = false;
            ComboBoxProducer.IsEnabled = false;
            CheckBoxAvailable.IsEnabled = false;
        }

        // Оформлення замовлення
        private void Button_Click_Order(object sender, RoutedEventArgs e)
        {
            selTov = (Tovar)tovarList.SelectedItem;

            if (selTov != null)
            {
                OrderWindow orderWindow = new OrderWindow();

                orderWindow.textBoxTovar.Text = selTov.Name;
                orderWindow.ComboBoxCustomer.ItemsSource = db.Customer.Select(c => c.Name).Distinct().ToList();
                orderWindow.DataEndTime.Text = DateTime.Now.ToString();
                orderWindow.textBoxNumber.Text = 1.ToString();
                orderWindow.TextBoxPrice.Text = Math.Round(Convert.ToDouble(orderWindow.textBoxNumber.Text) * selTov.Price, 2).ToString();

                if (orderWindow.ShowDialog() == true)
                {
                    orders.Add(
                        new Order
                        {
                            Tovar = selTov,
                            Date = DateTime.Now,
                            Customer = db.Customer.Where(c => c.Name == orderWindow.ComboBoxCustomer.SelectedItem).SingleOrDefault(),
                            Number = Convert.ToInt32(orderWindow.textBoxNumber.Text),
                            DateAndAddress = orderWindow.textBoxAddress.Text + ", " + orderWindow.DateToOrder.Text,
                            Status = Status.обробка
                        });

                    db.Orders.Add(orders.Last());
                    db.SaveChanges();
                    Show();
                    MessageBox.Show("Замовлення оформлено і знаходиться в обробці!");
                }
            }
            else
            {
                MessageBox.Show("Товар не вибрано!");
            }
        }

        // Скидання сортування за замовчуванням
        private void Button_Click_Default(object sender, RoutedEventArgs e)
        {
            tovarList.ItemsSource = db.Tovar.ToList();
            ComboBoxCategory.SelectedItem = default;
            ComboBoxProducer.SelectedItem = default;
            ComboBoxCharacteristics.SelectedItem = default;
            ComboBoxCategory.IsEnabled = true;
            ComboBoxCharacteristics.IsEnabled = true;
            ComboBoxProducer.IsEnabled = true;
            CheckBoxAvailable.IsEnabled = true;
            Characteristic1.Text = String.Empty;
            Characteristic2.Text = String.Empty;
            Characteristic3.Text = String.Empty;
            Characteristic4.Text = String.Empty;

            if (labels != null)
            {
                labels.Clear();
            }
        }

        #endregion

        // Вихід
        private void CloseMainWindow(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        // Мереміщення вікна
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

    }
}
