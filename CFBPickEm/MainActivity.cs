using Android.App;
using Android.Widget;
using Android.OS;

namespace CFBPickEm
{
    [Activity(Label = "CFB Pick Em", MainLauncher = false, Icon = "@drawable/bulldog")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

