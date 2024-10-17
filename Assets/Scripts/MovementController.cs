using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float thrust = 10f, jumpForce = 1f, jumpCooldown = 2f, jumpCooldownCurrent = 2f;
    [SerializeField] Rigidbody rb;
    [SerializeField] int score = 0;
    [SerializeField] Vector3 movementForce;

    public void collectCollectible()
    {
        score++;
        Debug.Log("Score: " + score);
        GameManager.Instance.getCollectedPoints(score);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Score: " + score);
    }

    private void Update()
    {
        if (jumpCooldownCurrent < jumpCooldown)
        {
            jumpCooldownCurrent += Time.deltaTime;
        }
        movementForce = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
        {
            movementForce = new Vector3(0f, 0f, thrust);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementForce = new Vector3(-thrust, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementForce = new Vector3(0f, 0f, -thrust);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementForce = new Vector3(thrust, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCooldownCurrent >= jumpCooldown)
        {
            rb.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            jumpCooldownCurrent = 0f;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(movementForce);
    }
}
