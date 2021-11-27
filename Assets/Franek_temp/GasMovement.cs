using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMovement : MonoBehaviour
{
    [Range(0, 10)] public float maxUpwardsSpeed;
    [Range(0, 100)] public float upwardsAcceleration;
    [Range(0, 1000)] public float sidewaysSpeed;
    [Range(0.1f, 0.2f)] public float jumpOffset;
    [Range(0, 100)] public float jumpPower;

    private Rigidbody2D _rigidbody;

    private float _lastJump;

    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0f;
        _lastJump = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        MoveSideways();
        AccelerateUpwards();
        TryJump();
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
        _spriteRenderer.flipX = xDisplacement < 0;
    }

    void TryJump()
    {
        if (Input.GetButtonDown("Jump") && _lastJump + jumpOffset < Time.time)
        {
            _lastJump = Time.time;
            _rigidbody.AddForce(Vector2.down * jumpPower, ForceMode2D.Impulse);
        }
    }
}
