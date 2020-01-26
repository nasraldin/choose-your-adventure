using System.Threading.Tasks;

namespace ChooseYourAdventure.Core.Common.Interfaces
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
