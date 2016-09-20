using GladOS.Core.Models;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GladOS.Core.ViewModels
{
    public class SecondViewModel : MvxViewModel
    {
        public ICommand HomePressed { get; private set; }
        public ICommand SchedulePressed { get; private set; }
        public ICommand SearchPressed { get; private set; }


        public SecondViewModel()
        {

            HomePressed = new MvxCommand(() =>
            {
                base.ShowViewModel<SecondViewModel>();
            });

            SchedulePressed = new MvxCommand(() =>
            {
                base.ShowViewModel<FirstViewModel>();
            });

            SearchPressed = new MvxCommand(() =>
            {
                base.ShowViewModel<ThirdViewModel>();
            });

        }
    }
}
