using SimpleJSON;

namespace LeaderboardTask
{
    public struct LeaderboardEntryData
    {
        public string AvatarUrl;
        public string Name;
        public int Score;
        public string Type;

        public static LeaderboardEntryData Deserialize(JSONNode jsonNode)
        {
            return new LeaderboardEntryData()
            {
                Name = jsonNode[JsonKeys.Name],
                Score = jsonNode[JsonKeys.Score],
                AvatarUrl = jsonNode[JsonKeys.Avatar],
                Type = jsonNode[JsonKeys.Type]
            };
        }
    }
}