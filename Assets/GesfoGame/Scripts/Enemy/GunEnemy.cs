using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : MonoBehaviour
{
    public GameObject bullet;

    public Transform attackPoint;

    private float time;

    private void Awake()
    {
        time = 0.5f;
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            Shoot();
            time = 0.5f;
        }
    }

    private void Shoot()
    {
         GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
    }
}
