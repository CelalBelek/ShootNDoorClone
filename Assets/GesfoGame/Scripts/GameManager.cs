using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool game;
    public bool finish;
    public bool win;
    public bool over;

    public float finishTime;
    public TextMeshProUGUI finishTimeTmp;

    public GameObject winPanel;
    public GameObject overPanel;
    public GameObject finishPanel;

    void Start()
    {
        game = false;
        finish = false;
        win = false;
        over = false;

        winPanel.SetActive(false);
        overPanel.SetActive(false);
        finishPanel.SetActive(false);

        finishTimeTmp.text = "0";
    }

    private void Update()
    {
        if (finish)
        {
            finishTime -= Time.deltaTime;

            finishTimeTmp.text = Mathf.Round(finishTime).ToString();

            if (finishTime <= 0 && !win)
            {
                Over();
            }
        }
    }

    public void Win()
    {
        win = true;
        winPanel.SetActive(true);
        finishPanel.SetActive(false);
    }

    public void Over()
    {
        over = true;
        overPanel.SetActive(true);
        finishPanel.SetActive(false);
    }
}
