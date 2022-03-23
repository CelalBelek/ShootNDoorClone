using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private bool first = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (first == false)
            {
                for (int i = 0; i < other.gameObject.transform.parent.gameObject.transform.childCount; i++)
                {
                    other.gameObject.transform.parent.gameObject.transform.GetChild(i).gameObject.GetComponent<AgentController>().AgentFinish();
                    first = true;
                    FindObjectOfType<GameManager>().finishPanel.SetActive(true);
                    Destroy(gameObject);
                }
            }
        }
    }
}
