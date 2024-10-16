using UnityEngine;

public class EscapeConsole : MonoBehaviour
{
    public Animator animator;
    LevelInteraction level;
    public GameObject Player;

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

    void Awake()
    {
        animator = GetComponent<Animator>();
        level = Player.GetComponent<LevelInteraction>();
    }

    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.localPosition, Player.transform.localPosition);
        if (distance <= 3f){
            Interactable = true;
            if(Input.GetKeyDown(KeyCode.F)){
                level.Victory();
            }
        } else {
            Interactable = false;
        }
    }
}
