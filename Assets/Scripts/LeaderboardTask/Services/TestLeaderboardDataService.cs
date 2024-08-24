namespace LeaderboardTask.Services
{
    public class TestLeaderboardDataService : ILeaderboardDataService
    {
        public LeaderboardEntryData[] GetLeaderboardDataEntries()
        {
            string avatarUrl = "https://secure.gravatar.com/avatar/89f62265519c76c020aa0611b1423e29?s=80&d=identicon";
            
            return new LeaderboardEntryData[]
            {
                new ()
                {
                    Name = "Carl Johnson",
                    AvatarUrl = avatarUrl,
                    Score = 100,
                    Type = "Gold"
                },
                new ()
                {
                    Name = "Sweet",
                    AvatarUrl = avatarUrl,
                    Score = 50,
                    Type = "Silver"
                },
                new ()
                {
                    Name = "Smoke",
                    AvatarUrl = avatarUrl,
                    Score = 25,
                    Type = "Bronze"
                },
                new ()
                {
                    Name = "Ryder",
                    AvatarUrl = avatarUrl,
                    Score = 5,
                    Type = "Default"
                },
            };
        }
    }
}