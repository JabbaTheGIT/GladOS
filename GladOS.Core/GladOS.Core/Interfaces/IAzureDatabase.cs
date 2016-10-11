using GladOS.Core.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladOS.Core.Interfaces
{
    public interface IAzureDatabase
    {
        MobileServiceClient GetMobileServiceClient();

    }
}
