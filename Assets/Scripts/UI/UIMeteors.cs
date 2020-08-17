using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMeteors : MonoBehaviour
{
    public string MeteorTag = "Enemy";
    public TextMeshProUGUI text;

    private void OnEnable()
    {
        LevelController.OnUpdateMeteors += UpdateMeteors;
    }

    private void OnDisable()
    {
        LevelController.OnUpdateMeteors -= UpdateMeteors;
    }

    void UpdateMeteors(string meteors)
    {
        text.text = meteors;
    }
}
