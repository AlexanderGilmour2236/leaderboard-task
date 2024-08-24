using System.Linq;
using LeaderboardTask.Services;
using UnityEngine;

namespace LeaderboardTask.View
{
    public class LeaderboardEntryPresenter : ILeaderboardEntryPresenter
    {
        private readonly IConfigService _configService;
        private readonly LeaderboardEntryData _leaderboardEntryData;
        private readonly LeaderboardPresenter _leaderboardPresenter;

        public LeaderboardEntryPresenter(LeaderboardEntryData leaderboardEntryData,
            LeaderboardPresenter leaderboardPresenter, IConfigService configService)
        {
            _leaderboardEntryData = leaderboardEntryData;
            _leaderboardPresenter = leaderboardPresenter;
            _configService = configService;
        }

        public Sprite GetFrameSprite()
        {
            return GetStyleDataForPlayer(_configService.GetLeaderboardSpritesData().WinnersPlayerFrameSprites);
        }

        public Sprite GetBackgroundSprite()
        {
            return GetStyleDataForPlayer(_configService.GetLeaderboardSpritesData().WinnersPlayerEntrySprites);
        }

        public Color GetTextColor()
        {
            return GetStyleDataForPlayer(_configService.GetLeaderboardSpritesData().WinnersPlayerTextColors);
        }

        private T GetStyleDataForPlayer<T>(T[] sortedStylesCollection)
        {
            int playerPlaceInLeaderboard = _leaderboardPresenter.GetPlayerPlaceInLeaderboard(_leaderboardEntryData);

            if (playerPlaceInLeaderboard < sortedStylesCollection.Length)
            {
                return sortedStylesCollection[playerPlaceInLeaderboard];
            }
            else
            {
                return sortedStylesCollection.Last();
            }
        }

        public string PlayerName => _leaderboardEntryData.Name;
        public string PlayerScoreText => _leaderboardEntryData.Score.ToString();
        public string PlayerAvatarUrl => _leaderboardEntryData.AvatarUrl;
        public string Type => _leaderboardEntryData.Type;
    }
}