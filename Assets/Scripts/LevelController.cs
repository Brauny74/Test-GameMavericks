using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public bool GameActive;

    public Level level;
    public string MeteorTag;

    public float SpawnMaxLeftX = -65;
    public float SpawnMaxRightX = 65;
    public float SpawnY = 48;
    public float MaxScale = 1.2f;
    public float MinScale = 0.8f;
    Pooler pooler;
    float currentMeteorRespawnCooldown;
    int currentMeteors;

    public GameObject WinWindow;
    public GameObject LoseWindow;

    public delegate void UpdateMeteorsHandler(string meteors);
    public static event UpdateMeteorsHandler OnUpdateMeteors;

    public delegate void VictoryHandler();
    public static event VictoryHandler OnVictory;

    void OnEnable()
    {
        Health.OnDeath += MeteorDeath;
        Health.OnDeath += PlayerDeath;
    }

    private void OnDisable()
    {
        Health.OnDeath -= MeteorDeath;
        Health.OnDeath -= PlayerDeath;
    }

    public void Init(Level l)
    {
        GameActive = true;
        WinWindow.SetActive(false);
        LoseWindow.SetActive(false);

        pooler = GetComponent<Pooler>();
        level = l;
        currentMeteorRespawnCooldown = level.RespawnCooldown;
        currentMeteors = 0;
        OnUpdateMeteors?.Invoke(currentMeteors.ToString() + "/" + level.AmountOfMeteorsToWin.ToString());
    }

    void Update()
    {
        if (!GameActive)
            return;

        currentMeteorRespawnCooldown -= Time.deltaTime;
        if (currentMeteorRespawnCooldown <= 0.0f)
        {
            SpawnMeteor();
            currentMeteorRespawnCooldown = level.RespawnCooldown;
        }        
    }

    void SpawnMeteor()
    {
        GameObject tmpObj = pooler.GetLastInactive();
        Vector2 newPosition = new Vector2(Random.Range(SpawnMaxLeftX, SpawnMaxRightX), SpawnY); 
        tmpObj.SetActive(true);
        tmpObj.transform.position = new Vector3(newPosition.x, 1.5f, newPosition.y);
        float scale = Random.Range(MinScale, MaxScale);
        tmpObj.transform.localScale = new Vector3(scale, scale, scale);
    }

    void MeteorDeath(string tag, bool fromBullet)
    {
        if (!GameActive)
            return;

        if (tag == MeteorTag && fromBullet)
        { 
            currentMeteors++;
            OnUpdateMeteors?.Invoke(currentMeteors.ToString() + "/" + level.AmountOfMeteorsToWin.ToString());
            if (currentMeteors == level.AmountOfMeteorsToWin)
            {
                OnVictory?.Invoke();
                GameController.instance.LevelBeaten(level);
                WinWindow.SetActive(true);
                GameController.instance.music.PlayWin();
                GameActive = false;
            }
        }
    }

    void PlayerDeath(string tag, bool bullet = false)
    {
        if (tag == "Player")
        {
            LoseWindow.SetActive(true);
            GameController.instance.music.PlayLoss();
            GameActive = false;
        }
    }

    public void BackToMenu()
    {
        GameController.instance.MoveScene("MainMenu");
    }
}
