﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace GladOS.Core.Models
{
    public class Person
    {
        public Person() { }
        public Person(Person person)
        {
            Name = person.Name;
            Number = person.Number;
            Email = person.Employer;
            Employer = person.Employer;

        }
        //All the personal infomation about the person using the service
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Photo { get; set; }
        public string Employer { get; set; }
        public string Email { get; set; }
        public bool Nfc { get; set; }
        public bool Gps { get; set; }
        public bool Wifi { get; set; }
        public bool Bluetooth { get; set; }
    }



}
