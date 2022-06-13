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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Page
    {
        var4Entities3 context;
        public AddClient(var4Entities3 cont)
        {
            InitializeComponent();
            context = cont;
        }
        Client cl;

        public AddClient(var4Entities3 cont, Client client)
        {
            InitializeComponent();
            context = cont;
            cl = client;

            fioBox.Text = cl.name;
            passportBox.Text = cl.passport;
        }

        private void AddNewClient(object sender, RoutedEventArgs e)
        {
            context.Client.Find(cl.num).name = fioBox.Text;
            context.Client.Find(cl.num).passport = passportBox.Text;
            context.SaveChanges();
            NavigationService.Navigate(new ClientPage());
        }
    }
}
