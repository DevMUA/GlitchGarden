using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel = null;
    [SerializeField] GameObject loseLabel = null;
    [SerializeField] float waitToLoad = 4f;
    bool lost = false;

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }
    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <= 0 && levelTimerFinished && lost == false)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelManager>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        Debug.Log("you lost");
        loseLabel.SetActive(true);
        Time.timeScale = 0;
        bool lost = true;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        var spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}
