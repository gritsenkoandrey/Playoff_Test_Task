using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Installers.Scopes
{
    public sealed class BootstrapScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.RegisterEntryPoint<EntryPoint>(Lifetime.Scoped);
        }
    }
}