using UnityEngine;
using System.Collections.Generic;

public class test : MonoBehaviour
{
    public GameObject thisIsAGameObject;
    public Transform thisIsATransform;
    public float rotationSpeed = 90f;
    public move moveScript; // Reference to the move script component

    void Update()
    {
        thisIsATransform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (moveScript != null)
            {
                moveScript.Move();
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            thisIsATransform.Translate(1*Time.deltaTime, 0, 0);
        }
    }
}
