using gladOS.Core.Interfaces;
using gladOS.Core.Models;
using gladOS.Core.Services;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

/*This view carries on from the search view, it displays the selected 
 * person chosen by the user from the search page
 */

namespace gladOS.Core.ViewModels
{
    public class OfficeLocationViewModel : MvxViewModel
    {
        public ICommand AddNewBarcode { get; private set; }
        public ICommand SelectRoom { get; private set; }
        public string Barcode { get; set; }

        public OfficeLocationViewModel()
        {
            AddNewBarcode = new MvxCommand(() =>
            {
                ShowViewModel<CreatePersonViewModel>();
            });

        }
    }
}