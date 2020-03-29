using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TodoList.Services;
using TodoList.Views;
using TodoList.DBAccess;

namespace TodoList
{
    public partial class App : Application
    {
        static TodoDB todoDB;

        public static TodoDB DB
        {
            get
            {
                if (todoDB == null)
                {
                    todoDB = new TodoDB();
                }
                return todoDB;
            }
        }

        public App()
        {
            InitializeComponent();

            Plugin.Iconize.Iconize
                         .With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
                         .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
                         .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule());

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
