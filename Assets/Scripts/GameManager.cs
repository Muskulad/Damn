using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Points;
    public Slider slider;
    public TextMeshProUGUI pointsText;
    public SpawnManager spawnManagerTrash;
    public SpawnManager spawnManagerDucks;
    public GameWin gameWin;
    public GameOver gameOver;
    public GameObject stopPanel;

    // Start is called before the first frame update
    void Start()
    {
        AddPoints(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPanel();
        }
    }
    public void AddPoints(int points)
    {
        Points += points;
        slider.value = Points;
         if (Points >= 50)
        {
            pointsText.text = "Победа!";
            GameWin();
        }
        else if (Points>40)
        {
            pointsText.text = "Осталось ещё немного";
        }
        else if (Points > 30)
        {
            pointsText.text = "Монстрик почти стал человеком!";
        }
        else if (Points > 10)
        {
            pointsText.text = "Это только начало...";
        }
        else if (Points > -20)
        {
            pointsText.text = "Серьезно?";
        }
        else if (Points > -35)
        {
            pointsText.text = "Он придет к тебе ночью...";
        }
       
        else if (Points >= -50)
        {
            pointsText.text = "Поражение!";
            GameOver();
        }
    }
    public void GameWin()
    {
        gameWin.StartAnimation();
        spawnManagerDucks.isSpawnable = false;
        spawnManagerTrash.isSpawnable = false;
        GameObject[] Ducks = GameObject.FindGameObjectsWithTag("Objects");
        foreach(GameObject Duck in Ducks)
        {
            Destroy(Duck);
        }
    }
    public void GameOver()
    {
        gameOver.gameOver();
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    private void OpenPanel()
    {
        stopPanel.SetActive(true);
        Time.timeScale = 0.1f;
    }
    public void ClosePanel()
    {
        stopPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
