using UnityEngine;

namespace LeaderboardTask.View
{
    public interface ILeaderboardEntryPresenter
    {
        string PlayerName { get; }
        string PlayerScoreText { get; }
        string PlayerAvatarUrl { get; }
        string Type { get; }
        Sprite GetFrameSprite();
        Sprite GetBackgroundSprite();
        Color GetTextColor();
    }
}