using LeaderboardTask.View;
using UnityEngine;

namespace LeaderboardTask
{
    public class UiFactory
    {
        private LeaderboardEntryView _leaderboardEntryViewPrefab;
        
        private LeaderboardEntryView LoadLeaderboardEntryViewPrefab()
        {
            return Resources.Load<LeaderboardEntryView>(LeaderboardResourcePath.LeaderboardEntryView);
        }
        
        public LeaderboardEntryView CreateLeaderboardEntryView()
        {
            if (_leaderboardEntryViewPrefab == null)
            {
                _leaderboardEntryViewPrefab = LoadLeaderboardEntryViewPrefab();
            }

            LeaderboardEntryView leaderboardEntryView = Object.Instantiate(_leaderboardEntryViewPrefab);
            return leaderboardEntryView;
        }
    }
}