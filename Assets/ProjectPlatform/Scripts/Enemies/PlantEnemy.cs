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


}
