using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime;

    [SerializeField] private float waitTimeToAttack;

    public Animator animator;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPosition;

    private void Start()
    {
        waitedTime = waitTimeToAttack;
    }

    private void Update()
    {
        if (waitedTime <= 0)
        {
            waitedTime = waitTimeToAttack;
            animator.Play("PlantAttackAnimation");
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }
}
