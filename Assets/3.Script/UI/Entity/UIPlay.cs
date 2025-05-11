using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UserInterface;

public class UIPlay : UIBase
{
    [SerializeField] private GameObject _playButton; 
    
    private void Awake()
    {
        BindEvent(_playButton, StartGame);
    }

    private void StartGame(PointerEventData _)
    {
        // 게임 시작
    }
}
