using UnityEngine;

namespace LeaderboardTask.Services
{
    public class ConfigService : IConfigService
    {
        private LeaderboardSpritesData _leaderboardSpritesData;
        private LeaderboardTaskConfigData _leaderboardTaskConfigData;

        public void InitializeConfigs()
        {
            _leaderboardTaskConfigData = Resources.Load<LeaderboardTaskConfigData>(LeaderboardResourcePath.LeaderboardConfigData);
            _leaderboardSpritesData = _leaderboardTaskConfigData.LeaderboardSpritesData;
        }

        public LeaderboardSpritesData GetLeaderboardSpritesData()
        {
            return _leaderboardSpritesData;
        }
    }
}