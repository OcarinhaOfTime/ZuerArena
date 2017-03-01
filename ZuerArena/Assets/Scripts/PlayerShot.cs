using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {
    private Gun gun;
    private Animator animator;

    private bool pressed;

    private void Start() {
        gun = GetComponentInChildren<Gun>();
        animator = GetComponentInChildren<Animator>();
    }

    protected virtual void Update() {
        if(Input.GetMouseButtonDown(0)) {
            animator.SetBool("aiming", true);
        }

        if(Input.GetMouseButtonUp(0)) {
            pressed = false;
            gun.Release();
            animator.SetBool("aiming", false);
        }

        if(pressed) {
            gun.Pressing();
        }
    }

    public void OnPress() {
        pressed = true;
        gun.Press();
    }
}
