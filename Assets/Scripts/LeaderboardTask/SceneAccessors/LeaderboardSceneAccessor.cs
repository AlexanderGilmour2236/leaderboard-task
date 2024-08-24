using UnityEngine;

namespace LeaderboardTask
{
    public class LeaderboardSceneAccessor : MonoBehaviour
    {
        [field:SerializeField] public Transform UiSafeAreaParent { get; private set; }
    }
}