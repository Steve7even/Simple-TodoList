using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TodoList.Models;
using TodoList.ViewModels;
using TodoList.Entities;

namespace TodoList.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        public Todo TodoItem { get; set; }

        public ItemDetailPage()
        {
            InitializeComponent();

            TodoItem = new Todo();
        }

        public ItemDetailPage(Todo todoItem)
        {
            InitializeComponent();

            TodoItem = todoItem;
            EntryTitel.Text = TodoItem.Titel;
            EntryContent.Text = TodoItem.Content;
        }

        async void SaveItem_Clicked(object sender, EventArgs e)
        {
            TodoItem.Titel = EntryTitel.Text;
            TodoItem.Content = EntryContent.Text;
            await App.DB.Save(TodoItem);
            await Navigation.PopAsync();
        }
    }
}