using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGun : MonoBehaviour, Gun {
    public float shootForce = 10;
    public GameObject projectilePrefab;
    public float coolDown = 1;

    private float timer = 999;
    bool canShot { get { return timer > coolDown; } }

    private void Update() {
        timer += Time.deltaTime;
    }

    public void Pressing() {
        Debug.Log("shottt!!!" + timer);
        Debug.Log("shottt!!!" + canShot);
        if(!canShot)
            return;

        Debug.Log("shooting bitch!!!");
        var projectile = Instantiate(projectilePrefab, projectilePrefab.transform.position, Quaternion.identity);
        projectile.SetActive(true);
        projectile.GetComponent<Rigidbody2D>().AddForce(-transform.up * shootForce, ForceMode2D.Impulse);
        timer = 0;
    }

    public void Release() {
    }

    public void Press() {
        
    }
}
