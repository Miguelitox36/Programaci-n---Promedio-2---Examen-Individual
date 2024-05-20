using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Vector3 position;
    public float speed;
    public int health;

    public virtual void Move() { }   
}
