using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movePower = 100f;
    public float maxSpeed = 10;
    Rigidbody2D rb2d;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        var mouseGlobalPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(transform.position - mouseGlobalPos, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);      
    }

    private void FixedUpdate() {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if((rb2d.velocity.magnitude < maxSpeed && v >= 0) || (rb2d.velocity.magnitude > -maxSpeed && v <= 0)) {
            rb2d.AddForce(transform.up * movePower * v + transform.right * movePower * h);
        }
    }
}
