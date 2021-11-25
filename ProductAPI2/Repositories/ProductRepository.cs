using Microsoft.EntityFrameworkCore;
using ProductAPI2.DbContexts;
using ProductAPI2.Models;
using ProductAPI2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI2.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext db;

        public ProductRepository(ProductContext _db)
        {
            db = _db;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await db.Products.Where(p=>p.Id==id).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return product;
        }
    }
}
