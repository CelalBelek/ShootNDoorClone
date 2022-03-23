using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float shootForce;
    public int end;
    public int power;

    private Vector3 startPos;

    void Start()
    {
        startPos = this.transform.position;
    }

    void Update()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * shootForce, ForceMode.Impulse);

        if (transform.position.z >= startPos.z + end)
        {
            Debug.Log("200 Metre");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Değdi Düşman");
            Destroy(gameObject);
            other.GetComponent<EnemyController>().HealthControll(power);
        }
    }
}
