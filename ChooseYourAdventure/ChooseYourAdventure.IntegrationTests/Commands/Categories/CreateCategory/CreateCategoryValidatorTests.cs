using ChooseYourAdventure.Core.Commands.Categories.CreateCategory;
using ChooseYourAdventure.Core.Entities;
using Shouldly;
using Xunit;

namespace ChooseYourAdventure.IntegrationTests.Commands.Categories.CreateCategory
{
    public class CreateCategoryValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenListNameIsUnique()
        {
            var command = new CreateCategoryCommand
            {
                Name = "Cat 1"
            };

            var validator = new CreateCategoryValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenListNameIsNotUnique()
        {
            Context.Categories.Add(new Category { Name = "Cat 1" });
            Context.SaveChanges();

            var command = new CreateCategoryCommand
            {
                Name = "Cat 1"
            };

            var validator = new CreateCategoryValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
