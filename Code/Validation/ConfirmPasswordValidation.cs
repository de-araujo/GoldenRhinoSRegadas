using System;
using System.Collections.Generic;
using System.Text;
//Libs
using Xamarin.Forms;

namespace GoldenRhino.Code.Validation
{
    public class ConfirmPasswordValidation : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += BindableOnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.TextChanged -= BindableOnTextChanged;
        }

        private void BindableOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var CnfrmPass = e.NewTextValue;
            var Entry = sender as Entry;


            if (IsConfirmPassword(CnfrmPass) == true)
            {
                Entry.TextColor = Color.Default;
                ValidationVault.ConfirmPassword = true;
            }
            else
            {
                Entry.TextColor = Color.Red;
                ValidationVault.ConfirmPassword = false;
            }
        }

        private bool IsConfirmPassword(string password)
        {
            string passwordStored = ValidationVault.StoredPasswordValidation;
            if (passwordStored != null)
            {
                if (passwordStored.Equals(password) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }



        }
    }
}
