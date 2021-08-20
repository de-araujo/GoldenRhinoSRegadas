using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//libs
using System.IO;
using GoldenRhino.Data;
using GoldenRhino.Model;
using GoldenRhino.Code;
using GoldenRhino.ViewModel;
using SQLite;
using GoldenRhino.Views;

namespace GoldenRhino
{
    public partial class App : Application
    {
         static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GoldenRhino.db3"));
                }

                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            NavigationPage navigationPage = new NavigationPage(new MainPage());
            navigationPage.BarBackgroundColor = Color.DimGray;
            navigationPage.BarTextColor = Color.Gold;
            MainPage = navigationPage;


     
           
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
