using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Runtime
{
    public class GameEntryPoint : IStartable, IAsyncStartable
    {
        private readonly Foo _foo;

        // Supports constructor injection
        public GameEntryPoint(Foo foo)
        {
            UnityEngine.Debug.Log($"{nameof(GameEntryPoint)} CTOR with foo={foo}");
            _foo = foo;
        }
        
        void IStartable.Start()
        {
            UnityEngine.Debug.Log($"{nameof(GameEntryPoint)} Received IStartable.Start()");
            _foo.Validate();
        }

        async UniTask IAsyncStartable.StartAsync(CancellationToken cancellation)
        {
            UnityEngine.Debug.Log($"{nameof(GameEntryPoint)} Received IAsyncStartable.StartAsync()");
            
            await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: cancellation);
        }
    }
}