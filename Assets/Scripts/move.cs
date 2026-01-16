using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject redCube;
    public float moveSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Move()
    {
        redCube.transform.Translate(0, moveSpeed * Time.deltaTime, 0);

    }
}
