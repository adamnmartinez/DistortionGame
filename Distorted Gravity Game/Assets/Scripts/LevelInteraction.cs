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
    public Vector3 spawnPoint = new Vector3(-25, 3 ,0);

    public int deathCount = 0;

    void Awake()
    {
        rg = GetComponent<RotateGravity>();
    }

    public void ResetGame()
    {
        gameObject.transform.localPosition = spawnPoint;
        rg.ResetGravity();
        beams.Reset();
    }

    public void PlayerDeath()
    {
        ResetGame();
        deathCount += 1;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == obstacleLayer) ResetGame();
    }
}
