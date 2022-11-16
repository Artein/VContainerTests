using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Runtime
{
    public class AllSpecialInterfacesReceiver : IInitializable, IPostInitializable, IStartable, IAsyncStartable, IPostStartable, IFixedTickable, 
        IPostFixedTickable, ITickable, IPostTickable, ILateTickable, IPostLateTickable, IDisposable
    {
        private readonly List<string> _messagesSent = new();
        
        // 1
        void IInitializable.Initialize()
        {
            LogSingle($"{nameof(AllSpecialInterfacesReceiver)}: 1. Received IInitializable.Initialize()");
        }

        // 2
        void IPostInitializable.PostInitialize()
        {
            LogSingle($"{nameof(AllSpecialInterfacesReceiver)}: 2. Received IPostInitializable.PostInitialize()");
        }
        
        // 3
        void IStartable.Start()
        {
            LogSingle($"{nameof(AllSpecialInterfacesReceiver)}: 3. Received IStartable.Start()");
        }

        // 4
        async UniTask IAsyncStartable.StartAsync(CancellationToken cancellation)
        {
            LogSingle($"{nameof(AllSpecialInterfacesReceiver)}: 4. Received IAsyncStartable.StartAsync()");
            
            await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: cancellation);
        }

        // 5
        void IPostStartable.PostStart()
        {
            LogSingle($"{nameof(AllSpecialInterfacesReceiver)}: 5. Received IPostStartable.PostStart()");
        }

        // 6
        void IFixedTickable.FixedTick()
        {
            LogSingle($"{nameof(AllSpecialInterfacesReceiver)}: 6. Received IFixedTickable.FixedTick()");
        }

        // 7
        void IPostFixedTickable.PostFixedTick()
        {
            LogSingle($"{nameof(AllSpecialInterfacesReceiver)}: 7. Received IPostFixedTickable.PostFixedTick()");
        }

        // 8
        void ITickable.Tick()
        {
            LogSingle($"{nameof(AllSpecialInterfacesReceiver)}: 8. Received ITickable.Tick()");
        }

        // 9
        void IPostTickable.PostTick()
        {
            LogSingle($"{nameof(AllSpecialInterfacesReceiver)}: 9. Received IPostTickable.PostTick()");
        }

        // 10
        void ILateTickable.LateTick()
        {
            LogSingle($"{nameof(AllSpecialInterfacesReceiver)}: 10. Received ILateTickable.LateTick()");
        }

        // 11
        void IPostLateTickable.PostLateTick()
        {
            LogSingle($"{nameof(AllSpecialInterfacesReceiver)}: 11. Received IPostLateTickable.PostLateTick()");
        }

        // 12
        void IDisposable.Dispose()
        {
            LogSingle($"{nameof(AllSpecialInterfacesReceiver)}: 12. Received IDisposable.Dispose()");
        }

        private void LogSingle(string message)
        {
            if (!_messagesSent.Contains(message))
            {
                _messagesSent.Add(message);
                UnityEngine.Debug.Log(message);
            }
        }
    }
}