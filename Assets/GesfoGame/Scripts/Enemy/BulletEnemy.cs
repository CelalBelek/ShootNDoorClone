using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float shootForce;
    public int end;

    private Vector3 startPos;
    private Transform startPos2;

    void Start()
    {
        startPos = this.transform.position;
        startPos2 = this.transform;
    }

    void Update()
    {
        if (startPos.x >= 0)
            this.GetComponent<Rigidbody>().AddForce(new Vector3(startPos.x + 5, -startPos.y, -startPos.z) * shootForce, ForceMode.Impulse);
        else
            this.GetComponent<Rigidbody>().AddForce(new Vector3(startPos.x - 5, -startPos.y, -startPos.z) * shootForce, ForceMode.Impulse);

        if (transform.position.z <= startPos.z - end)
        {
            Debug.Log("200 Metre Enemy");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<AgentController>().Death();
        }
    }
}
