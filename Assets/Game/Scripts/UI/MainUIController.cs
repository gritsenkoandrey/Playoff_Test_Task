﻿using Runtime.Models;
using Runtime.Services.Factories.ScreenFactory;
using Runtime.Services.LevelService;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Runtime.UI
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
                .Subscribe(CreatePopup)
                .AddTo(_compositeDisposable);

            _levelService.LevelModel
                .Subscribe(UpdateView)
                .AddTo(_compositeDisposable);
        }

        private void OnDisable()
        {
            _compositeDisposable.Clear();
        }

        private void CreatePopup(Unit _)
        {
            _levelService.GenerateLevel();
            _screenFactory.CreateLevelPopupController();
        }

        private void UpdateView(LevelModel levelModel)
        {
            _levelText.text = levelModel.ToString();
        }
    }
}