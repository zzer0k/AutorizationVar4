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
    /// Логика взаимодействия для AddMaster.xaml
    /// </summary>
    public partial class AddMaster : Page
    {
        var4Entities3 context;
        public AddMaster(var4Entities3 cont)
        {
            InitializeComponent();
            context = cont;
            flag = true;
        }
        bool flag;
        private void AddNewMaster(object sender, RoutedEventArgs e)
        {

            if (flag)
            {
                Employer employer = new Employer()
                {
                    tabNum = Convert.ToInt32(tabBox.Text),
                    name = fioBox.Text,
                    dateStartWork = Convert.ToDateTime(databox.SelectedDate),
                    salary = Convert.ToDecimal(salaryBox.Text),
                    State = Convert.ToInt32(statusBox.Text),
                    position = 2 //двойка потому что в бд мастер под id position - 2
                };
                context.Employer.Add(employer);
                context.SaveChanges();

                NavigationService.Navigate(new MainPage());
            }
            else
            {
                context.Employer.Find(emp.tabNum).name = fioBox.Text;
                context.Employer.Find(emp.tabNum).dateStartWork = Convert.ToDateTime(databox.SelectedDate);
                context.Employer.Find(emp.tabNum).salary = Convert.ToDecimal(salaryBox.Text);
                context.Employer.Find(emp.tabNum).State = Convert.ToInt32(statusBox.Text);
                context.Employer.Find(emp.tabNum).position = 2;//двойка потому что в бд мастер под id position - 2
                context.SaveChanges();
                NavigationService.Navigate(new MainPage());
            }


        }
        Employer emp;
        public AddMaster(var4Entities3 cont, Employer employer)
        {
            InitializeComponent();
            context = cont;
            emp = employer;

            tabBox.Text = Convert.ToString(employer.tabNum);
            fioBox.Text = employer.name;
            databox.SelectedDate = employer.dateStartWork;
            salaryBox.Text = employer.salary.ToString();
            statusBox.Text = employer.State.ToString();
            flag = false;
        }
    }
}
