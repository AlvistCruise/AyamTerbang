using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : Player
{
    public float dashDistance;
    public float dashCooldown;
    private Rigidbody rb;
    private float currentDashCooldown;
    private TrailRenderer trailRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentDashCooldown = dashCooldown;
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        currentDashCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && currentDashCooldown <= 0)
        {
            rb.AddForce(GetComponent<PlayerController2>().moveDirection  * dashDistance, ForceMode.Impulse);
            currentDashCooldown = dashCooldown;
            trailRenderer.enabled = true;
            StartCoroutine(TrailRenderDelay());
        }
    }

    IEnumerator TrailRenderDelay()
    {
        yield return new WaitForSeconds(0.1f);
        trailRenderer.enabled = false;
    }
}