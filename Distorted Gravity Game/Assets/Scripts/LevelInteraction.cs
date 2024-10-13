using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelInteraction : MonoBehaviour
{
    public int obstacleLayer;
    public RotateGravity rg;
    public BeamController beams;
    public UIController ui;
    public Vector3 spawnPoint;

    public int deathCount = 0;

    void Awake()
    {
        rg = GetComponent<RotateGravity>();
    }

    public void ResetGame()
    {
        gameObject.transform.localPosition = spawnPoint;
        rg.ResetGravity();
        ui.ResetTimer();
        ui.CloseAllMenus();
        beams.Reset();

    }

    public void TrueReset()
    {
        ResetGame();
        deathCount = 0;
    }

    public void PlayerDeath()
    {
        ResetGame();
        deathCount += 1;
    }

    public void Victory()
    {
        ui.OpenVictoryScreen();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == obstacleLayer) PlayerDeath();
    }
}
