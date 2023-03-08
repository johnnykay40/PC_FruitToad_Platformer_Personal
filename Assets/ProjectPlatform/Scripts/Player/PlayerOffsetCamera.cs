using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOffsetCamera : MonoBehaviour
{
    [SerializeField] private Transform rayCastOrigin;
    [SerializeField] private RaycastHit2D raycastHit2D;
    [SerializeField] private Color color;
    [SerializeField] private float rayDistance;
   
   
    void Update()
    {
        //CreateRayCastDirection(rayCastOrigin.position, Vector3.right, "RightWall");
        //CreateRayCastDirection(rayCastOrigin.position, Vector3.up, "UpWall");
        //CreateRayCastDirection(rayCastOrigin.position, Vector3.down, "DownWall");
        CreateRayCastDirection(rayCastOrigin.position, Vector3.left, "LeftWall");
    }

    private void CreateRayCastDirection(Vector3 originPosition, Vector3 direction, string name)
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(originPosition, direction, rayDistance);

        if (raycastHit2D)
        {
            if (raycastHit2D.transform.CompareTag("Wall"))
            {
                Debug.Log("Me di con la pared");

            } 
        }
        Debug.DrawRay(originPosition, direction, color);
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(rayCastOrigin.position, transform.forward * rayDistance);
    }*/
}
