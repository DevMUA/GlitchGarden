using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
    Text livesText;
    float lives;

    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateDisplay();

    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLife()
    {
            lives -= damage;
            UpdateDisplay();

        if(lives <= 0)
        {
            Debug.Log("you lost");
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
        
    }
}
