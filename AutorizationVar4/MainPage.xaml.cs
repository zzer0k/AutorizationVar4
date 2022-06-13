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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        var4Entities3 context;
        public MainPage()
        {
            InitializeComponent();
            context = new var4Entities3();
            MastersTable.ItemsSource = context.Employer.ToList();
            var stateList = context.State.ToList();
            stateList.Insert(0, new State() { title = "все" });
            statusCombo.ItemsSource = stateList;
        }

        public void RefreshData()
        {
            var list = context.Employer.ToList();
            if(statusCombo.SelectedIndex > 0)
            {
                State st = statusCombo.SelectedItem as State;
                list = list.Where(x => x.State1 == st).ToList();
            }

            if (!string.IsNullOrWhiteSpace(inputNameSearch.Text))
            {
                list = list.Where(x => x.name.ToLower().Contains(inputNameSearch.Text.ToLower())).ToList();
            }
            MastersTable.ItemsSource = list;
        }


        private void GoMaster(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void GoClients(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientPage());

        }

        private void GoAddMaster(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddMaster(context));
        }

        private void EditMaster(object sender, RoutedEventArgs e)
        {
            Employer employer = MastersTable.SelectedItem as Employer;
            NavigationService.Navigate(new AddMaster(context, employer));
        }

        private void DeleteMaster(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Employer employer = MastersTable.SelectedItem as Employer;
                    context.Employer.Remove(employer);
                    context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка при удалении");
                }
            }
        }

        private void SearchFio(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void ChangedStatus(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();

        }
    }
}
