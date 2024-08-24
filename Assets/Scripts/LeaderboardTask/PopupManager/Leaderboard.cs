using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeaderboardTask.View;
using SimplePopupManager;
using UnityEngine;
using UnityEngine.UI;

namespace LeaderboardTask
{
    public class Leaderboard : MonoBehaviour, IPopupInitialization
    {
        [SerializeField] private Transform _entriesParent;
        [SerializeField] private Button _closeButton;

        private LeaderboardEntryView[] _currentLeaderboardEntryViews;
        private ILeaderboardPresenter _leaderboardPresenter;

        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnCloseButtonClick()
        {
            _leaderboardPresenter?.OnCloseButtonClick();
        }

        public Task Init(object param)
        {
            _leaderboardPresenter = (ILeaderboardPresenter) param;
            CreateLeaderboardEntries(_leaderboardPresenter);
            
            return Task.CompletedTask;
        }

        private void CreateLeaderboardEntries(ILeaderboardPresenter leaderboardPresenter)
        {
            List<LeaderboardEntryData> entryDataCollection = leaderboardPresenter.GetLeaderboardEntryDataCollection();
            _currentLeaderboardEntryViews = leaderboardPresenter.GetLeaderboardEntryViews(entryDataCollection);
            
            foreach (LeaderboardEntryView leaderboardEntryView in _currentLeaderboardEntryViews)
            {
                leaderboardEntryView.transform.SetParent(_entriesParent, false);
            }
        }
    }
}