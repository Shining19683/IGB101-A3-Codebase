using UnityEngine;

public class GateOpen : MonoBehaviour
{
    public GameObject player;

    private Animation gate_animation;
    private bool gate_open = false;

    private float distanceFrom;
    private float prevDistanceFrom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gate_animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceFrom = Mathf.Pow(
            Mathf.Pow(transform.position.x-player.transform.position.x, 2.0f) +
            Mathf.Pow(transform.position.y-player.transform.position.y, 2.0f) +
            Mathf.Pow(transform.position.z-player.transform.position.z, 2.0f),
            1f/3f
        );
        
        if (distanceFrom < 8f && !gate_open) {
            gate_animation.Play("Open Gate");
            gate_open = true;
        } 
        else if (distanceFrom >= 8f & gate_open) {
            gate_animation.Play("Close Gate");
            gate_open = false;
        }
    }
}
