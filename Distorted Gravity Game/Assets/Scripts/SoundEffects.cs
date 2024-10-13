using System.Collections;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource source;
    public AudioClip walkClip, winClip;

    public float walkCooldown = 0.5f;
    public bool enableWalkSFX = true;

    public IEnumerator walkSFXCooldown()
    {
        enableWalkSFX = false;
        yield return new WaitForSeconds(walkCooldown);
        enableWalkSFX = true;
    }

    public void playWalkSFX()
    {
        if(enableWalkSFX){
            source.clip = walkClip;
            source.volume = 0.25f;
            source.pitch = Random.Range(0.9f, 1.1f);
            source.Play();
            StartCoroutine(walkSFXCooldown());
        }
    }

    public void playWinSFX()
    {
        source.volume = 0.66f;
        source.clip = winClip;
        source.Play();
    }
}
