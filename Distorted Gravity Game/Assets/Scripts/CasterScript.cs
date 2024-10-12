using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.MPE;
using UnityEngine;

public class CasterScript : MonoBehaviour
{
    public GameObject laserPrefab;
    public GameObject laserObjectRef;
    public float beamLength = 2f;

    public void Activate()
    {
        if(laserObjectRef) Deactivate();
        laserPrefab.transform.localPosition = new Vector3(0, (beamLength * 0.5f) + 1f, 0);
        laserPrefab.transform.localScale = new Vector2(1, beamLength);
        laserObjectRef = Instantiate(laserPrefab, gameObject.transform);
    }

    public void Deactivate()
    {
        Destroy(laserObjectRef);
    }

    void Start()
    {
        Activate();
    }
}
