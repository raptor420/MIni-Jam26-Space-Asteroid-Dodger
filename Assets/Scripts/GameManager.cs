using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public EnemtSpawner enemySpawner;
    bool GameOver;
    int Wave;
    public TextMeshProUGUI WaveText;
    public GameObject RestartUi;
    AudioSource aud;
    public float fadetime;
    public bool pause;
    private void Start()
    {
        pause = false;
        aud = GetComponent<AudioSource>();
        if (player != null)
        {

            player.deathevent += SetGameOver; // SETGAMEOVER CALL HOBE PLAYER MORLE

        }
        GameOver = false;
        if (RestartUi != null)
        {
            RestartUi.SetActive(false);

        }

    }

    private void SetGameOver()
    {
        GameOver = true;
        enemySpawner.SpawnerOn = false;
        RestartUi.SetActive(true);
        if (aud.isPlaying)
        {

            //  aud.Stop();
           StartCoroutine( fadeAudio(aud, fadetime));

        }
        player.deathevent -= SetGameOver;
    }


    IEnumerator fadeAudio(AudioSource source,float fadetime){

        float startvolume = source.volume;
        while (startvolume > 0)
        {

            source.volume -= startvolume  * Time.deltaTime / fadetime;
            yield return null;
        }
        source.Stop();

        }
    private void Update()
    {
        
        

            if (Input.GetMouseButtonDown(1))
            {
            if (player.playerAlive  )
            {
                if (!pause)
                {
                    aud.Pause();
                    Time.timeScale = 0;
                    
                    pause = true;
                   
                }

                else
                {
                    if (!aud.isPlaying)
                    {

                        aud.PlayDelayed(.5f);
                    }
                    Time.timeScale = 1;
                  
                    pause = false;
                 
                }
            }

            

            }

        

        if (Input.GetMouseButtonDown(0))
        {
            Restart();
        }
    }




    public void Restart()
    {

        if (GameOver)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }

   public void setWave(int Wave)
    {

        this.Wave = Wave;

        UpdateUIWave(Wave);
    }

    public void UpdateUIWave(int Wave)
    {
        WaveText.text = "Wave:" + Wave.ToString(); 


    }

 




}
