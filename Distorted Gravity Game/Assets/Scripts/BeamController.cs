using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public GameObject[] casters;
    public GameObject[] consoles;

    public void Reset()
    {
        for (int i = 0; i < casters.Length; i++){
            casters[i].GetComponent<CasterScript>().Activate();
        }

        for (int i = 0; i < consoles.Length; i++){
            consoles[i].GetComponent<ConsoleScript>().ResetConsole();
        }
    }
}
