using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
//libs
using GoldenRhino.Model;
using GoldenRhino.ViewModel;
using GoldenRhino.Code.Validation;
using GoldenRhino.Views;

namespace GoldenRhino
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registeration());
        }

        async private void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (ValidationVault.LoginEmail == true)
            {
                if (ValidationVault.LoginPassword == true)
                {
                    User user = new User();
                    user.Email = EmailEntry.Text;
                    user.Password = PasswordEntry.Text;

                    List<User> DatabaseItems = await App.Database.GetAllItems();
                    foreach (User item in DatabaseItems)
                    {
                        if (item.Email == user.Email)
                        {
                            if (item.Password == user.Password)
                            {
                                Navigation nav = new Navigation();
                                App.Current.MainPage = nav;
                            }
                        }
                    }
                }
            }
        }

      
    }
}
