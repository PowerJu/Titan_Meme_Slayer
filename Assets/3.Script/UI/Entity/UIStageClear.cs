using TMS.Core;
using TMS.Event;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UserInterface;

public class UIStageClear : UIBase
{
    [SerializeField] private GameObject _nextStageButton;
    [SerializeField] private Transform arrow;
    
    
    public float speed = 130f;
    private float angle = 0f;
    private bool goingUp = true;

    private void Awake()
    {
        // Bind the button click event to the method that handles stage clear logic
        BindEvent(_nextStageButton, OnNextStageButtonClicked);
    }

    private void OnNextStageButtonClicked(PointerEventData _)
    {
        GameManager.Instance.RestartGame();
    }
    
    void Update()
    {
        if (goingUp)
        {
            angle += speed * Time.deltaTime;
            if (angle >= 180f)
            {
                angle = 180f;
                goingUp = false;
            }
        }
        else
        {
            angle -= speed * Time.deltaTime;
            if (angle <= 0f)
            {
                angle = 0f;
                goingUp = true;
            }
        }

        arrow.rotation = Quaternion.Euler(0f, 0, angle);
    }
}
