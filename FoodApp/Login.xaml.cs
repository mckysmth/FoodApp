using System;
using FoodApp.Model;
using FoodApp.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodApp
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Login : ContentPage
  {
    public Login()
    {
      InitializeComponent();

    }
    LogIn login = new LogIn();
        
        
        private async void Loginbtn_Clicked(object sender, EventArgs e)
        {
            MongoService mongo = new MongoService();


            List<User> userList = await mongo.GetAllUsers();

            User user = userList.Find(i => i.Email == usernm.Text);

            if (user != null)
            {
                if (psswrd.Text == user.Password)
                {
                    Navigation.PushAsync(new ProfilePage());

                }




            }
          
        }

  }
}