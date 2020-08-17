using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public MusicController music;

    public List<Level> levels;
    private Level chosenLevel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        music = GetComponent<MusicController>();
        music?.PlayMenu();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += InitScene;    
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= InitScene;
    }

    private void InitScene(Scene scene, LoadSceneMode mode)
    {
        LevelController levelController = GameObject.FindGameObjectWithTag("LevelController")?.GetComponent<LevelController>();
        if (levelController != null)
        {
            levelController.Init(chosenLevel);//change to level change later        
            music.PlayGame();
        }
        else
        {
            music.PlayMenu();
        }
    }

    public void SetLevel(Level l)
    {
        chosenLevel = l;
        MoveScene("GameScene");
    }

    public void LevelBeaten(Level l)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if (l == levels[i])
            {
                levels[i].Beat();
                if (i < levels.Count - 1)
                    levels[i + 1].Unlock();
                return;
            }
        }
    }

    public void MoveScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }
}
