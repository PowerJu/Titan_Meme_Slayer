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
    [SerializeField] private RectTransform _wireNode;

    private CancellationTokenSource _cancelToken;

    private void Awake()
    {
        _cancelToken?.Dispose();
        _cancelToken = new CancellationTokenSource();
        EventBus.Subscribe<GameStartEvent>(StartGame);
    }

    private void StartGame(GameStartEvent gameStartEvent)
    {
        ShowWireNode().Forget();
    }

    private async UniTask ShowWireNode()
    {
        await UniTask.Delay(300, cancellationToken: _cancelToken.Token);

        var size = 200.0f;
        var targetSize = 100.0f;

        while (true)
        {
            _wireNode.sizeDelta = new Vector2(size, size);
            await _wireNode.DOSizeDelta(new Vector2(targetSize, targetSize), 0.5f).ToUniTask();
            await _wireNode.DOSizeDelta(Vector2.zero, 0.5f).ToUniTask();

            await UniTask.Delay(Random.Range(500, 1000), cancellationToken: _cancelToken.Token);
        }
    }
}
