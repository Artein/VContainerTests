using System;
using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace Runtime
{
    public class ChangeSceneByButtonClickedController : IInitializable, IDisposable
    {
        [Inject] private InputManager _inputManager;
        [Inject] private LoadSceneCommand _loadSceneCommand;

        void IInitializable.Initialize()
        {
            _inputManager.MousePrimaryButtonClicked += OnMousePrimaryButtonClicked;
        }

        void IDisposable.Dispose()
        {
            _inputManager.MousePrimaryButtonClicked -= OnMousePrimaryButtonClicked;
        }

        private void OnMousePrimaryButtonClicked()
        {
            _loadSceneCommand.PerformAsync(default).Forget();
        }
    }
}