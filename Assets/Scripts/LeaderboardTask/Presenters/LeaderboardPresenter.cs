using System;
using System.Collections.Generic;
using System.Linq;
using LeaderboardTask.Services;
using LeaderboardTask.View;
using UnityEngine;

namespace LeaderboardTask
{
    public class LeaderboardPresenter : ILeaderboardPresenter
    {
        private readonly LeaderboardSceneController _leaderboardSceneController;
        private readonly ILeaderboardDataService _leaderboardDataService;
        private readonly UiFactory _uiFactory;
        
        private List<LeaderboardEntryData> _leaderboardEntryDataCollection;
        private IConfigService _configService;

        public event Action<string> PopUpChange;

        public LeaderboardPresenter(LeaderboardSceneController leaderboardSceneController, 
            ILeaderboardDataService leaderboardDataService, UiFactory uiFactory, IConfigService configService)
        {
            _leaderboardSceneController = leaderboardSceneController;
            _leaderboardDataService = leaderboardDataService;
            _uiFactory = uiFactory;
            _configService = configService;
        }

        public List<LeaderboardEntryData> GetLeaderboardEntryDataCollection(bool update = false)
        {
            if (update || _leaderboardEntryDataCollection == null || _leaderboardEntryDataCollection.Count == 0)
            {
                _leaderboardEntryDataCollection =
                    _leaderboardDataService.GetLeaderboardDataEntries().OrderByDescending(entryData => entryData.Score).ToList();
            }

            return _leaderboardEntryDataCollection;
        }

        public LeaderboardEntryView[] GetLeaderboardEntryViews(List<LeaderboardEntryData> entryDataCollection)
        {
            LeaderboardEntryView[] leaderboardEntryViewCollection 
                = new LeaderboardEntryView[entryDataCollection.Count];
            
            for (var entryIndex = 0; entryIndex < entryDataCollection.Count; entryIndex++)
            {
                LeaderboardEntryData leaderboardEntryData = entryDataCollection[entryIndex];
                LeaderboardEntryView leaderboardEntryView = _uiFactory.CreateLeaderboardEntryView();
                
                leaderboardEntryView.Initialize(new LeaderboardEntryPresenter(leaderboardEntryData, this, _configService));
                leaderboardEntryViewCollection[entryIndex] = leaderboardEntryView;
            }

            return leaderboardEntryViewCollection;
        }

        public void OnOpenButtonClick()
        {
            _leaderboardSceneController.OpenLeaderboard();
        }

        public void OnCloseButtonClick()
        {
            _leaderboardSceneController.CloseLeaderboard();
        }

        public int GetPlayerPlaceInLeaderboard(LeaderboardEntryData leaderboardEntryData)
        {
            return _leaderboardEntryDataCollection.IndexOf(leaderboardEntryData);
        }
    }
}
