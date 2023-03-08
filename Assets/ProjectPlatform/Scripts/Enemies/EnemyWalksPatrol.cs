using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalksPatrol : MonoBehaviour
{
    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public Transform[] moveSpots;

    [SerializeField] private float enemySpeed;

    private float idleWaitTime;
    [SerializeField] private float startIdleTime;

    private int i = 0;

    private Vector2 actualPosition;


    
    void Start()
    {
        idleWaitTime = startIdleTime;
    }
    
    void Update()
    {
        StartCoroutine(CheckEnenemyMovement());
        
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, enemySpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (idleWaitTime <= 0)
            {
                if (moveSpots[i] !=moveSpots[moveSpots.Length -1])
                {
                    i++; 
                }
                else
                {
                    i = 0;
                }

                idleWaitTime = startIdleTime;                
            }
            else
            {
                idleWaitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckEnenemyMovement()
    {
        actualPosition = transform.position;

        yield return new WaitForSeconds(0.5f);

        if (transform.position.x > actualPosition.x)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x < actualPosition.x)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x == actualPosition.x)
        {
            animator.SetBool("Idle", true);
        }
    }
}
