using APIKhipo.Models;
using APIKhipo.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIKhipo.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        KHIDBContext db;
        public ProductsRepository(KHIDBContext _db)
        {
            db = _db;
        }

        // public async Task<List<Products>> GetProducts()
        // {
        //     if (db != null)
        //     {
        //         return await db.Products.ToListAsync();
        //     }

        //     return null;
        // }

        public async Task<List<Products>> GetProducts()
        {
            if (db != null)
            {
                return await (from p in db.Products  
                              select new Products
                              {
                                  createdAt = p.createdAt,
                                  name = p.name,
                                  price = p.price,
                                  brand = p.brand,
                                  updatedAt = p.updatedAt
                              }).ToListAsync();
            }

            return new List<Products>();
        }

        public async Task<Products?> GetProduct(long? Id)
        {
            if (db != null)
            {
                return await (from p in db.Products                              
                              where p.id == Id
                              select new Products
                              {
                                  createdAt = p.createdAt,
                                  name = p.name,
                                  price = p.price,
                                  brand = p.brand,
                                  updatedAt = p.updatedAt
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<long> AddProduct(Products prod)
        {
            if (db != null)
            {
                await db.Products.AddAsync(prod);
                await db.SaveChangesAsync();

                return prod.id;
            }

            return 0;
        }

        public async Task<long> DeleteProduct(long? Id)
        {
            int result = 0;

            if (db != null)
            {
                //Find the Products for specific Products id
                var Product = await db.Products.FirstOrDefaultAsync(x => x.id == Id);

                if (Product != null)
                {
                    //Delete that Products
                    db.Products.Remove(Product);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task<Products> UpdateProduct(Products prod)
        {
            if (db != null)
            {
                //Delete that Products
                db.Products.Update(prod);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
            return prod;
        }
    }
}