using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    private bool pauseEnabled = false;
    private Canvas PauseCanvas;
    private MenuMenager menuMenager;
    private Controlls controlls;

    public bool ActivePause = true;

    private void Start()
    {
        PauseCanvas = GetComponent<Canvas>();
        menuMenager = GetComponent<MenuMenager>();
        controlls = GameObject.FindGameObjectWithTag("Player").GetComponent<Controlls>();
    }

    public void ResumePause()
    {
        if (pauseEnabled)
        {
            pauseEnabled = false;
            Time.timeScale = 1f;


            controlls.ControllsActive = true;
            menuMenager.ActiveMenu = false;
            PauseCanvas.enabled = false;
        }
    }

    public void OpenOrClosePause(InputAction.CallbackContext context)
    {
        if (ActivePause && context.started)
        {
            if (!pauseEnabled)
            {
                pauseEnabled = true;
                Time.timeScale = 0f;

                controlls.ControllsActive = false;
                menuMenager.ActiveMenu = true;
                PauseCanvas.enabled = true;
            }
            else
            {
                ResumePause();
            }
        }
    }
}
