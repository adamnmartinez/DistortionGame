using UnityEngine;

public class ConsoleScript : MonoBehaviour
{
    public CasterScript[] LinkedCasters;
    public GameObject Player;
    Animator animator;
    AudioSource asrc;

    public bool _active = false;
    public bool Active {
        set {
            animator.SetBool("Active", value);
            _active = value;
        }

        get {
            return _active;
        }
    }

    public bool _interactable = false;
    public bool Interactable {
        set {
            animator.SetBool("Interactable", value);
            _interactable = value;
        }

        get {
            return _interactable;
        }
    }

    public void ResetConsole()
    {
        Active = false;
        Interactable = false;
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        asrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.localPosition, Player.transform.localPosition);
        if (distance <= 3f){
            Interactable = true;
            if(Input.GetKeyDown(KeyCode.F)){
                asrc.Play();
                for(int i = 0; i < LinkedCasters.Length; i++) {
                    if(LinkedCasters[i].startDeactivated) LinkedCasters[i].Activate(); else LinkedCasters[i].Deactivate();
                }
                Active = true;
            }
        } else {
            Interactable = false;
        }
    }
}
