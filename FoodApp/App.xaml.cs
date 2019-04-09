using System;
using FoodApp.Model;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FoodApp
{
    public partial class App : Application
    {

        public static string DatabaseLocation = string.Empty;

        public static MobileServiceClient MobileService =
            new MobileServiceClient(
                "https://polar.azurewebsites.net"
            );
        public static FoodUser User;

        public App()
        {
            InitializeComponent();

            MainPage = new FoodApp.MainPage();
        }

        public App(String databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());

            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
