using Mafi.Core.Input;
using Mafi.Unity.Camera;
using Mafi.Unity.InputControl;
using Mafi.Unity.UiFramework;
using Mafi.Unity.UserInterface;

namespace FreeCameraMod
{
    public class FreeCameraMenuController : IUnityInputController, IUnityUi
    {
        private readonly OrbitalCameraModel _cameraModel;
        private FreeCameraMenuView _view;

        public FreeCameraMenuController(OrbitalCameraModel cameraModel)
        {
            _cameraModel = cameraModel;
        }

        public ControllerConfig Config => new()
        {
            DeactivateOnOtherControllerActive = true,
            DeactivateOnNonUiClick = true,
            AllowInspectorCursor = false,
        };

        public void Activate()
        {
            _view.Show();
        }

        public void Deactivate()
        {
            _view.Hide();
        }

        public bool InputUpdate(IInputScheduler inputScheduler)
        {
            return false;
        }

        public void RegisterUi(UiBuilder builder)
        {
            _view = new FreeCameraMenuView(_cameraModel);
            _view.BuildUi(builder);
        }
    }
}
