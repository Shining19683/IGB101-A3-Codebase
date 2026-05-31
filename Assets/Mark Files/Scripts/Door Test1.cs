using UnityEngine;

public class DoorTest1 : MonoBehaviour
{

    private Animator anim;
    private bool doorOpen = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f") && !doorOpen) {
            anim.SetBool("Open", false);
            doorOpen = true;
        } 
        if(Input.GetKeyDown("f") && doorOpen) {
            anim.SetBool("Open", true);
            doorOpen = false;
        }
    }
}
