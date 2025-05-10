using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMoviment : MonoBehaviour
{
    public Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(velocity.x, velocity.y, 0);
    }
}
