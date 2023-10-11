using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D _rigid;
    SpriteRenderer _spriteRenderer;
    public int nextMove;

    void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();

        _spriteRenderer = GetComponent<SpriteRenderer>();

        Think();

        Invoke("Think", 5);
    }

    void FixedUpdate()
    {
        _rigid.velocity = new Vector2(nextMove, _rigid.velocity.y);

        Vector2 frontVec = new Vector2(_rigid.position.x + nextMove * 0.3f, _rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
        {
            Turn();   
        }

    }


    void Think()
    {
        nextMove = Random.Range(-1, 2);

        //재귀 함수 Recursive
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);

        if (nextMove != 0)
        {
            _spriteRenderer.flipX = nextMove == 1;
        }
    }

    void Turn()
    {
        nextMove *= -1;
        _spriteRenderer.flipX = nextMove == 1;


        CancelInvoke();
        Invoke("Think", 5);

    }

}
