using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMovement : MonoBehaviour
{
    public Vector2 direction;
    Movement mov;

    // Start is called before the first frame update
    void Start()
    {
        mov = GetComponent<Movement>();
        mov.SetDirection(direction);
    }

    // Update is called once per frame
    void Update()
    {
        mov.Move();
    }
}
