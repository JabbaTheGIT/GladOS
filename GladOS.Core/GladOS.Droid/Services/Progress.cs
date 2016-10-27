using Android.App;
using Android.Content;

namespace gladOS.Droid.Services
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
                    dialogProgress.SetCanceledOnTouchOutside(false);
                    dialogProgress.SetTitle("Loading...");
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