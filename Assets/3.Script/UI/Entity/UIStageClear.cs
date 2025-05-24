using TMS.Core;
using TMS.Event;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UserInterface;

public class UIStageClear : UIBase
{
    [SerializeField] private GameObject _nextStageButton;

    private void Awake()
    {
        // Bind the button click event to the method that handles stage clear logic
        BindEvent(_nextStageButton, OnNextStageButtonClicked);
    }

    private void OnNextStageButtonClicked(PointerEventData _)
    {
        GameManager.Instance.RestartGame();
    }
}
