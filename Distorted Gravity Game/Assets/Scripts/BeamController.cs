using UnityEngine;

public class BeamController : MonoBehaviour
{
    public GameObject[] casters;
    public GameObject[] consoles;

    public void Reset()
    {
        for (int i = 0; i < casters.Length; i++){
            CasterScript cstr = casters[i].GetComponent<CasterScript>();
            if(cstr.startDeactivated) cstr.Deactivate(); else cstr.Activate();
        }

        for (int i = 0; i < consoles.Length; i++){
            consoles[i].GetComponent<ConsoleScript>().ResetConsole();
        }
    }
}
