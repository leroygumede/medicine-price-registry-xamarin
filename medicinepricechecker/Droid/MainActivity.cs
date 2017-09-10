using Android.App;
using Android.Content.PM;
using Android.OS;
using FormsToolkit.Droid;
using FreshMvvm;

namespace medicinepricechecker.Droid
{
	[Activity(Label = "medicinepricechecker.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			Toolkit.Init();

			string dbPath = FileAccessHelper.GetLocalFilePath("products.db3");
			FreshIOC.Container.Register(dbPath);

			LoadApplication(new medicinepricechecker.App(dbPath));
		}
	}
}
