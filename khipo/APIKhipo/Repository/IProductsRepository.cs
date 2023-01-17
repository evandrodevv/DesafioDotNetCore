using APIKhipo.Models;
using APIKhipo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIKhipo.Repository
{
    public interface IProductsRepository
    {
        Task<List<Products>> GetProducts();        

        Task<Products?> GetProduct(long? Id);

        Task<long> AddProduct(Products prods);

        Task<long> DeleteProduct(long? Id);

        Task<Products> UpdateProduct(Products prods);
    }
}