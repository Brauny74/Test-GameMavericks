using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    Pooler pool;
    public AudioClip expSound;
    public AudioSource source;

    private void OnEnable()
    {
        Health.OnExplode += CreateExplosion;
    }

    private void OnDisable()
    {
        Health.OnExplode -= CreateExplosion;
    }

    private void Start()
    {
        pool = GetComponent<Pooler>();
        source.clip = expSound;
    }

    void CreateExplosion(Vector3 position, bool needSound)
    {
        GameObject exp = pool.GetLastInactive();
        exp.SetActive(true);
        exp.transform.position = position;
        if (needSound)
            source.Play();
    }
}
