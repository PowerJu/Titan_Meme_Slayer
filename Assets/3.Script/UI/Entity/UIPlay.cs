using System;
using UnityEngine;
using UserInterface;

public class UIPlay : UIBase
{
    [SerializeField] private GameObject _playButton; 
    
    private void Awake()
    {
        BindEvent(_playButton, (_) => { StartGame(); });
    }

    private void StartGame()
    {
        // 게임 시작
    }
}
