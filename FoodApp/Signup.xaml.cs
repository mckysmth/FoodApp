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

            DateTime dOB = dob.Date;

            user = new User(frstnm.Text, lstnm.Text, email.Text, newpsswrd.Text, dOB, float.Parse(hght.Text),float.Parse(wgth.Text));

            if (user != null)
            {
                MongoService mongoService = new MongoService();


                await mongoService.InsertNewUser(user);
            }

        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool result = ValidatorExtensions.IsValidEmailAddress(email.Text);

            if (!result)
            {
                DisplayAlert("Invalid e-mail", "please write a valid email", "OK");
            }

        }

        private void Confirmpsswrd_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool flag = ValidatorExtensions.ArePasswordsEqual(newpsswrd.Text, confirmpsswrd.Text);

            if (flag)
            {
                DisplayAlert("Passwords are not equeal", "confirm password again", "OK");
            }

        }

        //create validators for everything else




    }
}