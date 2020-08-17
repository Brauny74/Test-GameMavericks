using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocity;

    Vector2 movementDirection;
    Rigidbody rgbdy;

    // Start is called before the first frame update
    void Start()
    {
        rgbdy = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        if (rgbdy != null)
        {
            Vector3 movemenetDirection3 = new Vector3(movementDirection.x, 0, movementDirection.y);
            rgbdy.AddForce(movemenetDirection3 * velocity);
            if (rgbdy.velocity.magnitude >= velocity)
                rgbdy.velocity = movemenetDirection3 * velocity;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(movementDirection.x, transform.position.y, movementDirection.y), velocity);
        }
    }

    public void SetDirection(Vector2 newDirection)
    {
        movementDirection = newDirection.normalized;
    }

    public void SetDirecton(Vector3 newDirection)
    {
        movementDirection = new Vector2(newDirection.x, newDirection.z).normalized;
    }
}
