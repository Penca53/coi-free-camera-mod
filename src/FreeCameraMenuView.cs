using Mafi.Unity.UiFramework;
using Mafi.Unity.UiFramework.Components;
using Mafi.Unity.UserInterface;
using Mafi.Unity.Camera;

namespace FreeCameraMod
{
    public class FreeCameraMenuView : WindowView
    {
        private OrbitalCameraModel _cameraModel = null;

        private StackContainer _container = null;
        private SwitchBtn _btn = null;

        public FreeCameraMenuView(OrbitalCameraModel cameraModel) : base("CameraMenu", noHeader: true)
        {
            _cameraModel = cameraModel;
        }

        protected override void BuildWindowContent()
        {
            _container = Builder.NewStackContainer("CameraControllerContainer")
               .SetStackingDirection(StackContainer.Direction.TopToBottom)
               .SetSizeMode(StackContainer.SizeMode.StaticDirectionAligned)
               .SetItemSpacing(5f)
               .SetInnerPadding(new Offset(15, 15, 15, 15))
               .SetBackground(Mafi.ColorRgba.TransparentBlack)
               .PutTo(GetContentPanel());

            Builder.NewTitle("CameraControllerTitle")
                .SetText("Camera Controller")
                .SetPreferredSize()
                .AppendTo(_container);

            Builder.NewTitle("CameraControllerLabel")
                .SetText("Camera Mode")
                .SetPreferredSize()
                .SetFontSize(9)
                .AppendTo(_container);

            _btn = Builder.NewSwitchBtn()
                .SetText("Unconstrained")
                .AddTooltip("Default: constrained movement\nUnconstrained: free movement")
                .SetOnToggleAction(OnSwitchCameraModeBtnToggle)
                .AppendTo(_container);

            // Trick: we set initial text to "Unconstrained" to set the tooltip position to its right.
            // Since the string "Unconstrained" is larger than "Default" we use the first one to prevent 
            // overlapping the text and tooltip when changing the label when the switch is toggled
            _btn.SetText("Default");

            SetContentSize(200f, _container.GetDynamicHeight());
            PositionSelfToCenter();
        }

        private void OnSwitchCameraModeBtnToggle(bool state)
        {
            CameraMode cameraMode;
            if (!state)
            {
                cameraMode = CameraMode.DefaultGameplay;
                _btn.SetText("Default");
            }
            else
            {
                cameraMode = CameraMode.Unconstrained;
                _btn.SetText("Unconstrained");
            }
            _cameraModel.SetMode(cameraMode);
            _btn.SetIsOn(state);
        }
    }
}
