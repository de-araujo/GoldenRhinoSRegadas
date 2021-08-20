using System;
using System.Collections.Generic;
using System.Text;
//libs
using Xamarin.Forms;
using System.Text.RegularExpressions;
using BottomBar.XamarinForms;

namespace GoldenRhino.Code.Validation
{
    public class EmailValidation : Behavior<Entry>
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


        //The next part assesses the input if validation is met.
        //This displays the colour red for not met and green for me

        private void BindableOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var Email = e.NewTextValue;
            var Entry = sender as Entry;

            if (IsEmailValid(Email) == true)
            {
                Entry.TextColor = Color.Default;
                ValidationVault.Email = true;
            }
            else
            {
                Entry.TextColor = Color.Red;
                ValidationVault.Email = false;
            }
        }


        private bool IsEmailValid(string address)
        {
            //Do the regex for validating the email
            return Regex.IsMatch(address, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
