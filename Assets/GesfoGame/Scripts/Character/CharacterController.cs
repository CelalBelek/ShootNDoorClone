using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    GameManager gameManager;
    AgentController agentController;

    public Camera mainCamera;

    private Transform localTrans;

    private Vector3 lastMousePos;
    private Vector3 mousePos;
    private Vector3 newPosForTrans;

    private float xDiff;

    public float speed;
    public float swipeSpeed;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        agentController = FindObjectOfType<AgentController>();

        localTrans = GetComponent<Transform>();
    }

    void Update()
    {
        if(gameObject.transform.childCount > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, swipeSpeed));
                lastMousePos = mousePos;

                gameManager.game = true;
            }
            else if (Input.GetMouseButton(0) && gameManager.game == true)
            {
                mousePos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, swipeSpeed));

                xDiff = mousePos.x - lastMousePos.x;
                newPosForTrans.x = localTrans.position.x + xDiff;
                newPosForTrans.y = localTrans.position.y;
                newPosForTrans.z = localTrans.position.z;

                localTrans.position = newPosForTrans + localTrans.forward * speed * Time.deltaTime;

                lastMousePos = mousePos;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                gameManager.game = false;
            }
        }
        else
        {
            gameManager.game = false;
            gameManager.Over();
        }
    }

}
