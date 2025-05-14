using Game.Scripts.Services.Factories.ScreenFactory;
using Game.Scripts.Services.LevelService;
using Game.Scripts.Utils;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Scripts.UI
{
    public sealed class MainUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private Button _updateButton;

        private IScreenFactory _screenFactory;
        private ILevelService _levelService;

        private readonly CompositeDisposable _compositeDisposable = new ();

        [Inject]
        private void Construct(IScreenFactory screenFactory, ILevelService levelService)
        {
            _screenFactory = screenFactory;
            _levelService = levelService;
        }

        private void OnEnable()
        {
            _updateButton
                .OnClickAsObservable()
                .Subscribe(ShowPopup)
                .AddTo(_compositeDisposable);
            
            _levelService.Level
                .Subscribe(UpdateTextLevel)
                .AddTo(_compositeDisposable);
        }

        private void OnDisable()
        {
            _compositeDisposable.Clear();
            _compositeDisposable.Dispose();
        }

        private void ShowPopup(Unit _)
        {
            _screenFactory.CreateLevelPopupController(_levelService.GenerateLevel());
        }

        private void UpdateTextLevel(int level)
        {
            _levelText.text = string.Format(Format.Level, level.ToString());
        }
    }
}