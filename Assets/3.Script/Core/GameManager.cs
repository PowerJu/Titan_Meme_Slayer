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

        private void Start()
        {
            UIManager.Instance.OpenUI<UILobby>();
            EventBus.Subscribe<AcquireCoinEvent>(OnAcquireCoin);
        }

        public void StartGame()
        {
            _coinScore = 0;
            EventBus.Publish(new GameStartEvent());
        }

        public void ClearGame()
        {
            UIManager.Instance.CloseUI<UIPlay>();
            UIManager.Instance.OpenUI<UIStageClear>();
            
            EventBus.Publish(new GameClearEvent());
        }

        private void OnAcquireCoin(AcquireCoinEvent acquireCoinEvent)
        {
            _coinScore += acquireCoinEvent.CoinScore;
            EventBus.Publish(new UpdateScoreEvent(_coinScore));
        }

    }
}
