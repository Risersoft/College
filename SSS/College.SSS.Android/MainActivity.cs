using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Xamarin.Forms;
using Risersoft.Framework.Droid.Dependency;
using Android.Support.V7.App;
using Android.Util;
using System.Threading.Tasks;
using Android.Content;
using Risersoft.Framework.Droid;
using Risersoft.Framework.Dependency;
using Xamarin.Essentials;
using Android.Content.Res;

namespace College.SSS.Droid
{

    [Activity(Label = "College.SSS", Icon = "@drawable/icon", Theme = "@style/MyTheme.Splash", MainLauncher = true,NoHistory =true)]
    public class SplashActivity : AppCompatActivity
    {
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(TAG, "SplashActivity.OnCreate");

        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
            await Task.Delay(3000); // Simulate a bit of startup work.
            Log.Debug(TAG, "Startup work is finished - starting MainActivity.");
            StartActivity(new Intent(MainApplication.Context, typeof(MainActivity)));
            this.Finish();
        }
    }

    [Activity(Label = "College.SSS", Theme = "@style/MyTheme",ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,ScreenOrientation =ScreenOrientation.Portrait)]
    public class MainActivity : MainActivityBase
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
            Risersoft.Framework.Droid.Extension.Init(this);
            Permissions.RequestAsync<Permissions.StorageWrite>();
            InitDownloadFileFunc();

            LoadApplication(new App());
            DependencyService.Register<ConfigService>();
        }
        public override Resources Resources
        {
            get
            {
                Resources res = base.Resources;
                Configuration config = new Configuration();
                config.SetToDefaults();
                res.UpdateConfiguration(config, res.DisplayMetrics);
                return res;
            }
        }
    }
}

//https://stackoverflow.com/questions/40266537/xamarin-couldnt-find-libmonodroid-so-emulator-error