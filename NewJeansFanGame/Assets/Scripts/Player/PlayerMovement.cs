using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D _rigidbody;
    SpriteRenderer spriteRenderer;
    Animator anim;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJump"))
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
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

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
}
