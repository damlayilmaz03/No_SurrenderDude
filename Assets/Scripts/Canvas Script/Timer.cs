using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    TextMeshProUGUI time,players;
    int x;
    public float timeRemaining = 59;
    public bool timerIsRunning = false;
    public List<GameObject> objectsOnGround;
    int totalObjectsOnGround = 0;
    int objectsonGround = 0;

    void Start()
    {
        Time.timeScale = 1;
        time = GameObject.Find("Canvas/Time/timer").GetComponent<TextMeshProUGUI>();
        timerIsRunning = true;
        time.text = timeRemaining.ToString();

        players= GameObject.Find("Canvas/Players/players").GetComponent<TextMeshProUGUI>();

        totalObjectsOnGround = CountObjectsOnGround(); //oyun başlarken zemindeki total obje sayısı
        objectsonGround = totalObjectsOnGround;
        players.text=objectsonGround.ToString();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;//zaman geri sayımı
                x = Mathf.RoundToInt(timeRemaining);
                time.text = x.ToString();

                
                int currentObjectsOnGround = CountObjectsOnGround(); //zemindeki mevcut objelerin sayısı

                
                if (currentObjectsOnGround < objectsonGround) //zemindeki obje sayısı azaldıysa mevcut sayıyı güncelle
                {
                    RemoveMissingObjects();
                    totalObjectsOnGround = CountObjectsOnGround();
                    objectsonGround = totalObjectsOnGround;
                    players.text = objectsonGround.ToString();
                }

                if (objectsonGround == 1) // 1 oyuncu kaldıysa oyun biter
                {
                    
                    Time.timeScale = 0;
                    timerIsRunning = false;
                    SceneManager.LoadScene(0);
                }
            }
            else
            {
                timeRemaining = 0;  // zaman sıfırlandığında oyun biter zeminde kaç oyuncu olduğu önemsiz
                Time.timeScale = 0;
                timerIsRunning = false;
                SceneManager.LoadScene(0);
            }
        }
    }
    public void Pause()//pausebutton
    {
        Time.timeScale = 0;
    }
    public void Restart()//restartbutton
    {
        SceneManager.LoadScene(0);
    }
    public void Play()//playbutton
    {
        Time.timeScale = 1;
    }
    int CountObjectsOnGround() //zemindeki nesnelerin sayisinin kontrolu
    {
        int count = 0;
        for (int i = objectsOnGround.Count - 1; i >= 0; i--)
        {
            if (objectsOnGround[i] == null)
            {
                objectsOnGround.RemoveAt(i);
            }
            else
            {
                count++;
            }
        }
        return count;
    }

    void RemoveMissingObjects()//zemindeki nesneler artık zeminde olmagından silinebilir, silinen nesne varsa arrayden kaldır
    {
        for (int i = objectsOnGround.Count - 1; i >= 0; i--)
        {
            if (objectsOnGround[i] == null)
            {
                objectsOnGround.RemoveAt(i);
            }
        }
    }
}
