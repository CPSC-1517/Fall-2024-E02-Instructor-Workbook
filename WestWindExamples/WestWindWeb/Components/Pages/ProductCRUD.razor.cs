using WestWindLibrary.Entities;

namespace WestWindWeb.Components.Pages
{
    public partial class ProductCRUD
    {
        private Product product = new();
        private string feedback = string.Empty;
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
