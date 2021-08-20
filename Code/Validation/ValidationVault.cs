using System;
using System.Collections.Generic;
using System.Text;

namespace GoldenRhino.Code.Validation
{
    public static class ValidationVault
    {
        public static string StoredPasswordValidation;
        //For registeration
        public static bool Email = false;
        public static bool Password = false;
        public static bool ConfirmPassword = false;

        //for Login
        public static bool LoginEmail = false;
        public static bool LoginPassword = false;
    }
}
