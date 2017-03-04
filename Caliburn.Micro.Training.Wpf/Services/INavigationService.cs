namespace Caliburn.Micro.Training.Wpf.Services
{
    public interface INavigationService
    {
        void Initialize(IConductor conductor);
        void Navigate<T>(params object[] parameters) where T : IScreen;
    }
}
