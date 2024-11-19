using Microsoft.EntityFrameworkCore;
using WestWindLibrary.DAL;
using WestWindLibrary.Entities;

namespace WestWindLibrary.BLL
{
    public class ProductServices
    {
        private readonly WestWindContext _context;

        //Create a constructor that take in the context (map to the database)
        public ProductServices(WestWindContext context)
        {
            _context = context;
        }

        #region Queries
        public List<Product> GetAllProducts()
        {
            //Address is only Included as an example.
            //Can only include a full entity!! DO NOT Try and include a field, this will break.
            return _context.Products.Include(p=>p.Category).Include(p=>p.Supplier).ThenInclude(s=>s.Address).ToList();
        }
        public List<Product> GetProducts_ByCategory(int categoryId)
        {
            return _context.Products.Where(x=>x.CategoryID.Equals(categoryId)).Include(p=>p.Category).Include(p=>p.Supplier).ToList();
        }
        #endregion

        #region CRUD
        //For an insert we always return an int for identifier as the PK, this is the new PK
        public int Product_AddProduct(Product product)
        {
            //Check if you got data
            if (product == null)
            {
                throw new ArgumentNullException("You must supply the new product information.");
            }

            //Business Rule Example
            //Does the Product already exist?
            bool exists = _context.Products.Any(x => x.SupplierID == product.SupplierID
                                                && x.ProductName == product.ProductName);

            if (exists)
            {
                throw new ArgumentException("Product already exists, cannot add.");
            }

            //You can check multiple Business rules
            //You can reuse the exists bool if needed

            //Staging
            //IMPORTANT - Remember this is only local, meaning it is only local in memory not in the database
            //This product will not have an ID
            _context.Products.Add(product);

            //Commit
            //This sends the data to the database
            //The info for the changes or inserted records is updated in our DBSet (Products)
            _context.SaveChanges();

            //Now the new product will have an ID
            return product.ProductID;
        }
        #endregion
    }
}
