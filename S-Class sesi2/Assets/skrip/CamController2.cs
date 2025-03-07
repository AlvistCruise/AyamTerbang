using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController2 : MonoBehaviour
{
    public float distance = 5f; // Jarak kamera dari player
    public float height = 2f; // Tinggi kamera dari player
    public float rotationSpeed = 5f; // Kecepatan rotasi kamera
    private Transform player; // Referensi ke transform player
    private float currentRotation; // Rotasi kamera saat ini
    private bool isRotating = false; // Flag untuk menandakan apakah kamera sedang berputar

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Mendapatkan transform player
        Cursor.lockState = CursorLockMode.Locked; // Mengunci kursor
        Cursor.visible = false; // Menyembunyikan kursor
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Jika tombol klik kanan ditekan
        {
            isRotating = true; // Set flag rotasi menjadi true
        }

        if (Input.GetMouseButtonUp(1)) // Jika tombol klik kanan dilepas
        {
            isRotating = false; // Set flag rotasi menjadi false
        }

        if (isRotating) // Jika kamera sedang berputar
        {
            float horizontalInput = Input.GetAxis("Mouse X"); // Mendapatkan input mouse horizontal
            currentRotation += horizontalInput * rotationSpeed; // Memperbarui rotasi kamera
            Quaternion rotation = Quaternion.Euler(0f, currentRotation, 0f); // Membuat quaternion rotasi
            Vector3 desiredPosition = rotation * new Vector3(0f, 0f, -distance); // Menghitung posisi kamera yang diinginkan
            transform.position = player.position + desiredPosition + Vector3.up * height; // Memindahkan kamera
            transform.LookAt(player.position + Vector3.up * height); // Membuat kamera menghadap player
        } else { // Jika kamera tidak sedang berputar
            Quaternion rotation = Quaternion.Euler(0f, currentRotation, 0f);
            Vector3 desiredPosition = rotation * new Vector3(0f, 0f, -distance);
            transform.position = player.position + desiredPosition + Vector3.up * height;
            transform.LookAt(player.position + Vector3.up * height);
        }
        player.rotation = Quaternion.Euler(0f, currentRotation, 0f); // Merotasi player sesuai rotasi kamera
    }
}