using Runtime.Models;
using Runtime.Services.Factories.ScreenFactory;
using Runtime.Services.LevelService;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Runtime.UI
{
    public sealed class LevelPopupController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private RectTransform _rewardContainer;
        [SerializeField] private Button _closeButton;

        private IScreenFactory _screenFactory;
        private ILevelService _levelService;
        
        [Inject]
        private void Construct(IScreenFactory screenFactory, ILevelService levelService)
        {
            _screenFactory = screenFactory;
            _levelService = levelService;
        }

        private void OnEnable()
        {
            _closeButton
                .OnClickAsObservable()
                .First()
                .Subscribe(Close)
                .AddTo(this);

            _levelService.LevelModel
                .Subscribe(UpdateView)
                .AddTo(this);
        }

        private void UpdateView(LevelModel levelModel)
        {
            _levelText.text = levelModel.ToString();

            for (int i = 0; i < levelModel.Rewards.Count; i++)
            {
                _screenFactory.CreateRewardItemView(levelModel.Rewards[i], _rewardContainer);
            }
        }

        private void Close(Unit _)
        {
            _levelService.UpdateLevel();
            
            Destroy(gameObject);
        }
    }
}