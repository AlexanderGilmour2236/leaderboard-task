using LeaderboardTask.Services;
using SimplePopupManager;
using UnityEngine;
using Zenject;

namespace LeaderboardTask
{
    public class LeaderboardTaskInstaller : MonoInstaller
    {
        [SerializeField] private LeaderboardSceneAccessor _leaderboardSceneAccessor;

        public override void InstallBindings() 
        { 
            Container.BindInterfacesAndSelfTo<ConfigService>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<PopupManagerService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<JsonLeaderboardDataService>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<UiFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LeaderboardSceneAccessor>().FromInstance(_leaderboardSceneAccessor).AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<LeaderboardSceneController>().AsSingle().NonLazy();
        }
    }  
}
