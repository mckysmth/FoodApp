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
        FoodUser user;
    public Login()
    {
      InitializeComponent();
            user = null;
#pragma warning disable CS0618 // Type or member is obsolete
            noAccountLabel.GestureRecognizers.Add(item: new TapGestureRecognizer((view) => OnLabelClicked()));
#pragma warning restore CS0618 // Type or member is obsolete

        }

        private void OnLabelClicked()
        {
            Navigation.PushAsync(new Signup());
        }

        private async void Loginbtn_Clicked(object sender, EventArgs e)
        {
            user = new FoodUser
            {
                Email = usernm.Text,
                Password = psswrd.Text
            };

            //SQLService SQL = new SQLService();

            FoodUser userDB = await AzureService.GetUserByEmail(user);
            if (userDB != null)
            {
                if (userDB.Password == user.Password)
                {
                    App.User = userDB;
                    App.Current.MainPage = new MainPage();
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