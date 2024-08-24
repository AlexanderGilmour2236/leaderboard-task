using System;
using System.Threading.Tasks;
using SimplePopupManager;
using UnityEngine;
using UnityEngine.UI;

namespace LeaderboardTask
{
    public class MainMenu : MonoBehaviour, IPopupInitialization
    {
        [SerializeField] private Button _openLeaderboardButton;
        
        private LeaderboardPresenter _leaderboardPresenter;

        private void Awake()
        {
            _openLeaderboardButton.onClick.AddListener(OnOpenLeaderboardButtonClick);
        }

        private void OnOpenLeaderboardButtonClick()
        {
            _leaderboardPresenter?.OnOpenButtonClick();
        }

        public async Task Init(object param)
        {
            _leaderboardPresenter = (LeaderboardPresenter) param;
            
            await Task.CompletedTask;
        }
    }
}