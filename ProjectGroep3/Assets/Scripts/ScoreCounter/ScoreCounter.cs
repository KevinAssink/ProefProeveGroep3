using UnityEngine;
using StateMachineNameSpace;
using Utilities;

namespace Score
{
    public class ScoreCounter : SingletonBehaviour<ScoreCounter>
    {
        //--------------------Private--------------------//
        [SerializeField]
        private float _scoreMultiplier;
        private float _score;
        private float _highscore;
        private float _elapsedTime;

        private StateMachine _stateMachine;

        //--------------------Public--------------------//
        public float Score => _score;
        public float HighScore => _highscore;

        //--------------------Functions--------------------//
        private void Awake() => _highscore = PlayerPrefs.GetFloat("HighScore");
        
        private void Start()
        {
            _stateMachine = StateMachine.Instance;
            _stateMachine.OnStateSet += StateMachineStateChanged;
        }

        private void OnDisable() => _stateMachine.OnStateSet -= StateMachineStateChanged;

        private void Update()
        {
            if(_stateMachine.CurrentState == StateMachineState.GAME)
            {
                _elapsedTime += Time.deltaTime;
                CalculateScore();
            }
        }

        private void StateMachineStateChanged(StateMachineState changedState)
        {
            if(changedState == StateMachineState.GAME_OVER)
                CalculateHighScore();
        }

        private void CalculateScore()
        {
            _score = _elapsedTime * _scoreMultiplier;
        }

        private void CalculateHighScore()
        {
            if (_score > _highscore)
                _highscore = _score;

            SaveHighScore();
        }

        private void SaveHighScore() => PlayerPrefs.SetFloat("HighScore", _highscore);
    }
}