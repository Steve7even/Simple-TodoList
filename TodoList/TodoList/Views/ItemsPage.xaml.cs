using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TodoList.Models;
using TodoList.Views;
using TodoList.ViewModels;
using TodoList.Entities;

namespace TodoList.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        

        public ItemsPage()
        {
            InitializeComponent();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Todo)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(item));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemDetailPage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            ItemsCollectionView.ItemsSource = await App.DB.GetAll();
        }

        public async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var item = (Todo)mi.BindingContext;
            App.DB.Delete(item);
            ItemsCollectionView.IsRefreshing = true;
            ItemsCollectionView.ItemsSource = await App.DB.GetAll();
            ItemsCollectionView.IsRefreshing = false;
        }
    }
}