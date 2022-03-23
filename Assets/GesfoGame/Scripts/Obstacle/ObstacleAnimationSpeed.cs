using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimationSpeed : MonoBehaviour
{
    public float speed;

    void Start()
    {
        gameObject.GetComponent<Animator>().speed = speed;     
    }
}
