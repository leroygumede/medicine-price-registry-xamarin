using System;
using System.Collections.ObjectModel;
using FreshMvvm;
using medicinepricechecker.Helpers;
using medicinepricechecker.Models;
using System.Diagnostics;

namespace medicinepricechecker
{
    public class HomePageModel : FreshBasePageModel
    {
        #region Private members 

        readonly IHomeService _homeServices;
        public ObservableCollection<Products> ProductsList { get; set; }

        #endregion

        public HomePageModel(HomeService homeservices)
        {
            _homeServices = homeservices;
        }

        public async override void Init(object initData)
        {
            try
            {
                ProductsList = new ObservableCollection<Products>(await _homeServices.GetProductsAsync());
                Debug.WriteLine("");
            }
            catch (System.Exception ex)
            {
                MessageHelper.ShowError(ex, this);
            }
        }
    }
}