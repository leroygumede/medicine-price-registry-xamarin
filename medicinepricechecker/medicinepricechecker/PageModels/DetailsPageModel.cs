using System;
using FreshMvvm;
using medicinepricechecker.Helpers;
using medicinepricechecker.Models;

namespace medicinepricechecker
{
    public class DetailsPageModel : FreshBasePageModel
    {
        #region Private members 

        readonly IDetailService _detailService;
        public Product ProductDetails { get; set; }

        #endregion

        public DetailsPageModel(DetailService detailService)
        {
            _detailService = detailService;
        }


        public async override void Init(object initData)
        {
            if (initData != null)
            {
                try
                {
                    var parsedData = (Product)initData;
                    ProductDetails = await _detailService.GetProductAsync(parsedData.nappi_code);
                }
                catch (System.Exception ex)
                {
                    MessageHelper.ShowError(ex, this);
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
