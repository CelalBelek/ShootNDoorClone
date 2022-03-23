using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    GameManager gameManager;

    public Animator AgentAnimator;

    public Material friendsMat;
    public Material deathMat;

    public GameObject gun;

    public bool playerBool;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        gun.SetActive(false);
        AgentAnimator.SetBool("Game", false);
        playerBool = false;

        if (gameObject.tag == "Player")
            playerBool = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (playerBool == true)
            {
                gun.SetActive(true);
                AgentAnimator.SetBool("Game", true);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (playerBool == true)
            {
                gun.SetActive(false);
                AgentAnimator.SetBool("Game", false);
            }
        }

        if (gameManager.finish == true)
        {
            if (playerBool == true)
            {
                if (gameManager.win == true)
                {
                    gun.SetActive(false);
                    AgentAnimator.SetBool("Win", true);
                }
                else if (gameManager.over == true)
                {
                    gun.SetActive(false);
                    AgentAnimator.SetBool("Over", true);
                }
                else
                {
                    gun.SetActive(true);
                    AgentAnimator.SetBool("IdleShot", true);
                }
            }
        }
    }

    public void Death()
    {
        this.GetComponent<CapsuleCollider>().isTrigger = true;
        this.AgentAnimator.SetBool("Death", true);
        this.gameObject.transform.GetChild(1).GetComponent<Renderer>().material = deathMat;
        this.transform.SetParent(this.gameObject.transform.parent.transform.parent.transform);
        this.tag = "Death";
        gun.SetActive(false);
        StartCoroutine(DeathEnum());
    }

    IEnumerator DeathEnum()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }

    public void AgentFinish()
    {
        gameManager.game = false;
        gameManager.finish = true;

        AgentAnimator.SetBool("Game", false);
        AgentAnimator.SetBool("IdleShot", true);
        gun.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && this.tag != "Death")
        {
            //gameObject.GetComponent<Rigidbody>().useGravity = true;

            this.transform.SetParent(other.gameObject.transform.parent.transform);
            this.gameObject.transform.GetChild(1).GetComponent<Renderer>().material = friendsMat;

            this.tag = "Player";

            playerBool = true;
            gun.SetActive(true);
            AgentAnimator.SetBool("Game", true);
            this.GetComponent<CapsuleCollider>().isTrigger = false;
        }
    }
}
