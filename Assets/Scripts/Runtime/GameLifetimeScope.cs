using Eflatun.SceneReference;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Runtime
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private SceneReference _sceneRef;
        [SerializeField] private UnityComponent _unityComponent;
        [SerializeField] private GameObject _instancePrefab;
        
        protected override void Configure(IContainerBuilder builder)
        {
            UnityEngine.Debug.Log($"{nameof(GameLifetimeScope)}: Configure()", this);
            
            // Zenject: Container.Bind<Foo>().AsSingle();
            builder.Register<PlainClassInjectionReceiver>(Lifetime.Singleton).AsImplementedInterfaces();
            
            // Register all special VContainer interfaces
            builder.RegisterEntryPoint<AllSpecialInterfacesReceiver>();

            // Zenject: Container.Bind<IBar>().To<Bar>().AsSingle();
            builder.Register<IBar, Bar>(Lifetime.Singleton);
            
            // Zenject: Container.Camera<Foo>().FromComponentInHierarchy().AsSingle();
            // RegisterComponentInHierarchy always has a Scoped lifetime because the lifetime is equal to the scene.
            builder.RegisterComponentInHierarchy<Camera>();

            // Register transient copy (unique for each request)
            builder.Register<LoadSceneCommand>(Lifetime.Transient).AsSelf();

            // Register InputManager and all its interfaces
            builder.Register<InputManager>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            // Instance registration
            builder.RegisterInstance(_sceneRef);
            
            builder.Register<ChangeSceneByButtonClickedController>(Lifetime.Singleton).AsImplementedInterfaces();
            
            // WithParameter provides arguments to constructor or constructor method only
            // MISSING: Providing additional parameters that injects via field or property
            builder.Register<InstantiatePrefabOnSpaceKeyClick>(Lifetime.Singleton).WithParameter(_instancePrefab).AsImplementedInterfaces();

            // Passing named parameter
            builder.Register<InstantiatePrefabOnKeyClick>(Lifetime.Singleton).WithParameter(_instancePrefab).WithParameter("keyCode", KeyCode.W)
                .AsImplementedInterfaces();

            // Register unity component. In this case, the registered MonoBehaviour will both Inject and be Injected into other classes.
            builder.RegisterComponent(_unityComponent);
            
            // MISSING: Registration with execution order
            // builder.RegisterEntryPoint<AAAA>(ExecutionOrder);

            // TODO: Registration with Scoped lifetime
            // TODO: Registering with id
            // TODO: Prefab instantiation
            // TODO: Prefab instantiation with arguments/parameters/named parameter
            // TODO: Class instantiation
            // TODO: Class instantiation with arguments/parameters/named parameter
            // TODO: Scopes parenting
            // TODO: Optional injection
            // TODO: Check IDisposable : With container disposes. (For Lifetime.Singleton / Lifetime.Scoped)
            // TODO: Manual running of XLifetimeScope (AutoRun is disabled)
        }
    }
}