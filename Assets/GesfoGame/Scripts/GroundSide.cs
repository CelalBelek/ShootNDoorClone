using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.tag = "NPC";
            other.transform.SetParent(transform);
            other.GetComponent<AgentController>().playerBool = false;
            other.GetComponent<AgentController>().Death();
        }
    }
}
