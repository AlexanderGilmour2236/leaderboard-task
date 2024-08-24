using UnityEngine;

namespace LeaderboardTask
{
    [CreateAssetMenu(fileName = "LeaderboardTaskConfigData", menuName = "Configs/LeaderboardTaskConfigData")]
    public class LeaderboardTaskConfigData : ScriptableObject
    {
        [field:SerializeField] public LeaderboardSpritesData LeaderboardSpritesData { get; private set; }

    }
}