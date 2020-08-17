using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;

    public List<string> tagsThatDestroy;
    
    private void OnCollisionEnter(Collision other)
    {
        if (tagsThatDestroy.Contains(other.gameObject.tag))
        {
            gameObject.SetActive(false);
        }
    }
}
