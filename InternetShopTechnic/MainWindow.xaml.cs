using Bogus;
using InternetShopTechnic.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
                        Phone = fakerCustomer.Person.Phone
                    });
            }

            var fakerTovar = new Faker();
            tovars.Add(new Tovar { Name = "Gorenje WHP60SF", Address = fakerTovar.Address.City(), Category = Category.пралки, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "60x85x50", "7", "1200", "55" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "Samsung WW80R42LHFWD", Address = fakerTovar.Address.City(), Category = Category.пралки, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "60x85x45", "8", "1100", "55" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "Whirlpool TDLR 65230", Address = fakerTovar.Address.City(), Category = Category.пралки, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "40x90x60", "6", "1000", "55" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "LG F2J6HSR1W", Address = fakerTovar.Address.City(), Category = Category.пралки, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "59x85x46", "7", "1100", "54" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "Indesit IWUC 40851", Address = fakerTovar.Address.City(), Category = Category.пралки, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "60x85x45", "8", "1000", "55" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });

            tovars.Add(new Tovar { Name = "Vestfrost CNF289X", Address = fakerTovar.Address.City(), Category = Category.холодильники, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "186x59x68", "70", "341", "36" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "LG GA-B509SLSM", Address = fakerTovar.Address.City(), Category = Category.холодильники, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "178x59x66", "63", "311", "39" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "Vestfrost CW286W", Address = fakerTovar.Address.City(), Category = Category.холодильники, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 25000)), Characteristics = new Characteristics() { here = new[] { "203x60x66", "81", "400", "40" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "LG GA-B459SLCM", Address = fakerTovar.Address.City(), Category = Category.холодильники, Price = Convert.ToDouble(fakerTovar.Commerce.Price(40000, 55000)), Characteristics = new Characteristics() { here = new[] { "186x86x81", "121", "682", "42" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "SAMSUNG RB29FSRNDSA", Address = fakerTovar.Address.City(), Category = Category.холодильники, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "203x59x65", "70", "400", "37" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });

            tovars.Add(new Tovar { Name = "Xiaomi Mi TV P1 43", Address = fakerTovar.Address.City(), Category = Category.телевізори, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "611x973x187", "7,4", "43", "1920x1080" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "Xiaomi Mi TV P1 55", Address = fakerTovar.Address.City(), Category = Category.телевізори, Price = Convert.ToDouble(fakerTovar.Commerce.Price(15000, 40000)), Characteristics = new Characteristics() { here = new[] { "1234x285x782", "11,9", "55", "3840x2160" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "LG OLED55C1", Address = fakerTovar.Address.City(), Category = Category.телевізори, Price = Convert.ToDouble(fakerTovar.Commerce.Price(5000, 20000)), Characteristics = new Characteristics() { here = new[] { "1228x251x738", "23", "55", "3840x2160" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "Samsung UE43AU7100", Address = fakerTovar.Address.City(), Category = Category.телевізори, Price = Convert.ToDouble(fakerTovar.Commerce.Price(10000, 20000)), Characteristics = new Characteristics() { here = new[] { "963x627x192", "8,3", "43", "3840x2160" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "Sony XR-55X90J", Address = fakerTovar.Address.City(), Category = Category.телевізори, Price = Convert.ToDouble(fakerTovar.Commerce.Price(20000, 40000)), Characteristics = new Characteristics() { here = new[] { "1233x784x338", "17,4", "55", "3840x2160" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });

            tovars.Add(new Tovar { Name = "Sony BDP-S3700", Address = fakerTovar.Address.City(), Category = Category.програвачі, Price = Convert.ToDouble(fakerTovar.Commerce.Price(3000, 5000)), Characteristics = new Characteristics() { here = new[] { "23x3x19", "0,8", "2017", "1" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "Sony DVP-SR760HPB", Address = fakerTovar.Address.City(), Category = Category.програвачі, Price = Convert.ToDouble(fakerTovar.Commerce.Price(1500, 2000)), Characteristics = new Characteristics() { here = new[] { "27x3x20", "0,95", "2015", "2" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "Harman/Kardon BDS 2", Address = fakerTovar.Address.City(), Category = Category.програвачі, Price = Convert.ToDouble(fakerTovar.Commerce.Price(10000, 15000)), Characteristics = new Characteristics() { here = new[] { "10x40x26", "6,4", "2013", "1" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "Hyundai DV2X-227-DU", Address = fakerTovar.Address.City(), Category = Category.програвачі, Price = Convert.ToDouble(fakerTovar.Commerce.Price(1000, 1500)), Characteristics = new Characteristics() { here = new[] { "24x4x22", "1", "2015", "0" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            tovars.Add(new Tovar { Name = "Denon DN-V500BD", Address = fakerTovar.Address.City(), Category = Category.програвачі, Price = Convert.ToDouble(fakerTovar.Commerce.Price(15000, 20000)), Characteristics = new Characteristics() { here = new[] { "48x27x4", "2,7", "2016", "0" } }.ToString(), Producer = fakerTovar.Company.CompanyName(), Number = new Random().Next(0, 5) });
            
            for (int i = 0; i < 5; i++)
            {
                var fakerOrder = new Faker("uk");

                orders.Add(
                   new Order
                   {
                       Tovar = tovars[new Random().Next(0, tovars.Count())],
                       Date = fakerOrder.Date.Past(),
                       Customer = customers[new Random().Next(0, customers.Count())],
                       Status = Status.processing,
                       Number = new Random().Next(1, 5),
                       DateAndAddress = fakerOrder.Address.City() + ", " + fakerOrder.Date.Future().DayOfYear

                   });
                orders.Add(
                  new Order
                  {
                      Tovar = tovars[new Random().Next(0, tovars.Count())],
                      Date = fakerOrder.Date.Past(),
                      Customer = customers[new Random().Next(0, customers.Count())],
                      Status = Status.delivered,
                      Number = new Random().Next(1, 5),
                      DateAndAddress = fakerOrder.Address.City() + ", " + fakerOrder.Date.Future().Day
                  });
                orders.Add(
                  new Order
                  {
                      Tovar = tovars[new Random().Next(0, tovars.Count())],
                      Date = fakerOrder.Date.Past(),
                      Customer = customers[new Random().Next(0, customers.Count())],
                      Status = Status.assembled,
                      Number = new Random().Next(1, 5),
                      DateAndAddress = fakerOrder.Address.City() + ", " + fakerOrder.Date.Future().Day

                  });
            }

            db = new MyAppContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            //db.Customer.AddRange(customers);
            //db.Tovar.AddRange(tovars);
            //db.Orders.AddRange(orders);
            db.SaveChanges();
        }

        public void Show()
        {
            // Виведення на ListViewe товару
            tovarList.ItemsSource = db.Tovar.ToList();

            // Виведення на ListViewe користувачів
            var custResult = (from o in db.Orders
                              join c in db.Customer on o.CustomerId equals c.Id

                              select new
                              {
                                  Name = c.Name,
                                  Address = c.Address,
                                  Email = c.Email,
                                  Phone = c.Phone,
                                  Order = db.Orders.Where(q => q.CustomerId == c.Id).Count()
                              }).Distinct();
            customerList.ItemsSource = custResult.ToList();

            // Виведення на ListViewe ордерів
            var result = from p in db.Orders
                         join c in db.Customer on p.CustomerId equals c.Id
                         join t in db.Tovar on p.TovarId equals t.Id
                         select new
                         {
                             Date = p.Date,
                             Customer = c.Name,
                             Status = p.Status,
                             Tovar = t.Name,
                             Price = Math.Round(t.Price * p.Number, 2),
                             Number = p.Number,
                             DateAndAddress = p.DateAndAddress,
                         };
            orderList.ItemsSource = result.ToList();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Show();

            // Додавання в ComboBox категорій товару
            ComboBoxCategory.ItemsSource = Enum.GetValues(typeof(Category));

            // Додавання в ComboBox виробників
            ComboBoxProducer.ItemsSource = db.Tovar.Select(t => t.Producer).Distinct().ToList();
        }

        #region Customer

        Customer selCust = null;

        // Додавання нового користувача
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            db.Customer.Add(new Customer { Name = textBoxName.Text, Address = textBoxAddress.Text, Phone = textBoxPhone.Text, Email = textBoxEmail.Text });
            db.SaveChanges();
            Show();
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

        // Відображення користувача в полях та очищення полів, якщо користувачі відсутні 
        private void customerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selCust = (Customer)customerList.SelectedItem;

            textBoxName.Text = String.Empty;
            textBoxAddress.Text = String.Empty;
            textBoxEmail.Text = String.Empty;
            textBoxPhone.Text = String.Empty;

            if (selCust != null)
            {
                textBoxName.Text = selCust.Name;
                textBoxAddress.Text = selCust.Address;
                textBoxEmail.Text = selCust.Email;
                textBoxPhone.Text = selCust.Phone;
            }
        }

        // Редагування даних користувача
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            selCust = (Customer)customerList.SelectedItem;

            if (selCust != null)
            {
                selCust.Name = textBoxName.Text;
                selCust.Address = textBoxAddress.Text;
                selCust.Email = textBoxEmail.Text;
                selCust.Phone = textBoxPhone.Text;

                db.Customer.Update(selCust);
                db.SaveChanges();
                Show();
            }
        }

        #endregion

        #region Tovar

        Tovar selTov = null;

        // Відображення вибраних характеристик товару
        private void tovarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selTov = (Tovar)tovarList.SelectedItem;

            labels = new List<Label> { lable1, lable2, lable3, lable4 };

            string[] lableCharacPralki = new string[] { "Габарити", "Вага", "Макс. швидкість", "Завантаження" };
            string[] lableCharacHolod = new string[] { "Габарити", "Вага", "Об'єм камери", "Рівень шуму" };
            string[] lableCharacTv = new string[] { "Габарити", "Вага", "Діагональ", "Роздільна здатність" };
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
            switch (ComboBoxCategory.SelectedItem)
            {
                case Category.пралки:
                    var result = db.Tovar.Where(t => t.Category == Category.пралки).ToList();
                    tovarList.ItemsSource = result;
                    break;
                case Category.холодильники:
                    result = db.Tovar.Where(t => t.Category == Category.холодильники).ToList();
                    tovarList.ItemsSource = result;
                    break;
                case Category.телевізори:
                    result = db.Tovar.Where(t => t.Category == Category.телевізори).ToList();
                    tovarList.ItemsSource = result;
                    break;
                case Category.програвачі:
                    result = db.Tovar.Where(t => t.Category == Category.програвачі).ToList();
                    tovarList.ItemsSource = result;
                    break;
                default:
                    break;
            }

            Characteristic1.Text = String.Empty;
            Characteristic2.Text = String.Empty;
            Characteristic3.Text = String.Empty;
            Characteristic4.Text = String.Empty;

            labels.Clear();
        }

        //Cписку товарів за виробниками
        private void ComboBoxProducer_SelectionProducer(object sender, SelectionChangedEventArgs e)
        {
            var result = db.Tovar.Where(t => t.Producer == ComboBoxProducer.SelectedItem.ToString()).ToList();
            tovarList.ItemsSource = result;
        }

        // Додавання товару
        private void Button_Click_AddTovar(object sender, RoutedEventArgs e)
        {
            TovarWindow tovarWindow = new TovarWindow(new Tovar());

            if (tovarWindow.ShowDialog() == true)
            {
                db.Tovar.Add(tovarWindow.tovar);
                db.SaveChanges();
                tovarList.ItemsSource = db.Tovar.ToList();
            }
        }

        // Редагування товару
        private void Button_Click_EditTovar(object sender, RoutedEventArgs e)
        {
            selTov = (Tovar)tovarList.SelectedItem;
            TovarWindow tovarWindow = new TovarWindow(selTov);

            if (tovarList.SelectedItem != null)
            {
                if (tovarWindow.ShowDialog() == true)
                {
                    db.Tovar.Update(tovarWindow.tovar);
                    db.SaveChanges();
                    Show();
                }
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

            customerList.SelectedIndex = 0;
        }


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
            0 => tovars.Where(t => t.Category == tovar.Category).OrderByDescending(t => GetOBJEM(t.GetCharacteristics().here[index])).ToList(),
            1 => tovars.Where(t => t.Category == tovar.Category).OrderByDescending(t => Convert.ToDouble(t.GetCharacteristics().here[index])).ToList(),
            2 => tovars.Where(t => t.Category == tovar.Category).OrderByDescending(t => Convert.ToInt32(t.GetCharacteristics().here[index])).ToList(),
            3 => tovars.Where(t => t.Category == tovar.Category).OrderByDescending(t => Convert.ToInt32(t.GetCharacteristics().here[index])).ToList(),
            _ => db.Tovar.ToList()
        };

        //Cписку товарів за характеристиками
        private void ComboBoxProducer_SelectionCharacteristics(object sender, SelectionChangedEventArgs e)
        {
            tovarList.ItemsSource = SortTovar(selTov, ComboBoxCharacteristics.SelectedIndex);
            ComboBoxCategory.SelectedItem = null;
        }

        private void Button_Click_Order(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();

            selTov = (Tovar)tovarList.SelectedItem;

            orderWindow.textBoxTovar.Text = selTov.Name;
            orderWindow.ComboBoxCustomer.ItemsSource = db.Customer.Select(c => c.Name).Distinct().ToList();
            orderWindow.DataEndTime.Text = DateTime.Now.ToString();
            orderWindow.textBoxNumber.Text = 1.ToString();
            orderWindow.TextBoxPrice.Text = Math.Round(Convert.ToDouble(orderWindow.textBoxNumber.Text) * selTov.Price, 2).ToString();

            if (selTov != null)
            {
                orderWindow.ShowDialog();
                
                if (!orderWindow.buttonToOrder.IsCancel)
                {
                    orders.Add(
                        new Order
                        {
                            Tovar = selTov,
                            Date = DateTime.Now,
                            Customer = db.Customer.Where(c => c.Name == orderWindow.ComboBoxCustomer.SelectedItem).SingleOrDefault(),
                            Number = Convert.ToInt32(orderWindow.textBoxNumber.Text),

                            DateAndAddress = orderWindow.textBoxAddress.Text + ", " + orderWindow.DateToOrder.Text,
                            Status = Status.processing
                        });


                    db.Orders.Add(orders.Last());
                    db.SaveChanges();
                    Show();
                }
            }
            else
            {
                MessageBox.Show("Error", "Товар не вибрано!", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        private void Button_Click_Check(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Default(object sender, RoutedEventArgs e)
        {
            tovarList.ItemsSource = db.Tovar.ToList();
            ComboBoxCategory.SelectedItem = null;
            ComboBoxProducer.SelectedItem = null;
            ComboBoxCharacteristics.SelectedItem = null;
        }

        #endregion

    }
}
