using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coal"))
        {
            Destroy(collision.gameObject);
        }
    }
}
