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
        
        protected override void Configure(IContainerBuilder builder)
        {
            // Register IStartable + IAsyncStartable
            builder.RegisterEntryPoint<GameEntryPoint>();
            
            // Zenject: Container.Bind<Foo>().AsSingle();
            builder.Register<Foo>(Lifetime.Singleton);

            // Zenject: Container.Bind<IBar>().To<Bar>().AsSingle();
            builder.Register<IBar, Bar>(Lifetime.Singleton);
            
            // Zenject: Container.Camera<Foo>().FromComponentInHierarchy().AsSingle();
            builder.RegisterComponentInHierarchy<Camera>();

            // Register transient copy (unique for each request)
            builder.Register<LoadSceneCommand>(Lifetime.Transient).AsSelf();

            // Register ITickable
            builder.Register<InputManager>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.RegisterInstance(_sceneRef);
            
            builder.Register<ChangeSceneByButtonClickedController>(Lifetime.Singleton).AsImplementedInterfaces();

            // Register unity component
            builder.RegisterComponent(_unityComponent);

            // TODO: Check
            // builder.Register<Bar>(Lifetime.Scoped);

            // TODO: Registering with id
            // TODO: Prefab instantiation
            // TODO: Prefab instantiation with arguments
            // TODO: Class instantiation
            // TODO: Class instantiation with arguments
            // TODO: Scopes parenting
        }
    }
}