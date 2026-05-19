using UnityEngine;
using UnityEngine.UIElements;

public class Fade : MonoBehaviour
{
    public GameObject cameraObject;
    float distanceFrom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceFrom = Mathf.Sqrt(
            Mathf.Pow(transform.position.x-cameraObject.transform.position.x, 2.0f) +
            Mathf.Pow(transform.position.y-cameraObject.transform.position.y, 2.0f) +
            Mathf.Pow(transform.position.z-cameraObject.transform.position.z, 2.0f)
        );
        distanceFrom = Mathf.Pow(distanceFrom/30.0f, 16.0f);

        if (distanceFrom > 1.0f)
        {
            distanceFrom = 1.0f;
        }
        if (distanceFrom < 0.0f)
        {
            distanceFrom = 0.0f;
        }
        this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f-distanceFrom);
    }
}
