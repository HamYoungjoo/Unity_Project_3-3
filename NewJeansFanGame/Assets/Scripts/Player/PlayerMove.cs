using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;
    Animator anim;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Jump
        if (Input.GetButton("Jump") && !anim.GetBool("isJump"))
        {
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
        }

        //Stop Speed
        if (Input.GetButtonUp("Horizontal")) //buttonUp = 버튼을 뗀다
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.normalized.x * 0.5f, _rigidbody.velocity.y);
        }

        //Direction Sprite
        if (Input.GetButtonDown("Horizontal"))
            _spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        //Walk Anim
        if (Mathf.Abs(_rigidbody.velocity.x) < 0.3)
            anim.SetBool("isWalk", false);
        else
            anim.SetBool("isWalk", true);

    }

    void FixedUpdate()
    {
        //Move Speed
        float h = Input.GetAxisRaw("Horizontal");
        _rigidbody.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //Max Speed
        if (_rigidbody.velocity.x > maxSpeed) // Right max speed
        {
            _rigidbody.velocity = new Vector2(maxSpeed, _rigidbody.velocity.y);
        }
        else if (_rigidbody.velocity.x < maxSpeed * (-1))// Left max speed
        {
            _rigidbody.velocity = new Vector2(maxSpeed * (-1), _rigidbody.velocity.y);
        }

        //Lading Platform
        if(_rigidbody.velocity.y < 0)
        {
            Debug.DrawRay(_rigidbody.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(_rigidbody.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
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
            OnDamaged(collision.transform.position);
        }
    }

    void OnDamaged(Vector2 targetPos)
    {
        gameObject.layer = 11;
        _spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1; // 적 혹은 장애물과 부딪혔을 때 부딪힌 방향으로 튕겨나간다.
        _rigidbody.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);

        Invoke("OffDamaged", 3f);

    }

    void OffDamaged()
    {
        gameObject.layer = 10;
        _spriteRenderer.color = new Color(1, 1, 1, 1);

    }
}
