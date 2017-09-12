using System;
using FreshMvvm;
using medicinepricechecker.Helpers;
using medicinepricechecker.Models;
using medicinepricechecker.Services;

namespace medicinepricechecker
{
	public class DetailsPageModel : FreshBasePageModel
	{
		#region Private members 

		readonly IProductServices _productServices;
		public Product ProductDetails { get; set; }

		#endregion

		public DetailsPageModel(ProductServices productServices)
		{
			_productServices = productServices;
		}

		public async override void Init(object initData)
		{
			if (initData != null)
			{
				try
				{
					var parsedData = (Product)initData;
					ProductDetails = await _productServices.GetProductDetailsAsync(parsedData.nappi_code);
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
