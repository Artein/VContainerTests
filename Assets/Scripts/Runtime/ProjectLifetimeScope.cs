using VContainer;
using VContainer.Unity;

namespace Runtime
{
    public class ProjectLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Registration that will survive any scene change
            UnityEngine.Debug.Log($"{nameof(ProjectLifetimeScope)}: Configure()", this);
        }
    }
}