using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameManager gameManager;
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D _rigid;
    SpriteRenderer _spriteRenderer;
    Animator anim;
    CapsuleCollider2D _collider;

    void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Jump
        if (Input.GetButton("Jump") && !anim.GetBool("isJump"))
        {
            _rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
        }

        //Stop Speed
        if (Input.GetButtonUp("Horizontal")) //buttonUp = 버튼을 뗀다
        {
            _rigid.velocity = new Vector2(_rigid.velocity.normalized.x * 0.5f, _rigid.velocity.y);
        }

        //Direction Sprite
        if (Input.GetButtonDown("Horizontal"))
            _spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        //Walk Anim
        if (Mathf.Abs(_rigid.velocity.x) < 0.3)
            anim.SetBool("isWalk", false);
        else
            anim.SetBool("isWalk", true);

    }

    void FixedUpdate()
    {
        //Move Speed
        float h = Input.GetAxisRaw("Horizontal");
        _rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //Max Speed
        if (_rigid.velocity.x > maxSpeed) // Right max speed
        {
            _rigid.velocity = new Vector2(maxSpeed, _rigid.velocity.y);
        }
        else if (_rigid.velocity.x < maxSpeed * (-1))// Left max speed
        {
            _rigid.velocity = new Vector2(maxSpeed * (-1), _rigid.velocity.y);
        }

        //Lading Platform
        if(_rigid.velocity.y < 0)
        {
            Debug.DrawRay(_rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(_rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                    anim.SetBool("isJump", false);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (_rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y) //몬스터 어택
            {
                OnAttack(collision.transform);
            }
            else
                OnDamaged(collision.transform.position);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            //Add Point
            gameManager.stagePoint += 100;

            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Finish")
        {
            gameManager.GameFinish(); 
        }

    }

    void OnAttack(Transform enemy)
    {
        //Add Point
        gameManager.stagePoint += 100;

        _rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        EnemyMove enemyMove = enemy.GetComponent<EnemyMove>();
        enemyMove.OnDamaged();
    }

    void OnDamaged(Vector2 targetPos)
    {
        gameManager.HealthDown();
        gameObject.layer = 11;
        _spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1; // 적 혹은 장애물과 부딪혔을 때 부딪힌 방향으로 튕겨나간다.
        _rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);

        Invoke("OffDamaged", 3f);

    }

    void OffDamaged()
    {
        gameObject.layer = 10;
        _spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void OnDie()
    {
        _spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        _spriteRenderer.flipY = true;
        _collider.enabled = false;
        _rigid.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
    }

    public void VelocityZero()
    {
        _rigid.velocity = Vector2.zero;
    }
}
