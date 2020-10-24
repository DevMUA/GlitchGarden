using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;
    [SerializeField] GameObject gun = null;
    AttackerSpawner myLaneSpawner = null;
    Animator animator = null;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount > 0)
        {
            return true;
        }
        return false;
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] AttackerSpawners;
        AttackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in AttackerSpawners)
        {
            bool isCloseEnough = Mathf.Approximately(spawner.transform.position.y + 0.2f, transform.position.y);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    public void Fire(float damage)
    {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }
}
