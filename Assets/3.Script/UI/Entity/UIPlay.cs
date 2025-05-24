using UnityEngine;
using UserInterface;
using Cysharp.Threading.Tasks;
using System.Threading;
using TMPro;
using DG.Tweening;
using TMS.Event;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIPlay : UIBase
{
    [SerializeField] private GameObject _playButton;
    [SerializeField] private TMP_Text _scoreText;

    private CancellationTokenSource _cancelToken;

    private void Awake()
    {
        _cancelToken?.Dispose();
        _cancelToken = new CancellationTokenSource();
        EventBus.Subscribe<GameStartEvent>(StartGame);
        EventBus.Subscribe<GameClearEvent>(ClearGame);
        EventBus.Subscribe<UpdateScoreEvent>(OnAcquireCoin);

        BindEvent(_playButton, OnPlayButton);
    }

    private void OnDestroy()
    {
        _cancelToken?.Cancel();
        _cancelToken?.Dispose();
        EventBus.Unsubscribe<GameStartEvent>(StartGame);
        EventBus.Unsubscribe<GameClearEvent>(ClearGame);
        EventBus.Unsubscribe<UpdateScoreEvent>(OnAcquireCoin);
    }

    public override void Open()
    {
        base.Open();
        _playButton.SetActive(true);
    }

    private void StartGame(GameStartEvent gameStartEvent)
    {
        _playButton.SetActive(true);
    }

    private void ClearGame(GameClearEvent gameStartEvent)
    {
    }

    private void OnAcquireCoin(UpdateScoreEvent acquireCoinEvent)
    {
        // _scoreText.text = $"Score: {acquireCoinEvent.Score}";
        // _scoreText.transform.DOPunchScale(Vector3.one * 0.2f, 0.5f).SetEase(Ease.OutBack);
    }
    
    private void OnPlayButton(PointerEventData _)
    {
        _playButton.SetActive(false);
        EventBus.Publish(new PlayStartEvent());
    }
}
