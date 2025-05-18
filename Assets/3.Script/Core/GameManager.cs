using TMP.UI;
using TMS.Event;
using UserInterface;

namespace TMS.Core
{
    public class GameManager : Singleton<GameManager>
    {
        private void Start()
        {
            UIManager.Instance.OpenUI<UILobby>();
        }

        public void StartGame()
        {
            EventBus.Publish(new GameStartEvent());
        }

    }
}
