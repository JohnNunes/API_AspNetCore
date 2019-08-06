using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.Repositories;

namespace ProductCatalog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/categories")]
        [HttpGet]
        [ResponseCache(Duration = 3600)]
        public IEnumerable<Category> Get()
        {
            //return _context.Categories.AsNoTracking().ToList();
            return _repository.Get();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category Get(int id)
        {
            // Find() ainda não suporta AsNoTracking
            //return _context.Categories.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            return _repository.Get(id);
        }

        [Route("v1/categories")]
        [HttpPost]
        public Category Post([FromBody]Category category)
        {
            //_context.Categories.Add(category);
            //_context.SaveChanges();
            _repository.Save(category);
            return category;
        }

        [Route("v1/categories")]
        [HttpPut]
        public Category Put([FromBody]Category category)
        {
            //_context.Entry<Category>(category).State = EntityState.Modified;
            //_context.SaveChanges();
            _repository.Update(category);
            return category;
        }

        [Route("v1/categories")]
        [HttpDelete]
        public Category Delete([FromBody]Category category)
        {
            //_context.Categories.Remove(category);
            //_context.SaveChanges();
            _repository.Delete(category);

            return category;
        }
    }
}