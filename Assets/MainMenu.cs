using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string nameEssentialScene;
    [SerializeField] string newGameStartScene;

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(nameEssentialScene, LoadSceneMode.Single);
        SceneManager.LoadScene(newGameStartScene, LoadSceneMode.Additive);
    }
}
