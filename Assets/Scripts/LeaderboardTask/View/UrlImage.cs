using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace LeaderboardTask
{
    public class UrlImage : MonoBehaviour
    {
        [SerializeField] private Image _avatarImage;
        [SerializeField] private GameObject _loadingIndicator;
        
        [SerializeField] private string _url;
        [SerializeField] private float _rotationSpeed = 360;

        private bool _isBeingDestroyed = false;
        private Coroutine _loadAvatarRoutine;
        private Sprite _currentAvatarSprite = null;

        private string _currentLoadingSpriteUrl;

        private void Update()
        {
            if (string.IsNullOrEmpty(_currentLoadingSpriteUrl) || _currentLoadingSpriteUrl != _url)
            {
                TryDownloadSprite();
            }

            if (_loadingIndicator.activeInHierarchy)
            {
                _loadingIndicator.transform.Rotate(Vector3.back, _rotationSpeed * Time.deltaTime);
            }
        }

        private void TryDownloadSprite()
        {
            if (string.IsNullOrEmpty(_url) || _currentAvatarSprite != null || _loadAvatarRoutine != null)
            {
                return;
            }

            _currentLoadingSpriteUrl = _url;
            _loadAvatarRoutine = StartCoroutine(LoadAvatar(_url));
        }


        private IEnumerator LoadAvatar(string avatarUrl)
        {
            _loadingIndicator.SetActive(true);
            _avatarImage.gameObject.SetActive(false);
            
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(avatarUrl);

            yield return request.SendWebRequest();

             if (_isBeingDestroyed)
             {
                 yield break; 
             }

             bool isResponseFail = HandleResponse(request);

             _loadingIndicator.SetActive(isResponseFail);
             _avatarImage.gameObject.SetActive(!isResponseFail);

             _loadAvatarRoutine = null;
        }

        private Sprite GetLoadingAvatarSprite()
        {
            return null;
        }

        private bool HandleResponse(UnityWebRequest request)
        {
            bool isResponseFail =
                request.result == UnityWebRequest.Result.ConnectionError ||
                request.result == UnityWebRequest.Result.ProtocolError;

            if (isResponseFail)
            {
                Debug.LogError("Error downloading image: " + request.error);
            }
            else
            {
                Texture2D texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
                Sprite sprite = SpriteFromTexture2D(texture);
                _avatarImage.sprite = sprite;
            }

            return isResponseFail;
        }

        private Sprite SpriteFromTexture2D(Texture2D texture)
        {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }

        public void ChangeUrl(string url, bool download = true)
        {
            _url = url;
            if (download)
            {
                TryDownloadSprite();
            }
        }

        private void OnDestroy()
        {
            _isBeingDestroyed = true;
            if (_loadAvatarRoutine != null)
            {
                StopCoroutine(_loadAvatarRoutine);
                _loadAvatarRoutine = null;
            }
        }
    }
}