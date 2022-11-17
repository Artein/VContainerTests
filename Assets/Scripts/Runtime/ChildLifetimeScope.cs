using VContainer;
using VContainer.Unity;

namespace Runtime
{
    public class ChildLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // nothing to do for now
            UnityEngine.Debug.Log($"{nameof(ChildLifetimeScope)}: Configure()", this);
        }
    }
}