using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 50.0f;

    public bool canMove = false;

    public Vector3 angleVelocity = new Vector3(0, 80f, 0);

    public ParticleSystem exhaust;

    Rigidbody playerRigidbody;

    private float hInput;
    private float vInput;

    public void Reset()
    {
        canMove = false;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        var main = exhaust.main;
        if (vInput > 0)
        {
            main.startLifetime = 1.5f;
            GameManager.Instance.fuel.ToggleHighBurnRate();
        }
        else
        {
            main.startLifetime = 0.5f;
            GameManager.Instance.fuel.ToggleLowBurnRate();
        }
    }

    private void FixedUpdate()
    {
        playerRigidbody.angularVelocity = Vector3.zero;

        if (!canMove)
        {
            return;
        }

        if (hInput != 0)
        {
            Vector3 rotSpeed = vInput != 0 ? angleVelocity * 1.5f : angleVelocity;
            Quaternion deltaRotation = Quaternion.Euler(angleVelocity * Time.fixedDeltaTime * Mathf.Sign(hInput));
            playerRigidbody.rotation = playerRigidbody.rotation * deltaRotation;
        }

        if (vInput != 0)
        {
            float fwdSpeed = vInput > 0 ? speed * 1.5f : speed;
            playerRigidbody.AddForce(Mathf.Sign(vInput) * transform.forward * fwdSpeed);
        }
    }
}
