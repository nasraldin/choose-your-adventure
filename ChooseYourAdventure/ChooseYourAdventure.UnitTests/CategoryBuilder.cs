using ChooseYourAdventure.Core.Entities;

namespace ChooseYourAdventure.UnitTests
{
    // Learn more about test builders:
    // https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    public class CategoryBuilder
    {
        private Category _category = new Category();

        public CategoryBuilder Id(int id)
        {
            _category.Id = id;
            return this;
        }

        public CategoryBuilder Name(string name)
        {
            _category.Name = name;
            return this;
        }

        public CategoryBuilder WithDefaultValues()
        {
            _category = new Category() { Id = 1, Name = "Test Item" };

            return this;
        }

        public Category Build() => _category;
    }
}
