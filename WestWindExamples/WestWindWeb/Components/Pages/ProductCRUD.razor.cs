using Microsoft.AspNetCore.Components;
using WestWindLibrary.BLL;
using WestWindLibrary.Entities;

namespace WestWindWeb.Components.Pages
{
    public partial class ProductCRUD
    {
        private Product product = new();
        private string feedback = string.Empty;
        private List<string> errorMsgs = [];
        private List<Supplier> suppliers = [];
        private List<Category> categories = [];

        [Inject]
        SupplierServices supplierServices { get; set; }
        [Inject]
        CategoryServices categoryServices { get; set; }
        [Inject]
        ProductServices productServices { get; set; }

        protected override void OnInitialized()
        {
            //Fill in the initial data for the drop downs (selects)
            try
            {
                suppliers = supplierServices.GetAllSuppliers();
                categories = categoryServices.GetCategories();
            }
            catch (Exception ex)
            {
                errorMsgs.Add(GetInnerException(ex).Message);
            }
            base.OnInitialized();
        }
        private void OnValidSubmit()
        {
            //Always clear the messaging first. Always, Always, Always!
            errorMsgs.Clear();
            feedback = string.Empty;

            if (product.SupplierID == 0)
            {
                //Add to errorMsg
                //If using EditContext you can add an error to the ValidationSummary for the related field
                errorMsgs.Add("You must select a supplier.");
            }
            if (product.CategoryID == 0)
            {
                errorMsgs.Add("You must select a category.");
            }
            if (errorMsgs.Count == 0)
            {
                try
                {
                    int newproductid = productServices.Product_AddProduct(product);
                    feedback = $"Product {product.ProductName} (ID: {newproductid}) has be added to the database.";
                }
                catch (Exception ex)
                {
                    errorMsgs.Add(GetInnerException(ex).Message);
                }
            }

        }
        private void OnInvalidSubmit()
        {
            feedback = "This be borked!";
        }

        private Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }
    }
}
