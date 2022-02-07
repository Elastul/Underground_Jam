using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int health = 3;
    public Transform movePoint;
    public LayerMask wallLayer;
    public LayerMask enemyLayer;
    public LayerMask trainLayer;
    public bool canMove = false;
    public bool missedTiming = false;
    public bool reached = false;
    public static PlayerController plrInstance;
    public GameObject blood1;
    public GameObject slashTop;
    public GameObject slashBot;
    public GameObject slashLeft;
    public GameObject slashRight;
    public GameObject missPr;
    Canvas canvas;
    public RawImage heart1;
    public RawImage heart2;
    public RawImage heart3;
    public AudioSource Hurt;
    public AudioSource TrainHit;
    public bool hasWon = false;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        plrInstance = this;
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (health == 2)
        {
            heart3.enabled = false;
        } 
        else if (health == 1)
        {
            heart3.enabled = false;
            heart2.enabled = false;
        } 
        else if (health <= 0)
        {
            RhythmController.rtmInstance.hasLost = true;
            heart3.enabled = false;
            heart2.enabled = false;
            heart1.enabled = false;
            Instantiate(blood1, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(Vector3.zero));
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Invoke("Die", .1f);
        }
        if (canMove == true && missedTiming == false)
        {
            if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .5f, enemyLayer))
                    {
                        Instantiate(slashLeft, movePoint.position + new Vector3(-1f, 0f, 0f), Quaternion.Euler(Vector3.zero));
                    }
                    else if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, wallLayer))
                    {
                        movePoint.position += new Vector3(-1f, 0f, 0f);
                    }
                    canMove = false;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .5f, enemyLayer))
                    {
                        Instantiate(slashRight, movePoint.position + new Vector3(1f, 0f, 0f), Quaternion.Euler(Vector3.zero));
                    }
                    else if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, wallLayer))
                    {
                        movePoint.position += new Vector3(1f, 0f, 0f);
                    }
                    canMove = false;
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .5f, enemyLayer))
                    {
                        Instantiate(slashTop, movePoint.position + new Vector3(0f, 1f, 0f), Quaternion.Euler(Vector3.zero));
                    }
                    else if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, wallLayer))
                    {
                        movePoint.position += new Vector3(0f, 1f, 0f);
                    }
                    canMove = false;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .5f, enemyLayer))
                    {
                        Instantiate(slashBot, movePoint.position + new Vector3(0f, -1f, 0f), Quaternion.Euler(Vector3.zero));
                    }
                    else if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, wallLayer))
                    {
                        movePoint.position += new Vector3(0f, -1f, 0f);
                    }
                    canMove = false;                    
                }
            }
        }
        else if (canMove == false && missedTiming == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                missedTiming = true;
                Instantiate(missPr, canvas.transform);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                missedTiming = true;
                Instantiate(missPr, canvas.transform);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                missedTiming = true;
                Instantiate(missPr, canvas.transform);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                missedTiming = true;
                Instantiate(missPr, canvas.transform);
            }
        }
    }

    void Die()
    {
        this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy!" + collision.gameObject.layer.Equals(9)); 
        if (collision.gameObject.layer.Equals(9))
        {
            Hurt.Play();
            health -= 1;
        }
        Debug.Log("Train!" + collision.gameObject.layer.Equals(10));
        if (collision.gameObject.layer.Equals(10))
        {
            TrainHit.Play();
            health -= 3;
        }
    }
}
