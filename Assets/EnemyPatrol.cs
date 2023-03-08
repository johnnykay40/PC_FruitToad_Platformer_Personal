using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    Rigidbody2D enemyRigidBody2D;
    public int UnitsToMove = 5;
    public float EnemySpeed = 5;
    public bool _isFacingLeft;
    private float _startPos;
    private float _endPos;

    public bool _moveLeft = true;

    public SpriteRenderer spriteRenderer;
    public Animator animator;


    // Use this for initialization
    public void Awake()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        _startPos = transform.position.x;
        _endPos = _startPos + UnitsToMove;
        _isFacingLeft = transform.localScale.x > 0;
    }


    // Update is called once per frame
    public void Update()
    {

        if (_moveLeft)
        {
            enemyRigidBody2D.AddForce(Vector2.left * EnemySpeed * Time.deltaTime);
            if (!_isFacingLeft)
                Flip();
        }

        if (enemyRigidBody2D.position.x >= _endPos)
            _moveLeft = false;

        if (!_moveLeft)
        {
            enemyRigidBody2D.AddForce(-Vector2.left * EnemySpeed * Time.deltaTime);
            if (_isFacingLeft)
                Flip();
        }
        if (enemyRigidBody2D.position.x <= _startPos)
            _moveLeft = true;


    }

    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingLeft = transform.localScale.x > 1;
    }
}
