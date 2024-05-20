using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public string enemyType;
    public float speed = 5f;
    public int damage = 1;

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
                
        if (transform.position.y < -Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if ((enemyType == "black" && other.CompareTag("BlackBullet")) || (enemyType == "white" && other.CompareTag("WhiteBullet")))
        {
            Destroy(other.gameObject); 
            Destroy(gameObject); 
        }
    }
}
