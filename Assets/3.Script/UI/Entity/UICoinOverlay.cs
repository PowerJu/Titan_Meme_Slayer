using DG.Tweening;
using TMPro;
using TMS.Event;
using UnityEngine;
using UserInterface;

public class UICoinOverlay : UIBase
{
    [SerializeField] private TMP_Text _scoreText;
    void Start()
    {
        EventBus.Subscribe<UpdateGameScoreEvent>(OnAcquireGameScore);
    }
    
    private void OnAcquireGameScore(UpdateGameScoreEvent acquireCoinEvent)
    {
        _scoreText.text = $"Score: {acquireCoinEvent.GameScore}";
    }
}
