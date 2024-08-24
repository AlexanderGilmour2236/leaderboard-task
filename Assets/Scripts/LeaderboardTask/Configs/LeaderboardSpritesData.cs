using UnityEngine;

namespace LeaderboardTask
{
    [CreateAssetMenu(fileName = "LeaderboardSpritesData", menuName = "Configs/UI/LeaderboardSpritesData")]
    public class LeaderboardSpritesData : ScriptableObject
    {
        [field:SerializeField] public Sprite[] WinnersPlayerEntrySprites { get; private set; }
        [field:SerializeField] public Sprite[] WinnersPlayerFrameSprites { get; private set; }
        [field:SerializeField] public Color[] WinnersPlayerTextColors { get; private set; }

    }
}