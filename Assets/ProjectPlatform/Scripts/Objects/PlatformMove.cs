using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform[] moveSpots;
    private float idleWaitTime;
    private int i = 0;

    [SerializeField] private float platformSpeed;    
    [SerializeField] private float startIdleTime;

    void Start()
    {
        idleWaitTime = startIdleTime;
    }

    void Update()
    {       
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, platformSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (idleWaitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
        
    }
}
