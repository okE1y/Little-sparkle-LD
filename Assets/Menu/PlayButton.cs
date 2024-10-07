using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private Canvas loadScreen;

    [SerializeField] private MenuMenager menuMenager;

    public void Action()
    {
        SceneManager.LoadSceneAsync("Game");

        menuMenager.ActiveMenu = false;

        loadScreen.enabled = true;
    }
}
