using UnityEngine;

public class CasterScript : MonoBehaviour
{
    public GameObject laserPrefab;
    public GameObject[] casterTiles;
    public GameObject laserObjectRef;
    public float beamLength = 2f;
    public bool startDeactivated = false;

    public void Activate()
    {
        if(laserObjectRef) Deactivate();
        SetTileActivity(true);
        laserPrefab.transform.localPosition = new Vector3(0, (beamLength * 0.5f) + 1f, 0);
        laserPrefab.transform.localScale = new Vector2(1, beamLength);
        laserObjectRef = Instantiate(laserPrefab, gameObject.transform);
    }

    public void Deactivate()
    {
        SetTileActivity(false);
        Destroy(laserObjectRef);
    }

    public void SetTileActivity(bool active)
    {
        for(int i = 0; i < casterTiles.Length; i++)
        {
            casterTiles[i].GetComponent<Animator>().SetBool("Deactivated", !active);
        }
    }

    void Start()
    {
        if(startDeactivated) Deactivate(); else Activate();
    }
}
