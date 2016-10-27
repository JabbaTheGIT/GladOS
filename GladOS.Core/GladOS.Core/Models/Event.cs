using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using MvvmCross.Core.ViewModels;

namespace gladOS.Core.Models
{
    public class Event
    {
        public Event() { }
        public Event(Event events)
        {
            EventTitle = events.EventTitle;
            StartTime = events.StartTime;
            EndTime = events.EndTime;
        }
        //The persons event infomation
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string PersonId { get; set; }
        public string EventTitle { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }



}
