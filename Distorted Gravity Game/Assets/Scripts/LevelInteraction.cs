using UnityEngine;

public class LevelInteraction : MonoBehaviour
{
    public int obstacleLayer;
    SoundEffects sound;
    RotateGravity rg;
    public BeamController beams;
    public UIController ui;
    public Vector3 spawnPoint;

    public int deathCount = 0;

    void Awake()
    {
        rg = GetComponent<RotateGravity>();
        sound = GetComponent<SoundEffects>();
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
        sound.playWinSFX();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == obstacleLayer) PlayerDeath();
    }
}
