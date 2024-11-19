﻿using Microsoft.AspNetCore.Components;
using WestWindLibrary.BLL;
using WestWindLibrary.Entities;

namespace WestWindWeb.Components.Pages
{
    public partial class ProductCRUD
    {
        //Our form model, what holds data for our form
        private Product product = new();
        private string feedback = string.Empty;
        private List<string> errorMsgs = [];
        private List<Supplier> suppliers = [];
        private List<Category> categories = [];
        private bool isNew;

        //This parameter matches the parameter in our page directive
        //Must have the same datatype and name
        [Parameter]
        public int? productId { get; set; }

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
                //Check if the parameter productId has a value
                if (productId.HasValue)
                {
                    //If the productId is provided we need to be able to get the Product from the database.
                    product = productServices.GetProduct_ByProductId(productId.Value);
                    if (product == null)
                    {
                        errorMsgs.Add($"Supplied product ID {productId} does not match any products in the database.");
                        product = new();
                        isNew = true;
                    }
                }
                else
                {
                    isNew = true;
                }
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
                if(isNew)
                {
                    AddProduct();
                }
                else
                {
                    UpdateProduct();
                }

            }
        }

        private void UpdateProduct()
        {
            try
            {
                int rowAffected = productServices.Product_UpdateProduct(product);
                if (rowAffected == 0)
                {
                    errorMsgs.Add($"Product {product.ProductName} (ID: {product.ProductID}) has not been updated. Please check to see if the product still exists in the database.");
                }
                else
                {
                    feedback = $"Product {product.ProductName} (ID: {product.ProductID}) has been successfully updated.";
                }
            }
            catch (Exception ex)
            {
                errorMsgs.Add(GetInnerException(ex).Message);
            }
        }

        private void AddProduct()
        {
            try
            {
                int newproductid = productServices.Product_AddProduct(product);
                feedback = $"Product {product.ProductName} (ID: {newproductid}) has be added to the database.";
                isNew = false;
            }
            catch (Exception ex)
            {
                errorMsgs.Add(GetInnerException(ex).Message);
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
