using FormsToolkit;
using FreshMvvm;
using Xamarin.Forms;
using System.Diagnostics;

namespace medicinepricechecker
{
	public partial class App : Application
	{

		public static Repository PersonRepo { get; private set; }

		public App(string dbPath)
		{
			InitializeComponent();

			PersonRepo = new Repository(dbPath);
			Debug.WriteLine(dbPath);
			var page = FreshPageModelResolver.ResolvePageModel<HomePageModel>();
			var basicNavContainer = new FreshNavigationContainer(page);
			MainPage = basicNavContainer;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		/// <summary>
		/// Subscribes to messages for displaying alerts.
		/// </summary>
		static void SubscribeToDisplayAlertMessages()
		{
			MessagingService.Current.Subscribe<MessagingServiceAlert>(MessageKeys.DisplayAlert, async (service, info) =>
			{
				var task = Current?.MainPage?.DisplayAlert(info.Title, info.Message, info.Cancel);
				if (task != null)
				{
					await task;
					info?.OnCompleted?.Invoke();
				}
			});

			MessagingService.Current.Subscribe<MessagingServiceQuestion>(MessageKeys.DisplayQuestion, async (service, info) =>
			{
				var task = Current?.MainPage?.DisplayAlert(info.Title, info.Question, info.Positive, info.Negative);
				if (task != null)
				{
					var result = await task;
					info?.OnCompleted?.Invoke(result);
				}
			});
		}
	}
}
