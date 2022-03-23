using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    GameManager gameManager;

    public GameObject bullet;

    public Transform attackPoint;

    private float time;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        time = 1.0f;
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            Shoot();
            time = 1.0f;
        }
    }

    private void Shoot()
    {
        if (gameManager.game || gameManager.finish)
        {
            GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        }
    }
}
