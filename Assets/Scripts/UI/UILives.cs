using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILives : MonoBehaviour
{
    public string PlayterTag = "Player";
    public TextMeshProUGUI text;

    private void OnEnable()
    {
        Health.OnDamage += UpdateLives;        
    }

    private void OnDisable()
    {
        Health.OnDamage -= UpdateLives;
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().Lives.ToString();
    }

    void UpdateLives(string tag, int lives)
    {
        if (tag == PlayterTag)
        {
            text.text = lives.ToString();
        }
    }
}
