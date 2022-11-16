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
            _inputManager.ButtonClicked += OnButtonClicked;
        }

        void IDisposable.Dispose()
        {
            _inputManager.ButtonClicked -= OnButtonClicked;
        }

        private void OnButtonClicked()
        {
            _loadSceneCommand.PerformAsync(default).Forget();
        }
    }
}