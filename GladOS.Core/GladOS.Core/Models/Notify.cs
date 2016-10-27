using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using MvvmCross.Core.ViewModels;

namespace gladOS.Core.Models
{
    public class Notify
    {
        public Notify() { }
        public Notify(Notify Notify)
        {
            Text = Notify.Text;
            NotificationSet = Notify.NotificationSet;
        }
        //All the personal infomation about the person using the service
        [PrimaryKey, AutoIncrement]
        public string id { get; set; }
        public string Text { get; set; }
        public bool NotificationSet { get; set; }
    }



}
