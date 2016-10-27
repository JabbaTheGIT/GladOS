using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using gladOS.Droid.Database;
using gladOS.Core.Interfaces;
using gladOS.Droid.Services;
using gladOS.Core.Database;
using gladOS.Core.Models;
using gladOS.Droid.Maps;
using GladOS.Core.Database;

namespace gladOS.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new gladOS.Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            Mvx.LazyConstructAndRegisterSingleton<ISqlite, SqliteDroid>();
            Mvx.LazyConstructAndRegisterSingleton<IDialogService, DialogService>();
            Mvx.LazyConstructAndRegisterSingleton<IGeoCoder, GeoCoder>();
            //Mvx.LazyConstructAndRegisterSingleton<IPersonInfoDatabase, PersonInfoDatabase>();
            Mvx.LazyConstructAndRegisterSingleton<IEventInfoDatabase, EventInfoDatabase>();
            Mvx.LazyConstructAndRegisterSingleton<IPersonInfoDatabase, PersonInfoDatabaseAzure>();
            Mvx.LazyConstructAndRegisterSingleton<INotify, NotifyFunction>();
            Mvx.LazyConstructAndRegisterSingleton<IAzureDatabase, AzureDatabase>();
            base.InitializeFirstChance();
        }
    }
}
