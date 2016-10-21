using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GladOS.Droid.Services
{
    public class Progress
    {
        private readonly Context context;

        public Progress(Context context)
        {
            this.context = context;
        }

        private ProgressDialog dialogProgress;

        public bool Visible
        {
            get
            {
                return dialogProgress != null;
            }
            set
            {
                if (value == Visible)
                {
                    return;
                }

                if (value)
                {
                    dialogProgress = new ProgressDialog(context);
                    dialogProgress.SetTitle("Loading Profile...");
                    dialogProgress.Show();
                }
                else
                {
                    dialogProgress.Hide();
                    dialogProgress = null;
                }
            }
        }
    }
}