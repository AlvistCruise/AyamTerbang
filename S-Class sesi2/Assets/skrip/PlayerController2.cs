using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : Player
{
    public float moveSpeed = 5f; // Kecepatan gerakan player
    public float rotationSpeed = 10f; // Kecepatan rotasi player
    private Camera cam; // Referensi ke kamera utama
    private Rigidbody rb; // Referensi ke komponen Rigidbody player
    private Vector3 moveDirection; // Arah gerakan player

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Mendapatkan komponen Rigidbody
        cam = Camera.main; // Mendapatkan kamera utama
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Mendapatkan input horizontal (A/D atau panah kiri/kanan)
        float vertical = Input.GetAxis("Vertical"); // Mendapatkan input vertikal (W/S atau panah atas/bawah)
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized; // Membuat vektor arah gerakan dan menormalisasinya

        // Rotasi player sesuai arah kamera
        if (moveDirection.magnitude >= 0.1f) // Jika ada input gerakan
        {
            float targetAngle = cam.transform.eulerAngles.y; // Mendapatkan rotasi Y kamera
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f); // Menghaluskan rotasi
            transform.rotation = Quaternion.Euler(0f, angle, 0f); // Menerapkan rotasi ke player
        }
    }

    private void FixedUpdate()
    {
        // Ubah arah gerakan sesuai rotasi player
        Vector3 moveRelative = transform.TransformDirection(moveDirection); // Mengubah arah gerakan ke ruang lokal player
        rb.AddForce(moveRelative * moveSpeed, ForceMode.Impulse); // Menerapkan gaya ke Rigidbody untuk gerakan
    }
}