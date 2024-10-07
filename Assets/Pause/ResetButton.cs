using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    private RoomManager roomManager;
    [SerializeField] private PauseController pauseController;

    private void Start()
    {
        roomManager = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomManager>();
    }

    public void ResetLevel()
    {
        roomManager.ResetCurrentLevel();
        pauseController.ResumePause();
    }
}
