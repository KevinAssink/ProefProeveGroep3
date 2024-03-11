using UnityEngine.InputSystem;

namespace InputNameSpace
{
    public class InputComponent : SingletonBehaviour<InputComponent>
    {
        //--------------------Private--------------------//
        private GameInput _gameInput;

        private InputAction _onTouchScreenPress;

        //--------------------Public--------------------//
        public InputAction OnTouchScreenPress
        {
            get => _onTouchScreenPress;
            set => _onTouchScreenPress = value;
        }

        //--------------------Functions--------------------//
        private void Awake()
        {
            _gameInput = new GameInput();

            _onTouchScreenPress = _gameInput.Player.TouchScreenPress;
        }

        private void OnEnable() => _onTouchScreenPress.Enable();

        private void OnDisable() => _onTouchScreenPress.Disable();
    }
}