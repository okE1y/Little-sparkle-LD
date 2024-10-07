using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] private PauseController pauseController;

    public void Resume()
    {
        pauseController.ResumePause();
    }
}
