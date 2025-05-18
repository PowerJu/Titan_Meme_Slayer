using UnityEngine;
using UserInterface;
using Cysharp.Threading.Tasks;
using System.Threading;
using TMPro;
using DG.Tweening;
using TMS.Event;

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

        _scoreText.text = $"Score: {0}";
    }

    private void StartGame(GameStartEvent gameStartEvent)
    {
    }

    private void ClearGame(GameClearEvent gameStartEvent)
    {
    }

    private void OnAcquireCoin(UpdateScoreEvent acquireCoinEvent)
    {
        _scoreText.text = $"Score: {acquireCoinEvent.Score}";
        _scoreText.transform.DOPunchScale(Vector3.one * 0.2f, 0.5f).SetEase(Ease.OutBack);
    }


}
