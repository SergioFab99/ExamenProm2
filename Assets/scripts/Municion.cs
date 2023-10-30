using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municion : MonoBehaviour 
{

  private Rigidbody2D rb;

  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.CompareTag("Player")) 
      {
        // Recoge la moneda
        Destroy(gameObject);

        // Aumenta bullets 
        GameManager.instance.CollectAmmo();
      }
  }

}