using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Movement mov;
    Weapon wpn;

    // Start is called before the first frame update
    void Start()
    {
        mov = GetComponent<Movement>();
        wpn = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            mov.SetDirection(new Vector2(Input.GetAxisRaw("Horizontal"), 0.0f));
            mov.Move();
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            mov.SetDirection(new Vector2(0.0f, Input.GetAxisRaw("Vertical")));
            mov.Move();
        }
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            wpn.Shoot();
        }
    }
}
