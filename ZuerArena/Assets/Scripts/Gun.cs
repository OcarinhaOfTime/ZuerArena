using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public float shootForce = 10;
    public GameObject projectilePrefab;
    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    public void Shoot() {
        var projectile = Instantiate(projectilePrefab, projectilePrefab.transform.position, Quaternion.identity);
        projectile.SetActive(true);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * shootForce, ForceMode2D.Impulse);
    }
}
