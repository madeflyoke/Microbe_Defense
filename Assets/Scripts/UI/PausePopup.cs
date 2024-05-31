using Managers;
using Services;
using Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class PausePopup : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ServicesHolder _servicesHolder;
        
        [SerializeField] private Button _backToSelectorButton;
        [SerializeField] private Button _closeButton;
        
        public void Show()
        {
            _backToSelectorButton.onClick.AddListener(BackToSelector);
            _closeButton.onClick.AddListener(Hide);
            _servicesHolder.GetService<PauseService>().SetPause(true);
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
            _servicesHolder.GetService<PauseService>().SetPause(false);
            _backToSelectorButton.onClick.RemoveListener(BackToSelector);
            _closeButton.onClick.RemoveListener(Hide);
        }
        
        private void BackToSelector()
        {
            _signalBus.Fire<LevelSelectorCallSignal>();
            Hide();
        }
    }
}