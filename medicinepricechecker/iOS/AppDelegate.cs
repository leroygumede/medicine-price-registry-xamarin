using System;
using System.Collections.Generic;
using System.Linq;
using FormsToolkit.iOS;
using Foundation;
using FreshMvvm;
using UIKit;


namespace medicinepricechecker.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			Toolkit.Init();
			// Code for starting up the Xamarin Test Cloud Agent
#if DEBUG
			Xamarin.Calabash.Start();
#endif
			string dbPath = FileAccessHelper.GetLocalFilePath("products.db3");
			FreshIOC.Container.Register(dbPath);

			LoadApplication(new medicinepricechecker.App(dbPath));

			return base.FinishedLaunching(app, options);
		}
	}
}
