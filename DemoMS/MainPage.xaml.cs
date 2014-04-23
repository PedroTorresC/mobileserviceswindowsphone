using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DemoMS.Resources;
using Microsoft.WindowsAzure.MobileServices;

namespace DemoMS
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor

        IMobileServiceTable<Item> Listatabla =
            App.MobileService.GetTable<Item>();

        public MainPage()
        {
            InitializeComponent();

          
        }

        private async void btngrabar_Click(object sender, RoutedEventArgs e)
        {
            string codigo = Guid.NewGuid().ToString();
            
            Item item = new Item { Id = codigo, Text = txtnombre.Text };

            await App.MobileService.GetTable<Item>().InsertAsync(item);

            txtcodigo.Text = codigo;
        }











        private async void btnlistar_Click(object sender, RoutedEventArgs e)
        {
          var  items = await Listatabla.ToCollectionAsync();
          lista.ItemsSource = items.ToList();
        }









        private async void btnmodificar_Click(object sender, RoutedEventArgs e)
        {
            Item item = new Item { Id = txtcodigo.Text, Text = txtnombre.Text };
            await App.MobileService.GetTable<Item>().UpdateAsync(item);
            
        }

        private async void btneliminar_Click(object sender, RoutedEventArgs e)
        {
            Item item = new Item { Id = txtcodigo.Text };
            await App.MobileService.GetTable<Item>().DeleteAsync(item);
        }
         
    }
}