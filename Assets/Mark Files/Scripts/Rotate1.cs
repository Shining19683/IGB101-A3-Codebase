using UnityEngine;

public class ConstantRotation1 : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // Degrees per second

    void Update()
    {
        // Rotate the object every frame
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}