using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float offsetY = 5f;
    public float followSpeed = 2f;
    public float upwardSpeed = 1f; 

    private Vector3 initialOffset;

    void Start()
    {
        if (player != null)
        {
            initialOffset = new Vector3(0, offsetY, -10f); 
            transform.position = player.position + initialOffset;
        }
        else
        {
            Debug.LogError("Player transform is not assigned to the CameraController.");
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {            
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y + offsetY, player.position.z - 10f);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            transform.position += Vector3.up * upwardSpeed * Time.deltaTime;
        }
    }
}
