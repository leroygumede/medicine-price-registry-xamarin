using System;
using FormsToolkit;
using Xamarin.Forms;

namespace medicinepricechecker.Helpers
{
    public class MessageHelper
    {
        public static void ShowMessage(string message, string title)
        {

            MessagingService.Current.SendMessage<MessagingServiceAlert>(MessageKeys.DisplayAlert, new MessagingServiceAlert
            {
                Title = title,
                Message = message,
                Cancel = "OK"
            });
            return;
        }

        public static void ShowError(string message)
        {
            MessagingService.Current.SendMessage<MessagingServiceAlert>(MessageKeys.DisplayAlert, new MessagingServiceAlert
            {
                Title = "Error",
                Message = message,
                Cancel = "OK"
            });
            return;
        }

        public static void ShowError(Exception ex, object body)
        {
            MessagingService.Current.SendMessage<MessagingServiceAlert>(MessageKeys.DisplayAlert, new MessagingServiceAlert
            {
                Title = "Error",
                Message = ex.Message,
                Cancel = "OK"
            });
            return;
        }

        public void ShowNoConnection()
        {
            MessagingService.Current.SendMessage<MessagingServiceAlert>(MessageKeys.DisplayAlert, new MessagingServiceAlert
            {
                Title = "No internet connectivity",
                Message = "Please check your connection to the internet and try again.",
                Cancel = "OK"
            });
            return;
        }

        public static async void ShowError(Exception ex)
        {
            await Application.Current?.MainPage?.DisplayAlert("Error", ex.Message, "OK");
        }


    }
}