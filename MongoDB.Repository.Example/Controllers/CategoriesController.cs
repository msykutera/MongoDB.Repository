using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MongoDB.Repository.Example
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IRepository<Category> _repository;

        public CategoriesController(IRepository<Category> repository)
        {
            _repository = repository;
        }

        [HttpGet("getAll")]
        public IEnumerable<CategoryViewModel> Get()
        {
            var categories = _repository.AsQueryable()
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
            var category = _repository.GetById(id);
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
            _repository.Add(category);
        }

        [HttpDelete("delete/{id}")]
        public void Delete(string id)
        {
            _repository.Delete(id);
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
            _repository.Update(category);
        }
    }
}