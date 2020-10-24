using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefab = null;

    bool spawn = true;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        if(attackerPrefab.Length == 0) { return;  }
        int randomEnemy = 0;
        randomEnemy = UnityEngine.Random.Range(0, attackerPrefab.Length);
        Spawn(attackerPrefab[randomEnemy]);
        
    }

    private void Spawn(Attacker attackerPrefabe)
    {
        Attacker newAttacker = Instantiate(attackerPrefabe, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
