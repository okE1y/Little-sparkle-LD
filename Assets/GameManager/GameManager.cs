using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject Player;
    private Controlls controlls;
    [SerializeField] PauseController pauseController;
    [SerializeField] private CameraControll cameraControll;
    [SerializeField] private CutSceneController cutScene;
    [SerializeField] private Camera cameraCutScene;
    [SerializeField] private AudioListener MainaudioListener;
    [SerializeField] private AudioListener CutsceneaudioListener;
    [SerializeField] private Animator BlackScreen;

    private void Start()
    {
        BlackScreen.SetBool("Black", false);

        if (cutScene.CutsceneActive)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            controlls = Player.GetComponent<Controlls>();

            cameraCutScene.enabled = true;
            MainaudioListener.enabled = false;
            CutsceneaudioListener.enabled = true;


            pauseController.ActivePause = false;
            controlls.ControllsActive = false;
            cameraControll.CameraControlled = false;
            StartCoroutine(StopPlayer());
        }
    }

    private IEnumerator StopPlayer()
    {
        yield return null;
        Player.SetActive(false);
        yield break;
    }

    public void EndCutScene()
    {
        StartCoroutine(EndingCutScene());
    }

    private IEnumerator EndingCutScene()
    {
        BlackScreen.SetBool("Black", true);

        yield return new WaitForSeconds(BlackScreen.GetCurrentAnimatorStateInfo(0).length);

        cameraCutScene.enabled = false;
        MainaudioListener.enabled = true;
        CutsceneaudioListener.enabled = false;

        BlackScreen.SetBool("Black", false);

        yield return new WaitForSeconds(BlackScreen.GetCurrentAnimatorStateInfo(0).length);

        Player.SetActive(true);
        pauseController.ActivePause = true;
        controlls.ControllsActive = true;
        cameraControll.CameraControlled = true;
    }
}
