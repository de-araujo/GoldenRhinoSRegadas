using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//libs
using GoldenRhino.Model;
using GoldenRhino.Code.Validation;

namespace GoldenRhino.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registeration : ContentPage
    {
        public Registeration()
        {
            InitializeComponent();

            AccountTypePicker.Items.Add("Public User");
            AccountTypePicker.Items.Add("Employee");
            AccountTypePicker.SelectedItem = "Public User";
        }

        async private void BtnLogin_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async private void BtnRegister_OnClicked(object sender, EventArgs e)
        {
            if (ValidationVault.Email == true)
            {
                if (ValidationVault.Password == true)
                {
                    if (ValidationVault.ConfirmPassword == true)
                    {
                        User user = new User();
                        user.FirstName = FirstNameRegEntry.Text;
                        user.Surname = SurnameRegEntry.Text;
                        user.Email = EmailRegEntry.Text;
                        user.Password = PasswordRegEntry.Text;
                        user.AccountType = AccountTypePicker.SelectedItem.ToString();

                        List<User> DataBaseItems = await App.Database.GetAllItems();

                        if (DataBaseItems.Count == 0)
                        {
                            await App.Database.Insert(user);

                            await Navigation.PopAsync();
                        }
                        else
                        {
                            foreach (User item in DataBaseItems)
                            {
                                if (item.Email == user.Email)
                                {
                                    await DisplayAlert("Registeration Failed", "Email already exists", "Try again");
                                }
                                else
                                {
                                    await App.Database.Insert(user);
                                    await DisplayAlert("Regsiteration Successful", "You have successfully registered a user", "Yes", "Cancel");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}