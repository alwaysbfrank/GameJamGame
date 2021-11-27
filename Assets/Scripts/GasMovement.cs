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

    [Range(0, 1)] public float dashAccelerationTime;
    [Range(0, 100)] public float dashBrakePower;

    private Rigidbody2D _rigidbody;

    private float _lastJump;
    private float _lastDash;
    private bool _currentlyDashing;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0f;
        _lastJump = Time.time - jumpOffset;
        _lastDash = Time.time - dashOffset;
        _currentlyDashing = false;
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
        if (_currentlyDashing)
        {
            return;
        }

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
            _currentlyDashing = true;
            _rigidbody.velocity -= Vector2.right * _rigidbody.velocity.x;
        }

        if (!_currentlyDashing)
        {
            return;
        }
        
        if (Time.time - _lastDash < dashAccelerationTime)
        {
            AccelerateInDash();
            return;
        }

        if (DecelerateInDash())
        {
            _currentlyDashing = false;
        }
    }

    private bool DecelerateInDash()
    {
        var currentVel = _rigidbody.velocity;
        var currentSpeedX = currentVel.x;
        var direction = currentSpeedX < 0 ? 1f : -1f;
        var newSpeed = currentSpeedX + direction * Time.deltaTime * dashBrakePower;
        var result = direction > 0 == newSpeed > 0;
        if (result)
        {
            newSpeed = 0f;
        }

        _rigidbody.velocity = new Vector2(newSpeed, currentVel.y);
        return result;
    }

    private Vector2 GetDirection()
    {
        return _spriteRenderer.flipX ? Vector2.left : Vector2.right;
    }

    private void AccelerateInDash()
    {
        _rigidbody.velocity += GetDirection() * dashPower * Time.deltaTime;
    }
}