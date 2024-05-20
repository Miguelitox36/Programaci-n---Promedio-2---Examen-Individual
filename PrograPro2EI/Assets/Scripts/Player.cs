using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : Entity
{
    public GameObject blackBulletPrefab;
    public GameObject whiteBulletPrefab;
    public Transform firePoint;   

    void Update()
    {
        Move();
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot("white");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Shoot("black");
        }
    }

    public override void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
               
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
        position += movement * speed * Time.deltaTime;
        transform.position = position;
    }

    void Shoot(string bulletType)
    {
        GameObject bulletPrefab = bulletType == "black" ? blackBulletPrefab : whiteBulletPrefab;
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {            
            Destroy(gameObject);
        }
    }
}
