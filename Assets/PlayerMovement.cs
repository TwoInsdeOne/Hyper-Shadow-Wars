using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerActions playerActions;
    private Vector2 direction;
    public float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        playerActions = new PlayerActions();
        playerActions.Movement.Enable();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = playerActions.Movement.Move.ReadValue<Vector2>();
        direction = direction.normalized;

        rb.AddForce(direction*speed, ForceMode2D.Impulse);
    }
}
