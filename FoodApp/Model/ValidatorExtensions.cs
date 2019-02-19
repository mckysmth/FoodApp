﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FoodApp.Model
{
    public static class ValidatorExtensions
    {
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }

        public static bool ArePasswordsEqual( String a, String b)
        {
            bool flag;
            if (a.Equals(b))
            {
                flag = true;
            }
            else flag = false;

            return flag;

        }


    }

    


}
