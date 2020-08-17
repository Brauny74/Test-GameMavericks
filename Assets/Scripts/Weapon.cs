using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float CooldownTime;
    public Vector3 shootOffset;
    public AudioClip shootSound;
    public AudioSource source;

    float currentCooldownTime;
    bool readyToShoot;

    Pooler ammoPool;
    // Start is called before the first frame update
    void Start()
    {
        ammoPool = GetComponent<Pooler>();
        currentCooldownTime = CooldownTime;
        readyToShoot = true;

        source.clip = shootSound;
    }

    private void Update()
    {
        if (!readyToShoot)
        {
            currentCooldownTime -= Time.deltaTime;
            if (currentCooldownTime < 0.0f)
            {
                readyToShoot = true;
                currentCooldownTime = CooldownTime;
            }
        }
    }

    public void Shoot()
    {
        if (readyToShoot)
        {
            readyToShoot = false;
            GameObject bullet = ammoPool.GetLastInactive();
            bullet.SetActive(true);
            bullet.transform.position = transform.position + shootOffset;
            if (source != null)
            {
                source.Play(); 
            }
        }
    }
}
