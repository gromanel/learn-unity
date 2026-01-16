using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f; // Degrees per second
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the cube around the Y axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
