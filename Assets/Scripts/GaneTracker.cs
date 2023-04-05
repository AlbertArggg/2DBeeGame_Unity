using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GaneTracker : MonoBehaviour
{
    public int level;
    public AudioSource music;
    public AudioSource sdfx;
    public AudioSource endGameMusic;
    public AudioClip hsClip;

    public int diamonds;
    public int musicVol;
    public int gameMusicVol;
    public int sdfxVol;
    public int sens;
    public int currScore;
    public int highScore;
    public int prevHighScore = 0;
    bool highscore;
    public int itm;

    public TMP_Text textMeshPro;

    public TMP_Text scoreTxt;
    public TMP_Text highscoreTxt;
    public TMP_Text diamondsTxt;

    public TMP_Text currScoreTxt;
    public TMP_Text PrevHighscoreTxt;

    float xp = 0;
    bool playerDead = false;
    GameObject spawner, obsSpawner;
    public GameObject[] gameElements;
    public GameObject endGame;
    public GameObject NHS;
    public GameObject HS;
    public SpriteRenderer cust;
    public Sprite[] custItems;

    public void setPlayerBool()
    { 
        playerDead = true;
    }
    public float getMusicVol()
    {
        float mvol = (float)gameMusicVol;
        return (mvol / 100);
    }
    public float getsdfxVol()
    {
        float sdvol = (float)sdfxVol;
        return (sdvol / 100);
    }
    private void Start()
    {
        PlayerData d = SaveAndLoadSystem.loadData();
        if (d != null)
        { 
            musicVol = d.musicVol;
            gameMusicVol = d.gameMusicVol;
            sdfxVol = d.sdfxVol;
            sens = d.sensitivity;
            highScore = d.highScore;
            diamonds = d.diamonds;
            itm = d.custItem;
            handleCust(d.custItem);

            float mvol = (float)gameMusicVol;
            music.volume = mvol / 100;
            float sdvol = (float)sdfxVol;
            sdfx.volume = sdvol / 100;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerController>().getMult(sens);
        }
        spawner = GameObject.FindGameObjectWithTag("spawnerGO");
        obsSpawner = GameObject.FindGameObjectWithTag("obsSpawner");
    }
    public void handleCust(int _custItem)
    {
        cust.sprite = custItems[_custItem];
    }
    void Update()
    {
        if (xp > highScore)
        {
            if (!highscore) 
            { 
                sdfx.PlayOneShot(hsClip); 
                prevHighScore = highScore; 
            }
            highscore = true;
            highScore = (int)xp;
        }

        if (!playerDead)
        {
            updateUI();
            float wtm = obsSpawner.GetComponent<SpawnSystem>().waittimeMax;
            if (wtm > 3) { obsSpawner.GetComponent<SpawnSystem>().setWaittimeMax(wtm - (xp / 200000)); }
        }
        else
        {
            if (highscore) { SaveAndLoadSystem.saveData(musicVol, gameMusicVol, sdfxVol, sens, highScore, diamonds,itm); }
            else { SaveAndLoadSystem.saveData(musicVol, gameMusicVol, sdfxVol, sens, prevHighScore, diamonds, itm); }
            music.volume = 0;
            spawner.SetActive(false);
            FindObjectOfType<MatOffSet>().setPlayerBool();
            gameElements = GameObject.FindGameObjectsWithTag("GameElements");
            for (int i = 0; i < gameElements.Length; i++)
            {
                if (gameElements[i].GetComponent<MoveDown>()!=null)
                {
                    gameElements[i].GetComponent<MoveDown>().setPlayerDeadBool();
                }
                else
                {
                    if (gameElements[i].GetComponentInChildren<MoveDown>() != null) { gameElements[i].GetComponentInChildren<MoveDown>().setPlayerDeadBool(); }
                    else { continue; }
                }
            }
            StartCoroutine(waitAndEnd());
        }
    }
    private void updateUI()
    {
        xp += Time.deltaTime;
        int val = ((int)xp);
        currScore = val;
        string str = val.ToString();
        textMeshPro.SetText(str);

        diamondsTxt.SetText(diamonds.ToString());
    }
    IEnumerator waitAndEnd()
    {
        yield return new WaitForSeconds(2);

        NHS.SetActive(true);
        HS.SetActive(false);
        endGameMusic.volume = getMusicVol();

        string str = currScore.ToString();
        scoreTxt.SetText(str);

        if (highscore)
        {
            str = prevHighScore.ToString();
            PrevHighscoreTxt.SetText(str);
        }

        else
        {
            str = highScore.ToString();
            highscoreTxt.SetText(str);
        }

        endGame.SetActive(true);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToGame()
    {
        string scene = "GameScene" + level;
        SceneManager.LoadScene(scene);
    }
}


