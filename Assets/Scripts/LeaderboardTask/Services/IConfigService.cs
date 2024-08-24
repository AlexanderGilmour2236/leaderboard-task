namespace LeaderboardTask.Services
{
    public interface IConfigService
    {
        void InitializeConfigs();
        LeaderboardSpritesData GetLeaderboardSpritesData();
    }
}