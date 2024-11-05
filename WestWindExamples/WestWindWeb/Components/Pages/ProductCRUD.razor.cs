using Microsoft.AspNetCore.Components;
using WestWindLibrary.BLL;
using WestWindLibrary.Entities;

namespace WestWindWeb.Components.Pages
{
    public partial class ProductCRUD
    {
        private Product product = new();
        private string feedback = string.Empty;
        private List<Supplier> suppliers = [];
        private List<Category> categories = [];

        [Inject]
        SupplierServices supplierServices { get; set; }
        [Inject]
        CategoryServices categoryServices { get; set; }

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
                feedback = ex.Message;
            }
            base.OnInitialized();
        }
        private void OnValidSubmit()
        {
            feedback = "This be valid!";
        }

        private void OnInvalidSubmit()
        {
            feedback = "This be borked!";
        }
    }
}
