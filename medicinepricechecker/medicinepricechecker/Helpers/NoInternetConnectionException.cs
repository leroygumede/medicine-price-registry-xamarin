using System;
namespace medicinepricechecker.Helpers
{
    public class NoInternetConnectionException : Exception
    {
        /// <summary>
        ///  NoInternetConnectionException Exception handler
        /// </summary>
        public string Content { get; }

        public NoInternetConnectionException()
        {
            MessageHelper.ShowError("You seem to be offline, please check your internet connection.");
        }
    }
}
