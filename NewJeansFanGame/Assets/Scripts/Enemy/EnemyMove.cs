using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D _rigid;
    public int nextMove;

    void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
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
            nextMove *= -1;
            CancelInvoke();
            Invoke("Think", 5);

        }

    }

    //재귀함수
    void Think()
    {
        nextMove = Random.Range(-1, 2);

        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }

}
