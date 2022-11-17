using System;

namespace Runtime
{
    public class DisposableAction : IDisposable
    {
        private Action _action;

        public DisposableAction(Action action)
        {
            _action = action;
        }
        
        public void Dispose()
        {
            if (_action != null)
            {
                _action.Invoke();
                _action = null;
            }
        }
    }
}