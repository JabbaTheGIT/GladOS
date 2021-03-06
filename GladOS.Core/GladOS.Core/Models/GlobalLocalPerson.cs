﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using MvvmCross.Core.ViewModels;
using GladOS.Core.Models;

namespace gladOS.Core.Models
{
    public static class GlobalLocalPerson
    {
        private static string id = "";

        public static string Id
        {
            get { return id; }
            set { id = value; }
        }

        private static string name = "";

        public static string Name
        {
            get { return name; }
            set { name = value; }
        }

        private static string number = "";

        public static string Number
        {
            get { return number; }
            set { number = value; }
        }

        //public static string Photo { get; set; }
        private static string employer = "";

        public static string Employer
        {
            get { return employer; }
            set { employer = value; }
        }

        private static string email = "";

        public static string Email
        {
            get { return email; }
            set { email = value; }
        }

        private static bool contactable = true;

        public static bool Contactable
        {
            get { return contactable; }
            set { contactable = value; }
        }

        private static double latitude = 0;

        public static double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        private static double longitude = 0;

        public static double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public static List<string> messages = new List<string>();

        public static string Message
        {
            set
            {
                messages.Add(value);
            }
        }

        private static OfficeLocationBarcodes officeLocation;
        public static OfficeLocationBarcodes OfficeLocation
        {
            get { return officeLocation; }
            set { officeLocation = value; }
        }


    }



}
