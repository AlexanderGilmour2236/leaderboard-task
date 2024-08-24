using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeaderboardTask.View
{
    public class LeaderboardEntryView : MonoBehaviour
    {
        [SerializeField] private UrlImage _urlImage;
        [SerializeField] private Image _frameImage;
        [SerializeField] private Image _backgroundImage;

        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _scoreText;

        private ILeaderboardEntryPresenter _leaderboardEntryPresenter;
        
        public void Initialize(ILeaderboardEntryPresenter leaderboardEntryPresenter)
        {
            _leaderboardEntryPresenter = leaderboardEntryPresenter;
            _nameText.text = _leaderboardEntryPresenter.PlayerName;
            _scoreText.text = _leaderboardEntryPresenter.PlayerScoreText;
            
            _frameImage.sprite = _leaderboardEntryPresenter.GetFrameSprite();
            _backgroundImage.sprite = _leaderboardEntryPresenter.GetBackgroundSprite();

            Color textColor = _leaderboardEntryPresenter.GetTextColor();
            _nameText.color = textColor;
            _scoreText.color = textColor;
            
            _urlImage.ChangeUrl(leaderboardEntryPresenter.PlayerAvatarUrl, false);
        }
    }
}