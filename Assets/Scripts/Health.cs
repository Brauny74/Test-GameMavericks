using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int Lives;
    public bool ExplodeOnDeath = false;
    private int CurrentLives;
    public float DeathOffset;
    
    public delegate void DeathHandler(string tag, bool fromBullet = false);
    public static event DeathHandler OnDeath;
    private bool DeathFromBullet = false;

    public delegate void DamageHandler(string tag, int lives);
    public static event DamageHandler OnDamage;

    public delegate void ExplosionHandler(Vector3 position, bool needSound);
    public static event ExplosionHandler OnExplode;

    public List<string> tagsThatDamage;

    public enum TypeOfDeath { Disable, Destroy };
    public TypeOfDeath ActionOnDeath;
    
    public void Start()
    {
        CurrentLives = Lives;
    }

    public void OnEnable()
    {
        DeathFromBullet = false;
        CurrentLives = Lives;            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (tagsThatDamage.Contains(collision.gameObject.tag))
        {
            Bullet b = collision.gameObject.GetComponent<Bullet>();
            if (b != null)
            {
                CurrentLives -= b.Damage;
                DeathFromBullet = true;
            }
            else
            {
                CurrentLives--;
                DeathFromBullet = false;
            }
            OnDamage?.Invoke(gameObject.tag, CurrentLives);
            if (CurrentLives <= 0)
            {
                StartCoroutine(StartDeath());
            }
        }        
    }

    void FinishDeath()
    {
        if (ExplodeOnDeath)
            OnExplode?.Invoke(transform.position, DeathFromBullet);
        if(ActionOnDeath == TypeOfDeath.Disable)
            gameObject.SetActive(false);
        if (ActionOnDeath == TypeOfDeath.Destroy)
            Destroy(gameObject);
    }

    IEnumerator StartDeath()
    {
        OnDeath?.Invoke(gameObject.tag, DeathFromBullet);
        yield return new WaitForSeconds(DeathOffset);
        FinishDeath();
    }
}
