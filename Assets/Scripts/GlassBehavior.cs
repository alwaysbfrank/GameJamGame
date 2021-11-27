using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBehavior : MonoBehaviour
{
    public bool isDestructable;

    private void Start()
    {
        isDestructable = false;

        GameEventSystem.Instance.OnPlayerIsStone += SetDestructable;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isDestructable)
        {
            Destroy(gameObject);
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
