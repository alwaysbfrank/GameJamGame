using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMovement : MonoBehaviour
{
    [Range(0, 10)] public float maxUpwardsSpeed;
    [Range(0, 100)] public float upwardsAcceleration;
    [Range(0, 1000)] public float sidewaysSpeed;
    [Range(0.1f, 0.2f)] public float jumpOffset;
    [Range(0.1f, 1f)] public float dashOffset;
    [Range(0, 100)] public float jumpPower;
    [Range(0, 100)] public float dashPower;

    private Rigidbody2D _rigidbody;

    private float _lastJump;
    private float _lastDash;

    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0f;
        _lastJump = Time.time - jumpOffset;
        _lastDash = Time.time - dashOffset;
    }

    // Update is called once per frame
    void Update()
    {
        MoveSideways();
        AccelerateUpwards();
        TryJump();
        TryDash();
    }

    void AccelerateUpwards()
    {
        if (_rigidbody.velocity.y < maxUpwardsSpeed)
        {
            _rigidbody.velocity += Vector2.up * upwardsAcceleration * Time.deltaTime;
        }
    }

    void MoveSideways()
    {
        var xDisplacement = Input.GetAxis("Horizontal");
        var xSpeed = xDisplacement * sidewaysSpeed * Time.deltaTime;
        var current = _rigidbody.velocity;
        _rigidbody.velocity = new Vector2(xSpeed, current.y);
        TryFlipSprite(xDisplacement);
    }

    private void TryFlipSprite(float xDisplacement)
    {
        if (xDisplacement != 0)
        {
            _spriteRenderer.flipX = xDisplacement < 0;
        }
    }

    void TryJump()
    {
        if (Input.GetButtonDown("Jump") && _lastJump + jumpOffset < Time.time)
        {
            _lastJump = Time.time;
            _rigidbody.AddForce(Vector2.down * jumpPower, ForceMode2D.Impulse);
        }
    }

    void TryDash()
    {
        if (Input.GetButtonDown("Fire1") && _lastDash + dashOffset < Time.time)
        {
            Debug.Log("Dash");
            _lastDash = Time.time;
            var direction = _spriteRenderer.flipX ? Vector2.left : Vector2.right;
            _rigidbody.AddForce(direction * dashPower, ForceMode2D.Impulse);
        }
    }
}
