using System.Collections.Generic;
using LeaderboardTask.Services;
using SimplePopupManager;
using Zenject;

namespace LeaderboardTask
{
    public class LeaderboardSceneController
    {
        private ILeaderboardPresenter _leaderboardPresenter;

        private IPopupManagerService _popUpManager;
        private ILeaderboardDataService _leaderboardDataService;
        
        private UiFactory _uiFactory;
        private LeaderboardSceneAccessor _leaderboardSceneAccessor;

        private Dictionary<string, object> _popUpNameToParameter;
        private string _currentPopUpName;

        [Inject]
        public void Constructor(IPopupManagerService popUpManager, ILeaderboardDataService leaderboardDataService, 
            UiFactory uiFactory, LeaderboardSceneAccessor leaderboardSceneAccessor, IConfigService configService)
        {
            _popUpManager = popUpManager;
            _leaderboardDataService = leaderboardDataService;
            _uiFactory = uiFactory;
            _leaderboardSceneAccessor = leaderboardSceneAccessor;
            
            _leaderboardPresenter = new LeaderboardPresenter(this, _leaderboardDataService, _uiFactory, configService);

            _leaderboardPresenter.PopUpChange += ChangePopUp;

            _popUpNameToParameter = new Dictionary<string, object>
            {
                {PopUpNames.LeaderboardPopUp, _leaderboardPresenter},
                {PopUpNames.MainMenuPopUp, _leaderboardPresenter}
            };
        }

        public void Start()
        {
            ChangePopUp(PopUpNames.MainMenuPopUp);
        }

        private void ChangePopUp(string popUpName)
        {
            bool changeCurrentPopUp = !string.IsNullOrEmpty(_currentPopUpName) && _currentPopUpName != popUpName;
            if (changeCurrentPopUp) 
            {
                _popUpManager.ClosePopup(_currentPopUpName);
            }

            if (_currentPopUpName != popUpName)
            {
                _currentPopUpName = popUpName;
                _popUpManager.OpenPopup(popUpName, _popUpNameToParameter[popUpName], _leaderboardSceneAccessor.UiSafeAreaParent.transform);   
            }
        }


        public void OpenLeaderboard()
        {
            ChangePopUp(PopUpNames.LeaderboardPopUp);
        }

        public void CloseLeaderboard()
        {
            ChangePopUp(PopUpNames.MainMenuPopUp);
        }

        public ILeaderboardPresenter LeaderboardPresenter
        {
            get { return _leaderboardPresenter; }
        }
    }
}