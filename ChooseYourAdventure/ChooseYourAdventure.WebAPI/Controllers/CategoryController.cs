using ChooseYourAdventure.Core.Commands.Categories.CreateCategory;
using ChooseYourAdventure.Core.Commands.Categories.Queries.GetCategories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChooseYourAdventure.WebAPI.Controllers
{
    public class CategoryController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateCategoryCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> Get()
        {
            return await Mediator.Send(new GetCategoriesQuery()).ConfigureAwait(false);
        }
    }
}