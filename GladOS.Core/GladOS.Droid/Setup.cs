using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using GladOS.Droid.Database;
using GladOS.Core.Interfaces;
using GladOS.Droid.Services;
using GladOS.Core.Database;

namespace GladOS.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new GladOS.Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            Mvx.LazyConstructAndRegisterSingleton<ISqlite, SqliteDroid>();
            Mvx.LazyConstructAndRegisterSingleton<IDialogService, DialogService>();
            Mvx.LazyConstructAndRegisterSingleton<IPersonInfoDatabase, PersonInfoDatabase>();
            Mvx.LazyConstructAndRegisterSingleton<IPersonInfoDatabase, PersonInfoDatabaseAzure>();
            Mvx.LazyConstructAndRegisterSingleton<IAzureDatabase, AzureDatabase>();
            base.InitializeFirstChance();
        }
    }
}
