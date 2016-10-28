using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using MvvmCross.Core.ViewModels;

namespace gladOS.Core.Models
{
    public class UpstreamMessages
    {
        public UpstreamMessages() { }
        public UpstreamMessages(UpstreamMessages UpstreamMessage)
        {
            Message = UpstreamMessage.Message;
        }
        //All the personal infomation about the person using the service
        [PrimaryKey, AutoIncrement]
        public string id { get; set; }
        public string Message { get; set; }

    }



}
