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
    /// Логика взаимодействия для PodskazkaPage.xaml
    /// </summary>
    public partial class PodskazkaPage : Page
    {
        var4Entities3 var4Entities4;
        public PodskazkaPage()
        {
            InitializeComponent();
            var4Entities4 = new var4Entities3();
        }

        private void Proverka(object sender, RoutedEventArgs e)
        {
            int login = Convert.ToInt32(inputLogin.Text);
            string fio = inputfio.Text;
            string position = inputPosition.Text;
            string date = inputDate.Text;

            if (var4Entities4.Employer.Any(x=> x.tabNum == login))
            {
                Employer emp = var4Entities4.Employer.ToList().Find(x => x.tabNum == login);
                if (emp.name.Equals(fio))
                {
                    if (emp.Position1.Titile.Equals(position))
                    {
                        string dateMore = emp.dateStartWork.ToShortDateString();
                        if (dateMore.Equals(date))
                        {
                            MessageBox.Show($"Ваш пароль {emp.password}");
                        }
                        else
                        {
                            MessageBox.Show("Неправильные данные");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильные данные");
                    }
                }
                else
                {
                    MessageBox.Show("Неправильные данные");
                }
            }
            else
            {
                MessageBox.Show("Неправильные данные");
            }
        }
    }
}
