using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {
    private Gun gun;

    private void Start() {
        gun = GetComponentInChildren<Gun>();
    }

    protected virtual void Update() {
        if(Input.GetMouseButtonDown(0)) {
            gun.Press();
        }

        if(Input.GetMouseButton(0)) {
            gun.Pressing();
        }

        if(Input.GetMouseButtonUp(0)) {
            gun.Release();
        }
    }
}
