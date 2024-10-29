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
        #endregion
    }
}
