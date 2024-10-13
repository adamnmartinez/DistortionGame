using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject tutorialWindow;
    public GameObject levelSelectWindow;

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void OpenTutorial()
    {
        tutorialWindow.SetActive(true);
    }
    
    public void CloseTutorial()
    {
        tutorialWindow.SetActive(false);
    }

    public void OpenLevelSelect()
    {
        levelSelectWindow.SetActive(true);
    }

    public void CloseLevelSelect()
    {
        levelSelectWindow.SetActive(false);
    }

    public void StartLevel(string levelName)
    {
        StartCoroutine(LoadScene(levelName));
    }

    public IEnumerator LoadScene(string levelName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);
        while (!asyncLoad.isDone) yield return null;
    }

    void Start()
    {
        CloseTutorial();
        CloseLevelSelect();
    }
}
