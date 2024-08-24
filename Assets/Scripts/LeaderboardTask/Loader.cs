using LeaderboardTask.Services;
using UnityEngine;
using Zenject;

namespace LeaderboardTask
{
    public class Loader : MonoBehaviour
    {
        private LeaderboardSceneController _leaderboardSceneController;
        private IConfigService _configService;

        [Inject]
        public void Constructor(LeaderboardSceneController leaderboardSceneController, IConfigService configService)
        {
            _leaderboardSceneController = leaderboardSceneController;
            _configService = configService;
        }
        
        void Start()
        {
            _configService.InitializeConfigs();
            _leaderboardSceneController.Start();
        }
    }
}