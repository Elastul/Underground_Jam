using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RhythmController : MonoBehaviour
{
    public GameObject rhythmStick;
    public GameObject rhythmStickEmpty;
    public GameObject trainTop;
    public GameObject trainRight;
    public GameObject trainBot;
    public GameObject trainLeft;
    public GameObject railsHorizontal;
    public GameObject railsVertical;
    public GameObject tonnelBorderTop;
    public GameObject tonnelTop;
    public GameObject tonnelBorderRight;
    public GameObject tonnelRight;
    public GameObject tonnelBorderBot;
    public GameObject tonnelBot;
    public GameObject tonnelBorderLeft;
    public GameObject tonnelLeft;
    public GameObject pawn;
    public GameObject bishop;
    public GameObject rook;
    public GameObject horse;
    public AudioSource music;
    public static RhythmController rtmInstance;
    public Text textScore;
    public RectTransform rt;
    public Text text;
    int score = 0;
    public bool hasLost = false;
    // Start is called before the first frame update
    void Start()
    {
        //sound.Play();
        rtmInstance = this;
        InvokeRepeating("SpawnRhythmSticks", 1f, .5f);
        music.PlayDelayed(2.5f);
        music.loop = true;
        InvokeRepeating("SpawnTrains", 15f, 10f);
        InvokeRepeating("SpawnEnemies", 5f, 5f);
    }

    private void Update()
    {
        if (hasLost == true)
        {
            rt.gameObject.SetActive(true);
            text.text = "Game over, your score is " + score + " ,press R to restart";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void SpawnRhythmSticks()
    {
        if (hasLost == false)
        {
            score++;
            textScore.text = "Score: " + score;
        }
        Instantiate(rhythmStick, new Vector2(-2.8500f, 9f), Quaternion.Euler(Vector3.zero));
        Instantiate(rhythmStickEmpty, new Vector2(-2.8500f, -1f), Quaternion.Euler(Vector3.zero));
    }

    void SpawnEnemies()
    {
        int enemyType = Random.Range(0, 4);
        float x = Random.Range(0, 8) + .5f;
        float y = Random.Range(0, 8) + .5f;
        switch (enemyType)
        {
            case 0:
                Instantiate(pawn, new Vector2(x, y), Quaternion.Euler(Vector3.zero));
                break;
            case 1:
                Instantiate(rook, new Vector2(x, y), Quaternion.Euler(Vector3.zero));
                break;
            case 2:
                Instantiate(bishop, new Vector2(x, y), Quaternion.Euler(Vector3.zero));
                break;
            case 3:
                Instantiate(horse, new Vector2(x, y), Quaternion.Euler(Vector3.zero));
                break;
        }
    }

    void SpawnTrains()
    {
        int side = Random.Range(0, 4);
        switch (side) 
        {
            case 0:
                ChooseTile(side);
                break;
            case 1:
                ChooseTile(side);
                break;
            case 2:
                ChooseTile(side);
                break;
            case 3:
                ChooseTile(side);
                break;
        }
    }

    void ChooseTile(int side)
    {
        int tile = Random.Range(0, 8);
        float x = 0;
        float y = 0;
        switch (side)
        {
            case 0:
                x = 0.5f;
                y = 8.5f;
                switch (tile)
                {
                    case 0:
                        Instantiate(tonnelBorderTop, new Vector2(x, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainTop, new Vector2(x, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 1:
                        Instantiate(tonnelBorderTop, new Vector2(x + 1f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x + 1f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x + 1f, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x + 1f, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x + 1f, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainTop, new Vector2(x + 1f, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 2:
                        Instantiate(tonnelBorderTop, new Vector2(x + 2f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x + 2f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x + 2f, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x + 2f, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x + 2f, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainTop, new Vector2(x + 2f, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 3:
                        Instantiate(tonnelBorderTop, new Vector2(x + 3f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x + 3f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x + 3f, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x + 3f, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x + 3f, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainTop, new Vector2(x + 3f, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 4:
                        Instantiate(tonnelBorderTop, new Vector2(x + 4f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x + 4f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x + 4f, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x + 4f, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x + 4f, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainTop, new Vector2(x + 4f, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 5:
                        Instantiate(tonnelBorderTop, new Vector2(x + 5f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x + 5f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x + 5f, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x + 5f, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x + 5f, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainTop, new Vector2(x + 5f, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 6:
                        Instantiate(tonnelBorderTop, new Vector2(x + 6f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x + 6f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x + 6f, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x + 6f, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x + 6f, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainTop, new Vector2(x + 6f, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 7:
                        Instantiate(tonnelBorderTop, new Vector2(x + 7f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x + 7f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x + 7f, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x + 7f, y - 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x + 7f, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainTop, new Vector2(x + 7f, y), Quaternion.Euler(Vector3.zero));
                        break;
                }
                break;
            case 1:
                x = 8.5f;
                y = 0f;
                switch (tile)
                {
                    case 0:
                        Instantiate(tonnelBorderRight, new Vector2(x, y + .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x, y + .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x - 9f, y + .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x - 9f, y + .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(.5f, y + .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainRight, new Vector2(x, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 1:
                        Instantiate(tonnelBorderRight, new Vector2(x, y + 1.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x, y + 1.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x - 9f, y + 1.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x - 9f, y + 1.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(.5f, y + 1.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainRight, new Vector2(x, y + 1f), Quaternion.Euler(Vector3.zero));
                        break;
                    case 2:
                        Instantiate(tonnelBorderRight, new Vector2(x, y + 2.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x, y + 2.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x - 9f, y + 2.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x - 9f, y + 2.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(.5f, y + 2.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainRight, new Vector2(x, y + 2f), Quaternion.Euler(Vector3.zero));
                        break;
                    case 3:
                        Instantiate(tonnelBorderRight, new Vector2(x, y + 3.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x, y + 3.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x - 9f, y + 3.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x - 9f, y + 3.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(.5f, y + 3.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainRight, new Vector2(x, y + 3f), Quaternion.Euler(Vector3.zero));
                        break;
                    case 4:
                        Instantiate(tonnelBorderRight, new Vector2(x, y + 4.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x, y + 4.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x - 9f, y + 4.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x - 9f, y + 4.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(.5f, y + 4.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainRight, new Vector2(x, y + 4f), Quaternion.Euler(Vector3.zero));
                        break;
                    case 5:
                        Instantiate(tonnelBorderRight, new Vector2(x, y + 5.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x, y + 5.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x - 9f, y + 5.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x - 9f, y + 5.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(.5f, y + 5.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainRight, new Vector2(x, y + 5f), Quaternion.Euler(Vector3.zero));
                        break;
                    case 6:
                        Instantiate(tonnelBorderRight, new Vector2(x, y + 6.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x, y + 6.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x - 9f, y + 6.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x - 9f, y + 6.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(.5f, y + 6.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainRight, new Vector2(x, y + 6f), Quaternion.Euler(Vector3.zero));
                        break;
                    case 7:
                        Instantiate(tonnelBorderRight, new Vector2(x, y + 7.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x, y + 7.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x - 9f, y + 7.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x - 9f, y + 7.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(.5f, y + 7.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainRight, new Vector2(x, y + 7f), Quaternion.Euler(Vector3.zero));
                        break;
                }
                break;
            case 2:
                x = 0.5f;
                y = -0.5f;
                switch (tile)
                {
                    case 0:
                        Instantiate(tonnelBorderTop, new Vector2(x, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainBot, new Vector2(x, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 1:
                        Instantiate(tonnelBorderTop, new Vector2(x + 1f, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x + 1f, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x + 1f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x + 1f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x + 1f, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainBot, new Vector2(x + 1f, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 2:
                        Instantiate(tonnelBorderTop, new Vector2(x + 2f, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x + 2f, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x + 2f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x + 2f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x + 2f, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainBot, new Vector2(x + 2f, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 3:
                        Instantiate(tonnelBorderTop, new Vector2(x + 3f, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x + 3f, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x + 3f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x + 3f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x + 3f, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainBot, new Vector2(x + 3f, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 4:
                        Instantiate(tonnelBorderTop, new Vector2(x + 4f, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x + 4f, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x + 4f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x + 4f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x + 4f, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainBot, new Vector2(x + 4f, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 5:
                        Instantiate(tonnelBorderTop, new Vector2(x + 5f, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x + 5f, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x + 5f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x + 5f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x + 5f, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainBot, new Vector2(x + 5f, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 6:
                        Instantiate(tonnelBorderTop, new Vector2(x + 6f, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x + 6f, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x + 6f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x + 6f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x + 6f, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainBot, new Vector2(x + 6f, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 7:
                        Instantiate(tonnelBorderTop, new Vector2(x + 7f, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelTop, new Vector2(x + 7f, y + 9f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderBot, new Vector2(x + 7f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBot, new Vector2(x + 7f, y), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsVertical, new Vector2(x + 7f, .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainBot, new Vector2(x + 7f, y), Quaternion.Euler(Vector3.zero));
                        break;
                }
                break;
            case 3:
                x = -0.5f;
                y = 0f;
                switch (tile)
                {
                    case 0:
                        Instantiate(tonnelBorderRight, new Vector2(x + 9f, y + .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x + 9f, y + .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x, y + .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x, y + .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(.5f, y + .5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainLeft, new Vector2(x, y), Quaternion.Euler(Vector3.zero));
                        break;
                    case 1:
                        Instantiate(tonnelBorderRight, new Vector2(x + 9f, y + 1.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x + 9f, y + 1.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x, y + 1.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x, y + 1.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(.5f, y + 1.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainLeft, new Vector2(x, y + 1f), Quaternion.Euler(Vector3.zero));
                        break;
                    case 2:
                        Instantiate(tonnelBorderRight, new Vector2(x + 9f, y + 2.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x + 9f, y + 2.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x, y + 2.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x, y + 2.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(.5f, y + 2.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainLeft, new Vector2(x, y + 2f), Quaternion.Euler(Vector3.zero));
                        break;
                    case 3:
                        Instantiate(tonnelBorderRight, new Vector2(x + 9f, y + 3.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x + 9f, y + 3.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x, y + 3.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x, y + 3.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(.5f, y + 3.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainLeft, new Vector2(x, y + 3f), Quaternion.Euler(Vector3.zero));
                        break;
                    case 4:
                        Instantiate(tonnelBorderRight, new Vector2(x + 9f, y + 4.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x + 9f, y + 4.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x, y + 4.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x, y + 4.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(.5f, y + 4.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainLeft, new Vector2(x, y + 4f), Quaternion.Euler(Vector3.zero));
                        break;
                    case 5:
                        Instantiate(tonnelBorderRight, new Vector2(x + 9f, y + 5.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x + 9f, y + 5.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x, y + 5.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x, y + 5.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(.5f, y + 5.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainLeft, new Vector2(x, y + 5f), Quaternion.Euler(Vector3.zero));
                        break;
                    case 6:
                        Instantiate(tonnelBorderRight, new Vector2(x + 9f, y + 6.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x + 9f, y + 6.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x, y + 6.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x, y + 6.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(x, y + 6.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainLeft, new Vector2(x, y + 6f), Quaternion.Euler(Vector3.zero));
                        break;
                    case 7:
                        Instantiate(tonnelBorderRight, new Vector2(x + 9f, y + 7.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelRight, new Vector2(x + 9f, y + 7.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelBorderLeft, new Vector2(x, y + 7.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(tonnelLeft, new Vector2(x, y + 7.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(railsHorizontal, new Vector2(.5f, y + 7.5f), Quaternion.Euler(Vector3.zero));
                        Instantiate(trainLeft, new Vector2(x, y + 7f), Quaternion.Euler(Vector3.zero));
                        break;
                }
                break;
        }
        
    }
}
