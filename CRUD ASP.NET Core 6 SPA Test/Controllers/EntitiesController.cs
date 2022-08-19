using CRUD_ASP.NET_Core_6_SPA_Test.Data;
using CRUD_ASP.NET_Core_6_SPA_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_ASP.NET_Core_6_SPA_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntitiesController : Controller
    {
        private IRepository _repository;
        public EntitiesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<EntityObject>>> Get(int skip = 0, int take = 0)
        {
            if (take > 0) 
                return await _repository.EntityObjects.Skip(skip).Take(take).ToListAsync();
            return await _repository.EntityObjects.ToListAsync();
        }

        [HttpGet("HasCategoryId/{id}")] 
        [Produces("application/json")]
        public async Task<IEnumerable<EntityObject>> GetHasCategoryId(int id, int skip = 0, int take = 0)
        {
            var entities = from entity in _repository.EntityObjects
                         where entity.InCategories.Contains(new Category { Id = id })
                         select entity;
            var result = take <= 0 ? entities : entities.Skip(skip).Take(take);
            var resultList = await result.ToListAsync();
            foreach (var entity in resultList)
            {
                entity.InCategories = (from category in _repository.Categories
                                       where category.HasEntityObjects.Contains(new EntityObject { Id = entity.Id })
                                       select category).ToList();
            }
            return resultList;
        }
    }
}
