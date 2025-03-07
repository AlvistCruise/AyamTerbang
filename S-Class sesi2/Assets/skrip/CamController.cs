using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public float distance = 5f;
    public float height = 2f;
    public float rotationSpeed;
    private Transform player;
    private float currentRotation;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        currentRotation += horizontalInput * rotationSpeed;
        player.rotation = Quaternion.Euler(0f, -currentRotation, 0f);
        Debug.Log(currentRotation);
        Quaternion rotation = Quaternion.Euler(0f, currentRotation, 0f);
        Vector3 desiredPosition = rotation * new Vector3(0f, 0f, -distance);
        transform.position = player.position + desiredPosition + Vector3.up * height;
        transform.LookAt(player.position + Vector3.up * height);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}