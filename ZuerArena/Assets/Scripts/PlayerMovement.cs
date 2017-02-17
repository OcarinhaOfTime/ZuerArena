using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movePower = 100f;
    public float maxSpeed = 10;
    Rigidbody2D rb2d;
    Animator animator;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	
	void Update () {
        var mouseGlobalPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var z = Quaternion.LookRotation(transform.position - mouseGlobalPos, Vector3.forward).eulerAngles.z;
        transform.rotation = Quaternion.Euler(0, 0, z + 180);
    }

    void FourDirUpdate() {
        var mouseGlobalPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var rot = Quaternion.LookRotation(transform.position - mouseGlobalPos, Vector3.forward).eulerAngles;
        float angle = (rot.z + 45 + 90) % 360;
        angle /= 360;
        animator.SetFloat("angle", angle);
    }

    private void FixedUpdate() {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if((rb2d.velocity.magnitude < maxSpeed && v >= 0) || (rb2d.velocity.magnitude > -maxSpeed && v <= 0)) {
            rb2d.AddForce(Vector3.up * movePower * v + Vector3.right * movePower * h);
        }

        animator.SetFloat("speed",Mathf.Abs(h) + Mathf.Abs(v));
    }
}
