using System.Collections.Generic;
using System.Threading.Tasks;
using FarmFresh.Context;
using FarmFresh.Dto.ProductDto;
using FarmFresh.Interfaces.Repo;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FarmFresh.Dto;
using Microsoft.AspNetCore.Http;
using FarmFresh.Models;
using System;

namespace FarmFresh.Repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly FarmFreshContext _context;
        public ProductRepo(FarmFreshContext context)
        {
            _context=context;
        }
        public async Task<List<GetProductListResponse>> GetProductList(GetProductListRequest request)
        {
           
            //if product name is not null or empty will search with product name
            //if category id not equal 0 will search with category id
            
            return await _context.Product
            .Where(x=> 
            (string.IsNullOrEmpty(request.ProductName) || x.Name.Contains(request.ProductName))
            && (request.CategoryId==0 || x.CategoryId==request.CategoryId)
            ).Select(x=>new GetProductListResponse{
                Id=x.Id,
                Name=x.Name,
                ProductUrl=x.ProductUrl,
                UnitName=_context.Unit.Where(u=>u.Id==x.UnitId).Select(u=>u.Name).SingleOrDefault(),
                CategoryName=_context.Category.Where(u=>u.Id==x.CategoryId).Select(u=>u.Name).SingleOrDefault()
            })
            .Skip((request.PageNumber-1)*request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        }
        public async Task<List<GetCategoryListResponse>> GetCategoryList()
        {
            return await _context.Category.Select(x=>new GetCategoryListResponse{
                Id=x.Id,
                Name=x.Name
            })
            .ToListAsync();
        }

        public async Task<ResponseStatus> CreateProduct(CreateProductRequest request)
        {

            //image file should store on file server (aws s3, google drive,...)
            //because of time limitation, i will implement upload file server later

            var response=new ResponseStatus();
            var product=new Product(){
                Name=request.Name,
                ProductUrl=request.ProductUrl,
                Description=request.Description,
                CategoryId=request.CategoryId,
                UnitId=request.UnitId,
                CreatedBy=1,
                CreatedDate=DateTime.Now
            };
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<ResponseStatus> UpdateProduct(UpdateProductRequest request)
        {
            //image file should store on file server (aws s3, google drive,...)
            //because of time limitation, i will implement upload file server later
            
            var response=new ResponseStatus();
            var product=await _context.Product.Where(x=>x.Id==request.Id).SingleOrDefaultAsync();
            if(product!=null)
            {
                product.Name=request.Name;
                product.ProductUrl=request.ProductUrl;
                product.Description=request.Description;
                product.CategoryId=request.CategoryId;
                product.UnitId=request.UnitId;
                product.UpdatedBy=1;
                product.UpdatedDate=DateTime.Now;
                await _context.SaveChangesAsync();
                response.StatusCode=StatusCodes.Status200OK;
                response.Message="Successfully updated.";
            }
            else{
                response.StatusCode=StatusCodes.Status400BadRequest;
                response.Message="Product is not found.";
            }
            return response;
        }

        public async Task<ResponseStatus> DeleteProduct(int productId)
        {
            var response=new ResponseStatus();
            var product=await _context.Product.Where(x=>x.Id==productId).SingleOrDefaultAsync();
            if(product!=null)
            {
                product.IsDelete=true;
                await _context.SaveChangesAsync();
                response.StatusCode=StatusCodes.Status200OK;
                response.Message="Successfully deleted.";
            }
            else{
                response.StatusCode=StatusCodes.Status400BadRequest;
                response.Message="Product is not found.";
            }
            return response;
        }
    }
}