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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        var4Entities3 context;
        public ClientPage()
        {
            InitializeComponent();
            context = new var4Entities3();
            ClientTable.ItemsSource = context.Client.ToList();
        }

        private void GoMaster(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void GoClients(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientPage());

        }

        

        private void SearchFio(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputNameSearch.Text))
            {
                var list = context.Client.ToList();

                if (!string.IsNullOrWhiteSpace(inputNameSearch.Text))
                {
                    list = list.Where(x => x.name.ToLower().Contains(inputNameSearch.Text.ToLower())).ToList();
                }
                ClientTable.ItemsSource = list;
            }

        
        }

        private void EditMaster(object sender, RoutedEventArgs e)
        {

            Client client = ClientTable.SelectedItem as Client;
            NavigationService.Navigate(new AddClient(context, client));
        }

        private void ClientTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
