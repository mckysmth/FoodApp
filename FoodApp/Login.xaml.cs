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

        
        private void Loginbtn_Clicked(object sender, EventArgs e)
        {
            user = new User
            {
                Email = usernm.Text,
                Password = psswrd.Text
            };

            SQLService SQL = new SQLService();

            User userDB = SQL.GetUserByEmail(user);
            if (userDB != null)
            {
                if (userDB.Password == user.Password)
                {
                    App.Current.MainPage.Navigation.PushAsync(new ProfilePage());
                }
                else
                {
                    //ErrorMessage = "Incorrect Email/Password.";
                }
            }
            else
            {
                //ErrorMessage = "Incorrect Email/Password.";
            }
          
        }

  }
}