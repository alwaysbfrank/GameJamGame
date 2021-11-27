using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("PlayerRock") || collision.gameObject.CompareTag("PlayerGas"))
        {
            SceneManager.LoadScene("Nazwa sceny");
        }
    }
}
