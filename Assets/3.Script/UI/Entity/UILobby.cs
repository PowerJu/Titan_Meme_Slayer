using TMS.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UserInterface;

namespace TMP.UI
{
    public class UILobby : UIBase
    {
        [SerializeField] private GameObject _playButton;
        [SerializeField] private GameObject _exitButton;

        private void Awake()
        {
            BindEvent(_playButton, StartGame);
            BindEvent(_exitButton, ExitGame);
        }

        private void StartGame(PointerEventData _)
        {
            GameManager.Instance.StartGame();
        }

        private void ExitGame(PointerEventData _)
        {
        }
    }
}