using BullsAndCowsGame.Core.Models.Interfaces;

namespace BullsAndCowsGame.Core.Factories.Interfaces
{
    public interface IRiddleProviderFactory
    {
        IRiddleProvider CreateRiddleProvider();
    }
}