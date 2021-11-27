using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBehavior : MonoBehaviour
{
    public bool isDestructable;
    public Sprite destroyedSprite;

    private SpriteRenderer sr;

    private void Start()
    {
        isDestructable = false;

        sr = GetComponent<SpriteRenderer>();
        GameEventSystem.Instance.OnPlayerIsStone += SetDestructable;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isDestructable)
        {
            sr.sprite = destroyedSprite;
        }
    }

    void SetDestructable(bool _isStone)
    {
        isDestructable = _isStone;
    }

    private void OnDestroy()
    {
        GameEventSystem.Instance.OnPlayerIsStone -= SetDestructable;
    }
}
