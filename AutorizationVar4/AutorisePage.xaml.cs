			using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutorizationVar4
{
    /// <summary>
    /// Логика взаимодействия для AutorisePage.xaml
    /// </summary>
    /// 
   
    public partial class AutorisePage : Page
    {
        var4Entities3 var4Entities4;
        public AutorisePage()
        {
            InitializeComponent();
            var4Entities4 = new var4Entities3();
        }

        int count = 0;
        private void GoMain(object sender, RoutedEventArgs e)
        {

            int login = Convert.ToInt32(inputLogin.Text);
            string password = inputPassword.Text;
            if (var4Entities4.Employer.Any(x => x.tabNum == login))
            {
                Employer employer = var4Entities4.Employer.ToList().Find(x => x.tabNum == login);
                if (employer.password.Equals(inputPassword.Text))
                {
                    MessageBox.Show("Добро пожаловать");
                    NavigationService.Navigate(new MainPage());
                }
                else
                {
                    MessageBox.Show("Неверные входные данные");
                    count++;
                }
            }
            else
            {
                MessageBox.Show("Неверные входные данные");
                count++;
            }
            if (count >= 3)
            {
                check.Visibility = Visibility.Visible;
            }
        }

        private void GoPodskazka(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PodskazkaPage());
        }
    }
}
