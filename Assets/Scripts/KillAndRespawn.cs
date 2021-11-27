using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillAndRespawn : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("PlayerRock") || collision.gameObject.CompareTag("PlayerGas"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
