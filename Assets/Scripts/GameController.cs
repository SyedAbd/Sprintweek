using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public GameObject pausePanel;
    private bool _isPaused;
    private float _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CheckPaused();

        UpdateScore();
    }

    void CheckPaused()
    {
        if (!_isPaused)
        {
            _isPaused = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _isPaused = false;
            pausePanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    void UpdateScore()
    {
        _score += Time.deltaTime;
        timeText.text = "Time: " + (int)_score;
    }
}
