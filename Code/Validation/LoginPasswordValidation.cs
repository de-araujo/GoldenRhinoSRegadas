using System;
using System.Collections.Generic;
using System.Text;
//Libs
using Xamarin.Forms;

namespace GoldenRhino.Code.Validation
{
    public class LoginPasswordValidation : Behavior<Entry>
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
            var password = e.NewTextValue;
            var Entry = sender as Entry;

            if (IsLoginPasswordCorrect(password) == true)
            {
                Entry.TextColor = Color.Default;
                ValidationVault.LoginPassword = true;
            }
            else
            {
                Entry.TextColor = Color.Red;
                ValidationVault.LoginPassword = false;
            }
        }

        private bool IsLoginPasswordCorrect(string loginPassword)
        {
            if (loginPassword.Length > 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
