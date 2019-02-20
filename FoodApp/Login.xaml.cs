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
        User user;
    public Login()
    {
      InitializeComponent();
            user = null;
    }

        
        private async void Loginbtn_Clicked(object sender, EventArgs e)
        {
            MongoService mongo = new MongoService();


            List<User> userList = await mongo.GetAllUsers();

            user = userList.Find(i => i.Email.ToLower() == usernm.Text.ToLower());

            if (userList != null)
            {
                if (psswrd.Text == user.Password)
                {
                    Navigation.PushAsync(new ProfilePage());

                }
            }
          
        }

  }
}