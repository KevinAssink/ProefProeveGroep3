using UnityEngine.InputSystem;

namespace Input
{
    public class InputComponent : SingletonBehaviour<InputComponent>
    {
        //--------------------Private--------------------//
        private GameInput _gameInput;

        private InputAction _swipeTest;
        //--------------------Public--------------------//
        public InputAction SwipeTest
        {
            get => _swipeTest;
            set => _swipeTest = value;
        }

        //--------------------Functions--------------------//
        private void Awake()
        {
            _gameInput = new GameInput();

            _swipeTest = _gameInput.Player.Swipe;
        }

        private void OnEnable()
        {
            _swipeTest.Enable();
        }

        private void OnDisable()
        {
            _swipeTest.Disable();
        }
    }
}