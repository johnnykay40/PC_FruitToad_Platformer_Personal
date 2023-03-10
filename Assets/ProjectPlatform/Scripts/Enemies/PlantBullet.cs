using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDestroyTime;

    public bool facingLeft;

    private void Start()
    {
        Destroy(gameObject, bulletDestroyTime);
    }

    private void Update()
    {
        if (facingLeft)
        {
            transform.Translate(Vector2.left * bulletSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
        }
    }

}
