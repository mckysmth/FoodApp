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
    public Signup()
    {
      InitializeComponent();
    }

    SignUp signUp = new SignUp();

    private void Signupbtn_Clicked(object sender, EventArgs e)
    {
      signUp.firstName = frstnm.Text;
      signUp.lastName = lstnm.Text;
      //finish
    }
  }
}