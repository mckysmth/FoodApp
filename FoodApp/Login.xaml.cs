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
  public partial class Login : ContentPage
  {
    public Login()
    {
      InitializeComponent();

    }
    LogIn login = new LogIn();
    private void Loginbtn_Clicked(object sender, EventArgs e)
    {
      login.username = usernm.Text;
      login.password = psswrd.Text;
    }
  }
}