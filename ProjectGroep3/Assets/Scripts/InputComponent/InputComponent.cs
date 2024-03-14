using UnityEngine.InputSystem;

namespace InputNameSpace
{
    public class InputComponent : SingletonBehaviour<InputComponent>
    {
        //--------------------Private--------------------//
        private GameInput _gameInput;

        private InputAction _onTouchScreenPress;
        private InputAction _onScreenSwipeRight;

        //--------------------Public--------------------//
        public InputAction OnTouchScreenPress
        {
            get => _onTouchScreenPress;
            set => _onTouchScreenPress = value;
        }
        public InputAction OnScreenSwipeRight
        {
            get => _onScreenSwipeRight;
            set => _onScreenSwipeRight= value;
        }

        //--------------------Functions--------------------//
        private void Awake()
        {
            _gameInput = new GameInput();

            _onTouchScreenPress = _gameInput.Player.TouchScreenPress;
            _onScreenSwipeRight = _gameInput.Player.SwipeRight;
        }

        private void OnEnable()
        {
            _onTouchScreenPress.Enable();
            _onScreenSwipeRight.Enable();
        }

        private void OnDisable()
        {
            _onTouchScreenPress.Disable();
            _onScreenSwipeRight.Disable();
        }
    }
}