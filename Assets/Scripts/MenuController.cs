using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject levelSelectWindow;
    public GameObject levelIconPrefab;

    public float StartFrom = -195f;
    public float Step = 120f;

    List<UILevelSelect> levelSelects;

    // Start is called before the first frame update
    void Start()
    {
        List<Level> levels = GameController.instance.levels;
        levelSelects = new List<UILevelSelect>();
        for(int i = 0; i < levels.Count; i++)
        {
            UILevelSelect newLevel = Instantiate(levelIconPrefab, levelSelectWindow.transform).GetComponent<UILevelSelect>();
            levelSelects.Add(newLevel);
            newLevel.Init(levels[i]);
            newLevel.GetComponent<RectTransform>().anchoredPosition = new Vector2(StartFrom + Step * i, 0.0f);
        }
        CloseLevelSelectWindow();
    }

    public void OpenLevelSelectWindow()
    {
        levelSelectWindow.SetActive(true);
    }

    public void CloseLevelSelectWindow()
    {
        levelSelectWindow.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
    
}
