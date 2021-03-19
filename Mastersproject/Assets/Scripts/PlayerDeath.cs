using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
     private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.CompareTag("Enemy"))
         {
             Destroy(gameObject);
             LevelManager.instance.Respawn();
        }
        else if (collision.gameObject.CompareTag("spike"))
        {
            Destroy(gameObject);
            LevelManager.instance.Respawn();
        }
    }


    /*public Vector3 respawnPosition;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            transform.position = respawnPosition;
        }

        if (collision.tag == "Checkpoint")
        {
            respawnPosition = collision.transform.position;
        }
    }*/
}
