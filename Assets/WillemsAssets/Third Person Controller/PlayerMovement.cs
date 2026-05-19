using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public Animator anim;

    public float rotSpeed = 10;
    public float jumpForce = 5f;
    private bool isGrounded = true;
    private Rigidbody rb;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        ForwardMovement();
        Turning();
        Actions();
        Jump();
    }

    private void ForwardMovement(){
        if(Input.GetKey("w")){
            anim.SetBool("Walking", true);
            if (Input.GetKey(KeyCode.LeftShift)){
                anim.SetBool("Running", true);
            } else{
                anim.SetBool("Running", false);
            }
        } else if (Input.GetKeyUp("w")) {
            anim.SetBool("Walking", false);
            anim.SetBool("Running", false);
        }
    }

    private void Turning()
    {
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -rotSpeed * 15 * Time.deltaTime, 0, Space.World);
            if (isGrounded) anim.SetBool("Turn Left", true);
        }
        else if (Input.GetKey("d"))
        {
            transform.Rotate(0, rotSpeed * 15 * Time.deltaTime, 0, Space.World);
            if (isGrounded) anim.SetBool("Turn Right", true);
        }
        else
        {
            anim.SetBool("Turn Left", false);
            anim.SetBool("Turn Right", false);
        }
    }

    private void Actions(){
        if(Input.GetKeyDown("e")){
            anim.SetBool("Waving", true);
        } else if(Input.GetKeyUp("e")){
            anim.SetBool("Waving", false);
        }
    }

    private void Jump(){
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
            isGrounded = false;
            anim.SetTrigger("Jumping");
            StartCoroutine(DelayedJump());
        }
    }

    private IEnumerator DelayedJump(){
        yield return new WaitForSeconds(15f / 30f); // 15 frames at 30fps
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
      // <- Jump closes here

    void OnCollisionEnter(Collision collision){
        isGrounded = true;
    }
}