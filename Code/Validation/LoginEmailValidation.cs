using System;
using System.Collections.Generic;
using System.Text;
//Libs 
using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace GoldenRhino.Code.Validation
{
    public class LoginEmailValidation : Behavior<Entry>
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
            var Email = e.NewTextValue;
            var Entry = sender as Entry;

            if (IsEmailCorrect(Email) == true)
            {
                Entry.TextColor = Color.Green;
                ValidationVault.LoginEmail = true;
            }
            else
            {
                Entry.TextColor = Color.Red;
                ValidationVault.LoginEmail = false;
            }
        }


        private bool IsEmailCorrect(string adress)
        {
            //Do the regex for validating the email
            return Regex.IsMatch(adress, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
