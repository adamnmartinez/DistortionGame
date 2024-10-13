using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public TMP_Text TallyMesh;
    public TMP_Text TallyShadowMesh;
    public TMP_Text TimeMesh;
    public TMP_Text TimeShadowMesh;

    public TMP_Text victoryTime;
    public TMP_Text victoryAttempts;

    public GameObject pauseMenu;
    public GameObject instructionsMenu;
    public GameObject victoryScreen;

    public LevelInteraction level;

    public float timeTaken = 0.0f;

    public bool menuOpen;

    public void OpenMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnToMM()
    {
        Time.timeScale = 1;
        CloseVictoryScreen();
        StartCoroutine(LoadMM());
    }

    public IEnumerator LoadMM()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main_Menu");
        while (!asyncLoad.isDone) yield return null;
    }

    public void ShowInstructions()
    {
        instructionsMenu.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructionsMenu.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void OpenVictoryScreen()
    {
        Time.timeScale = 0;
        victoryAttempts.text = "ATTEMPTS: " + level.deathCount.ToString();
        victoryTime.text = "TIME: " + timeTaken.ToString("#.00");
        victoryScreen.SetActive(true);
    }

    public void CloseVictoryScreen()
    {
        Time.timeScale = 1;
        victoryScreen.SetActive(false);
    }

    public void ResetTimer()
    {
        timeTaken = 0.0f;
    }

    public void CloseAllMenus()
    {
        Time.timeScale = 1;
        CloseMenu();
        CloseInstructions();
        CloseVictoryScreen();
    }

    void Start()
    {
        CloseMenu();
        CloseInstructions();
        CloseVictoryScreen();
    }

    void Update()
    {
        TallyMesh.text = level.deathCount.ToString();
        TallyShadowMesh.text = level.deathCount.ToString();

        TimeMesh.text = timeTaken.ToString("#.00");
        TimeShadowMesh.text = timeTaken.ToString("#.00");

        timeTaken += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape) && !victoryScreen.activeInHierarchy)
        {
            if (menuOpen)
            {
                CloseMenu();
            } 
            else 
            {
                OpenMenu();
            }
        } 
    }
}
