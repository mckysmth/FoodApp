using FoodApp.Model;
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

   

    private void Signupbtn_Clicked(object sender, EventArgs e)
    {
      DateTime x = new DateTime(-1, 1, 1); //placeholder
      
      User user = new User(frstnm.Text, lstnm.Text, email.Text, newpsswrd.Text, x, float.Parse(hght.Text),float.Parse(wgth.Text));
     
    }
  }
}