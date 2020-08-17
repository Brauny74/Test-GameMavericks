using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILevelSelect : MonoBehaviour
{
    public TextMeshProUGUI label;
    public Image icon;
    public Sprite locked;
    public Sprite unlocked;
    public Sprite beaten;

    private Level level;

    public void Init(Level l)
    {
        level = l;
        switch (l.CurrentState)
        {
            case Level.LevelState.Unlocked:
                icon.sprite = unlocked;
                break;
            case Level.LevelState.Locked:
                icon.sprite = locked;
                break;
            case Level.LevelState.Beaten:
                icon.sprite = beaten;
                break;
        }
        label.text = l.name;
    }

    public void SelectLevel()
    {
        if(level.CurrentState != Level.LevelState.Locked)
            GameController.instance.SetLevel(level);
    }
}
