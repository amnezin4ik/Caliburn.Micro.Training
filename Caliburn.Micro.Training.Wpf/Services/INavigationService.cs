namespace Caliburn.Micro.Training.Wpf.Services
{
    public interface INavigationService
    {
        void Initialize(IConductor conductor);
        void Navigate<T>(params global::Autofac.Core.Parameter[] parameters) where T : IScreen;
    }
}
