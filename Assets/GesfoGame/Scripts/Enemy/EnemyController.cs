using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    GameManager gameManager;

    public Animator EnemyAnimator;

    public Material deathMat;

    public GameObject gun;
    public GameObject player;
    public GameObject healthBar;

    public bool playerBool;

    public float enemyRange;
    public int enemyHealt;

    //Gun
    RaycastHit hit;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        gun.SetActive(false);
        EnemyAnimator.SetBool("Game", false);
        playerBool = false;

        enemyHealt = 100;
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, enemyRange))
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                if(EnemyAnimator.GetBool("Shoot") == false)
                {
                    EnemyAnimator.SetBool("Shoot", true);
                    gun.SetActive(true);
                }
            }
        }

        if (hit.transform != null)
        {
            if (hit.collider.gameObject.tag == "Player" && (gameObject.transform.rotation.y > 160 || gameObject.transform.rotation.y < 200))
            {
                //gameObject.transform.LookAt(player.transform.position);
            }
        }
    }

    public void HealthControll(int val)
    {
        if (gameManager.finishTime > 0)
        {
            if (enemyHealt > 0)
            {
                enemyHealt -= val;
                healthBar.transform.GetComponent<Slider>().value = enemyHealt;
            }
            else
            {
                gameManager.Win();
                EnemyAnimator.SetBool("Death", true);
                gun.SetActive(false);

                this.gameObject.transform.GetChild(1).GetComponent<Renderer>().material = deathMat;
                playerBool = false;
                StartCoroutine(Death());
            }
        }
        else
        {
            EnemyAnimator.SetBool("Win", true);
            gun.SetActive(false);
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}
