using System;
using TMP.UI;
using TMS.Event;
using Unity.VisualScripting;
using UserInterface;

namespace TMS.Core
{
    public class GameManager : Singleton<GameManager>
    {
        private int _coinScore = 0;
        private int _gameScore = 0;
        
        private void Start()
        {
            UIManager.Instance.OpenUI<UILobby>();
            EventBus.Subscribe<AcquireCoinEvent>(OnAcquireCoin);
            EventBus.Subscribe<AcquireGameScoreEvent>(OnAcquireGameScore);
        }

        public void StartGame()
        {
            _coinScore = 0;
            _gameScore = 0;
            
            EventBus.Publish(new GameStartEvent());
            
            UIManager.Instance.OpenUI<UICoinOverlay>();
        }

        public void ClearGame()
        {
            UIManager.Instance.CloseUI<UIPlay>();
            UIManager.Instance.CloseUI<UICoinOverlay>();
            UIManager.Instance.OpenUI<UIStageClear>();
            
            EventBus.Publish(new GameClearEvent());
        }

        private void OnAcquireCoin(AcquireCoinEvent acquireCoinEvent)
        {
            _coinScore += acquireCoinEvent.CoinScore;
            EventBus.Publish(new UpdateScoreEvent(_coinScore));
        }

        private void OnAcquireGameScore(AcquireGameScoreEvent acquireGameScoreEvent)
        {
            _gameScore += acquireGameScoreEvent.GameScore;
            EventBus.Publish(new UpdateGameScoreEvent(_gameScore));
        }

    }
}
