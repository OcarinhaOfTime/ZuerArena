using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour, Gun {
    private LineRenderer lineRenderer;
    private Transform tip;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        tip = transform.FindChild("tip");
    }

    public void Pressing() {
        lineRenderer.enabled = true;
        var hit = Physics2D.Raycast(tip.position, -transform.up);
        lineRenderer.SetPosition(0, tip.position);
        lineRenderer.SetPosition(1, hit.point);
    }

    public void Release() {
        lineRenderer.enabled = false;
    }

    public void Press() {
        
    }
}
