using System.Collections.ObjectModel;
using FreshMvvm;
using medicinepricechecker.Helpers;
using medicinepricechecker.Models;
using Xamarin.Forms;
using medicinepricechecker.Services;

namespace medicinepricechecker
{
	public class HomePageModel : FreshBasePageModel
	{
		#region Private members 

		readonly IProductServices _productServices;
		public ObservableCollection<Product> ProductsList { get; set; }

		#endregion

		public HomePageModel(ProductServices productServices)
		{
			_productServices = productServices;
		}

		public async override void Init(object initData)
		{
			try
			{
				ProductsList = new ObservableCollection<Product>(await _productServices.GetProductsAsync());
			}
			catch (System.Exception ex)
			{
				MessageHelper.ShowError(ex, this);
			}
		}

		Product _selectedProduct;

		public Product SelectedProduct
		{
			get
			{
				return _selectedProduct;
			}
			set
			{
				_selectedProduct = value;

				if (_selectedProduct == null)
				{
					return;
				}

				SelectedProductCommand.Execute(value);
				_selectedProduct = null;
			}
		}

		#region Commands

		public Command SelectedProductCommand
		{
			get
			{
				return new Command<Product>(async (product) =>
				{
					var page = FreshMvvm.FreshPageModelResolver.ResolvePageModel<DetailsPageModel>(product);
					await Application.Current.MainPage.Navigation.PushAsync(page);
				});
			}
		}

		#endregion
	}
}