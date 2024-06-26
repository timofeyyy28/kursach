﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace App5
{
    public static class GlobalData
    {
        public static string UserEmail
        {
            get
            {
                if (Application.Current.Properties.ContainsKey("UserEmail"))
                    return Application.Current.Properties["UserEmail"].ToString();
                else
                    return null;
            }
            set
            {
                Application.Current.Properties["UserEmail"] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static string UserName
        {
            get
            {
                if (Application.Current.Properties.ContainsKey("UserName"))
                    return Application.Current.Properties["UserName"].ToString();
                else
                    return null;
            }
            set
            {
                Application.Current.Properties["UserName"] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static int UserId { get; set; }
        public static int CurrentPlace {  get; set; }
        public static List<int> Likes { get; set; }
        
        
    }
}
