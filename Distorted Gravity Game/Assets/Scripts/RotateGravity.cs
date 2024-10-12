using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateGravity : MonoBehaviour
{
    public Vector2 gravityDirection = Vector2.down;
    public bool canShift = true;
    public float rotationTime = 0.05f;

    Rigidbody2D rb;

    Vector2[] gravityVectors = {Vector2.down, Vector2.left, Vector2.up, Vector2.right};
    public int idx = 0;
    
    public float gravScale;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gravScale = rb.gravityScale;
        rb.gravityScale = 0;
    }

    public void ResetGravity()
    {
        gravityDirection = Vector2.down;
        gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        idx = 0;
    }

    public IEnumerator StartRotation(float rotation)
    {
        canShift = false;
        for (int i = 0; i < Math.Abs(rotation); i += 10) {
            gameObject.transform.localEulerAngles += new Vector3(0, 0, 10 * (rotation < 0 ? -1 : 1));
            yield return new WaitForSeconds(rotationTime);
        }
        canShift = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canShift){
            if (Input.GetKeyDown(KeyCode.Q)) {
                StartCoroutine(StartRotation(90));
                idx += 1;
                if (idx > gravityVectors.Length - 1) idx = 0;
                gravityDirection = gravityVectors[idx];
            }

            if (Input.GetKeyDown(KeyCode.E)) {
                StartCoroutine(StartRotation(-90)); 
                idx -= 1;
                if(idx < 0) idx = gravityVectors.Length - 1;
                gravityDirection = gravityVectors[idx];
            }

            if (Input.GetKeyDown(KeyCode.W)) {
                StartCoroutine(StartRotation(180));
                if (gravityDirection == Vector2.down) {
                    gravityDirection = Vector2.up;
                    idx = 2;
                } else if (gravityDirection == Vector2.up) {
                    gravityDirection = Vector2.down;
                    idx = 0;
                } else if (gravityDirection == Vector2.right) {
                    gravityDirection = Vector2.left;
                    idx = 1;
                } else if (gravityDirection == Vector2.left) {
                    gravityDirection = Vector2.right;
                    idx = 3;
                }
            }
        }
    }
}
