using Microsoft.AspNetCore.Components;
using WestWindLibrary.BLL;
using WestWindLibrary.Entities;

namespace WestWindWeb.Components.Pages
{
    public partial class ProductList
    {
        private List<Product> products = [];
        private List<string> errorMsgs = [];

        [Inject]
        ProductServices _productServices { get; set; }

        protected override void OnInitialized()
        {
            try
            {
                products = _productServices.GetAllProducts();
            }
            catch (Exception ex)
            {
                errorMsgs.Add($"Data Loading Error: {GetInnerException(ex).Message}");
            }
            base.OnInitialized();
        }
        private Exception GetInnerException(Exception ex)
        {
            //drill down into your Exception until there are no more inner exceptions
            //at this point you have the "real" error
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }
    }
}