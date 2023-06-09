﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPINorthwind.DesingPatterns.SingletonPattern;
using WebAPINorthwind.Models;
using WebAPINorthwind.RequestModels;
using WebAPINorthwind.ResponseModels;

namespace WebAPINorthwind.Controllers
{
    public class CategoryController: ApiController
    {
        NorthwindEntities _db;
        public CategoryController()
        {
            _db = DBTool.DBInstance;
        }

        List<CategoryResponseModel> ListCategories()
        {
            return _db.Categories.Select(x => new CategoryResponseModel
            {
                ID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();
        }

        [HttpGet]
        public List<CategoryResponseModel> BringCategories()
        {
            return ListCategories();


        }

        [HttpGet]
        public CategoryResponseModel GetCategory(int id) 
        {
            return _db.Categories.Where(x => x.CategoryID == id).Select(x => new CategoryResponseModel
            {
                ID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).FirstOrDefault();
        }
        [HttpPost]

        public List<CategoryResponseModel> AddCategory(CategoryCreateRequestModel item)
        {
            Category c = new Category
            {
                CategoryName = item.CategoryName,
                Description = item.Description
            };
            _db.Categories.Add(c);
            _db.SaveChanges();
            return ListCategories();
        }
        [HttpPut]
        public List<CategoryResponseModel> UpdateCategory(CategoryUpdateRequestModel item)
        {
            Category guncellenecek = _db.Categories.Find(item.ID);
            guncellenecek.CategoryName = item.CategoryName;
            guncellenecek.Description = item.Description;
            _db.SaveChanges();

            return ListCategories();
        }
        [HttpDelete]

        public List<CategoryResponseModel> DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return ListCategories();
        }

        [HttpGet]

        public List<CategoryResponseModel> SearchCategory(string item)
        {
            return _db.Categories.Where(x => x.CategoryName.Contains(item)).Select(x => new CategoryResponseModel
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                ID = x.CategoryID
            }).ToList();
        }
    }
}