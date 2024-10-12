using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpSpeed = 4f;
    public float jumpTime = 0.5f;
    public bool canMove = true;
    public bool isJumping = false;
    public bool isAirborne = false;
    public RotateGravity rg;

    Rigidbody2D rb;

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

    // Start is called before the first frame update
    void Awake()
    {
        rg = GetComponent<RotateGravity>();
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        float moveInputX = Input.GetAxisRaw("Horizontal");

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
            if (moveInputX != 0) {
                if (rg.gravityDirection.y > 0 || rg.gravityDirection.x > 0) facingLeft = moveInputX > 0;
                else facingLeft = moveInputX < 0;
            }          
        }
        
    }
}
