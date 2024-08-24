using UnityEngine;

namespace LeaderboardTask.View
{
    public class MainCanvas : MonoBehaviour
    {
        [field:SerializeField] public Canvas Canvas { get; private set; }
        [field:SerializeField] public Transform SafeZoneParent { get; private set; }

    }
}