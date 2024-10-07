using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneController : MonoBehaviour
{
    [SerializeField] public bool CutsceneActive = true;

    public Animator BaseAnimator;

    [SerializeField] GameManager gameManager;

    private void Start()
    {
        if (CutsceneActive)
        {
            StartCoroutine(CutSceneTimer());
        }
    }

    private IEnumerator CutSceneTimer()
    {
        yield return new WaitForSeconds(BaseAnimator.GetCurrentAnimatorStateInfo(0).length);

        Debug.Log("CutsceneEnded");
        gameManager.EndCutScene();

        yield break;
    }
}
