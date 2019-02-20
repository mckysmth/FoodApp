using FoodApp.Model;
using FoodApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodApp
{
[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ContentPage
    {
        User user;
        public Signup()
        {
            InitializeComponent();
            user = null;
        }



    private async void Signupbtn_Clicked(object sender, EventArgs e)
    {
      if (frstnm.Text == null || lstnm.Text == null || email.Text == null || newpsswrd.Text == null || dob.Date == null || hght.Text == null || wgth.Text == null)
      {
        DisplayAlert("Empty field error", "please verify you entered all the required information and try again", "OK");
      }
      else
      {
        DateTime dOB = dob.Date;

        user = new User(frstnm.Text, lstnm.Text, email.Text, newpsswrd.Text, dOB, float.Parse(hght.Text), float.Parse(wgth.Text));


        if (user != null)
        {
          MongoService mongoService = new MongoService();


          await mongoService.InsertNewUser(user);
        }

      }
    }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool result = ValidatorExtensions.IsValidEmailAddress(email.Text);

            if (!result)
            {
                //DisplayAlert("Invalid e-mail", "please write a valid email", "OK");
                emailLabel.IsVisible = true;
                emailLabel.Text = "invalid e-mail";
                emailLabel.TextColor = Color.Red;
            }

            if (result)
            {
                emailLabel.IsVisible = false;
            }

        }

        private void Confirmpsswrd_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool flag = ValidatorExtensions.ArePasswordsEqual(newpsswrd.Text, confirmpsswrd.Text);

            if (!flag)
            {
                //DisplayAlert("Passwords are not equeal", "confirm password again", "OK");
                confirmpsswrdLabel.IsVisible = true;
                confirmpsswrdLabel.Text = "passwords are not equal";
                confirmpsswrdLabel.TextColor = Color.Red;
                
            }

            if(flag)
            {
                confirmpsswrdLabel.IsVisible = false;
            }

        }

        //create validators for everything else




    }
}