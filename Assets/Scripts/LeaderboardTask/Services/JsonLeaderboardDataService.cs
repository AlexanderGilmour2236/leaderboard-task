using SimpleJSON;
using UnityEngine;

namespace LeaderboardTask.Services
{
    public class JsonLeaderboardDataService : ILeaderboardDataService
    {
        public LeaderboardEntryData[] GetLeaderboardDataEntries()
        {
            TextAsset jsonText = Resources.Load<TextAsset>(LeaderboardResourcePath.LeaderboardDataJson);
            JSONObject jsonObject = JSONNode.Parse(jsonText.text).AsObject;
            JSONArray jsonArray = jsonObject[JsonKeys.Leaderboard].AsArray;
            
            LeaderboardEntryData[] leaderboardDataEntries = new LeaderboardEntryData[jsonArray.Count];

            int index = 0;
            foreach (JSONNode jsonNode in jsonArray.Children)
            {
                LeaderboardEntryData leaderboardEntryData = LeaderboardEntryData.Deserialize(jsonNode);
                leaderboardDataEntries[index++] = leaderboardEntryData; 
            }

            return leaderboardDataEntries;
        }
    }
}