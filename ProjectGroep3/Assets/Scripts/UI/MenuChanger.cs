using UnityEngine;
using Utilities;
using StateMachineNameSpace;

namespace MenuHandler
{
    public class MenuChanger : MonoBehaviour
    {
        private StateMachine _stateMachine;

        private MenuManager _menuManager;

        [SerializeField]
        private Menu _mainMenu;
        [SerializeField]
        private Menu _gameMenu;
        [SerializeField]
        private Menu _pauseMenu;
        [SerializeField]
        private Menu _gameOverMenu;

        private void Start()
        {
            _stateMachine = StateMachine.Instance;
            _menuManager = MenuManager.Instance;

            _stateMachine.OnStateSet += StateChanged;
        }

        private void OnDisable() => _stateMachine.OnStateSet -= StateChanged;

        private void StateChanged(StateMachineState changedState)
        {
            switch (changedState)
            {
                case StateMachineState.MAIN_MENU:
                    _menuManager.OpenMenu(_gameMenu);
                    _menuManager.OpenMenuNoClose(_mainMenu);
                    break;

                case StateMachineState.GAME:
                    _menuManager.OpenMenu(_gameMenu);
                    break;

                case StateMachineState.PAUSED:
                    _menuManager.OpenMenu(_pauseMenu);
                    break;

                case StateMachineState.GAME_OVER:
                    _menuManager.OpenMenu(_gameMenu);
                    _menuManager.OpenMenuNoClose(_gameOverMenu);
                    break;
            }
        }
    }
}