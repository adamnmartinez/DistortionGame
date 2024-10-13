using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpSpeed = 4f;
    public float jumpTime = 0.5f;
    public bool canMove = true;
    public float groundDistance = 0.03f;

    ContactFilter2D castFilter;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    Animator animator;
    Rigidbody2D rb;
    RotateGravity rg;
    SoundEffects sound;
    BoxCollider2D bc;

    private bool _isAirborne = false;
    public bool isAirborne {
        set {
            animator.SetBool("isAirborne", value);
            if(_isAirborne != value && value == false) sound.playWalkSFX();
            _isAirborne = value;
        }

        get {
            return _isAirborne;
        }
    }

    private bool _isMoving = false;
    public bool isMoving {
        set {
            animator.SetBool("isMoving", value);
            _isMoving = value;
        }

        get {
            return _isMoving;
        }
    }

    private bool _facingLeft = false;
    public bool facingLeft {
        set {
            if (value != _facingLeft) gameObject.transform.localScale *= new Vector2(-1, 1);
            _facingLeft = value;
        }
        
        get {
            return _facingLeft;
        }
    }

    void Awake()
    {
        rg = GetComponent<RotateGravity>();
        rb = GetComponent<Rigidbody2D>();    
        bc = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sound = GetComponent<SoundEffects>();
    }

    void Update()
    {
        float moveInputX = Input.GetAxisRaw("Horizontal");
        isMoving = moveInputX != 0;

        if(rg.gravityDirection.y > 0 || rg.gravityDirection.x > 0) moveInputX *= -1;

        if (canMove){
            if (rg.gravityDirection.x == 0){
                rb.velocity = new Vector2(
                    moveSpeed * moveInputX, 
                    rg.gravityDirection.y * rg.gravScale
                );
            } else if (rg.gravityDirection.y == 0){
                rb.velocity = new Vector2 (
                    -rg.gravityDirection.x * rg.gravScale, 
                    moveSpeed * moveInputX  
                );
            }

            // Set Facing Direction.
            if (isMoving) {
                if (rg.gravityDirection.y > 0 || rg.gravityDirection.x > 0) facingLeft = moveInputX > 0;
                else facingLeft = moveInputX < 0;
            }          
        }

        if(rg.gravityDirection.y == 0)
        {
            isAirborne = bc.Cast(rg.gravityDirection * new Vector2(-1, 0), castFilter, groundHits, groundDistance, true) == 0;
        } 
        else 
        {
            isAirborne = bc.Cast(rg.gravityDirection, castFilter, groundHits, groundDistance, true) == 0;
        }

        if (isMoving && !isAirborne) sound.playWalkSFX();
        
    }
}
