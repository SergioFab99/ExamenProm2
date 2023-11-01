using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    public int life = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life--;
            if (life <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Derrota");
            }
        }
    }
}
