using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MongoDB.Repository.Example
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoriesController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("getAll")]
        public IEnumerable<CategoryViewModel> Get()
        {
            var categories = _categoryRepository.AsQueryable()
                .Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.Status,
                });

            return categories;
        }

        [HttpGet("get/{id}")]
        public CategoryViewModel Get(string id)
        {
            var category = _categoryRepository.GetById(id);
            var model = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Status = category.Status,
            };
            return model;
        }

        [HttpPost("add")]
        public void Add([FromBody] CategoryViewModel model)
        {
            var category = new Category
            {
                Name = model.Name,
                Status = model.Status,
            };
            _categoryRepository.Add(category);
        }

        [HttpDelete("delete/{id}")]
        public void Delete(string id)
        {
            _categoryRepository.Delete(id);
        }

        [HttpPut("update")]
        public void Update([FromBody] CategoryViewModel model)
        {
            var category = new Category
            {
                Id = model.Id,
                Name = model.Name,
                Status = model.Status,
            };
            _categoryRepository.Update(category);
        }
    }
}