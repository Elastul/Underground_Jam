using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : MonoBehaviour
{
    Vector3 movePoint;
    Transform targetPosition;
    public float moveSpeed = 5f;
    public bool canMove = false;
    public static PawnMovement pawnInstance;
    public LayerMask trainLayer;
    public LayerMask playerLayer;
    public LayerMask wallLayer;
    public GameObject blood1;
    public GameObject blood2;
    public GameObject blood3;
    public GameObject blood4;
    public GameObject blood5;
    public GameObject blood6;
    public GameObject blood7;
    public GameObject blood8;
    public AudioSource TrainHit;

    // Start is called before the first frame update
    void Start()
    {
        movePoint = transform.position;
        pawnInstance = this;
        targetPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint, moveSpeed * Time.deltaTime);
        if(canMove == true)
        {
            if (Vector3.Distance(transform.position, movePoint) == 0f)
            {
                if ((transform.position.x + 1f) == targetPosition.position.x && (transform.position.y + 1f) == targetPosition.position.y)
                {
                    movePoint += new Vector3(1f, 1f, 0f);
                    canMove = false;
                }
                else if ((transform.position.x - 1f) == targetPosition.position.x && (transform.position.y - 1f) == targetPosition.position.y)
                {
                    movePoint += new Vector3(-1f, -1f, 0f);
                    canMove = false;
                }
                else if ((transform.position.x - 1f) == targetPosition.position.x && (transform.position.y + 1f) == targetPosition.position.y)
                {
                    movePoint += new Vector3(-1f, 1f, 0f);
                    canMove = false;
                }
                else if ((transform.position.x + 1f) == targetPosition.position.x && (transform.position.y - 1f) == targetPosition.position.y)
                {
                    movePoint += new Vector3(1f, -1f, 0f);
                    canMove = false;
                }
                else if (Mathf.Abs(Mathf.Abs(targetPosition.position.y) - Mathf.Abs(transform.position.y)) > Mathf.Abs(Mathf.Abs(targetPosition.position.x) - Mathf.Abs(transform.position.x)))
                {
                    if (!Physics2D.OverlapCircle(movePoint + new Vector3(0f, -1f, 0f), .2f, playerLayer) && transform.position.y > targetPosition.position.y)
                    {
                        movePoint += new Vector3(0f, -1f, 0f);
                        canMove = false;
                    }
                    else if (!Physics2D.OverlapCircle(movePoint + new Vector3(0f, 1f, 0f), .2f, playerLayer) && transform.position.y < targetPosition.position.y)
                    {
                        movePoint += new Vector3(0f, 1f, 0f);
                        canMove = false;
                    }
                    else if (Physics2D.OverlapCircle(movePoint + new Vector3(0f, -1f, 0f), .2f, playerLayer))
                    {
                        if(!Physics2D.OverlapCircle(movePoint + new Vector3(1f, 0f, 0f), .2f, wallLayer))
                        {
                            movePoint += new Vector3(1f, 0f, 0f);
                            canMove = false;
                        }
                        else if (!Physics2D.OverlapCircle(movePoint + new Vector3(-1f, 0f, 0f), .2f, wallLayer))
                        {
                            movePoint += new Vector3(-1f, 0f, 0f);
                            canMove = false;
                        }
                    }
                    else if (Physics2D.OverlapCircle(movePoint + new Vector3(0f, 1f, 0f), .2f, playerLayer))
                    {
                        if (!Physics2D.OverlapCircle(movePoint + new Vector3(1f, 0f, 0f), .2f, wallLayer))
                        {
                            movePoint += new Vector3(1f, 0f, 0f);
                            canMove = false;
                        }
                        else if (!Physics2D.OverlapCircle(movePoint + new Vector3(-1f, 0f, 0f), .2f, wallLayer))
                        {
                            movePoint += new Vector3(-1f, 0f, 0f);
                            canMove = false;
                        }
                    }
                }
                else if (Mathf.Abs(Mathf.Abs(targetPosition.position.y) - Mathf.Abs(transform.position.y)) < Mathf.Abs(Mathf.Abs(targetPosition.position.x) - Mathf.Abs(transform.position.x)))
                {
                    if (!Physics2D.OverlapCircle(movePoint + new Vector3(1f, 0f, 0f), .2f, playerLayer) && transform.position.x < targetPosition.position.x)
                    {
                        movePoint += new Vector3(1f, 0f, 0f);
                        canMove = false;
                    }
                    else if (!Physics2D.OverlapCircle(movePoint + new Vector3(-1f, 0f, 0f), .2f, playerLayer) && transform.position.x > targetPosition.position.x)
                    {
                        movePoint += new Vector3(-1f, 0f, 0f);
                        canMove = false;
                    }
                    else if(Physics2D.OverlapCircle(movePoint + new Vector3(1f, 0f, 0f), .2f, playerLayer))
                    {
                        if (!Physics2D.OverlapCircle(movePoint + new Vector3(0f, 1f, 0f), .2f, wallLayer))
                        {
                            movePoint += new Vector3(0f, 1f, 0f);
                            canMove = false;
                        }
                        else if (!Physics2D.OverlapCircle(movePoint + new Vector3(0f, -1f, 0f), .2f, wallLayer))
                        {
                            movePoint += new Vector3(0f, -1f, 0f);
                            canMove = false;
                        }
                    }
                    else if (Physics2D.OverlapCircle(movePoint + new Vector3(-1f, 0f, 0f), .2f, playerLayer))
                    {
                        if (!Physics2D.OverlapCircle(movePoint + new Vector3(0f, 1f, 0f), .2f, wallLayer))
                        {
                            movePoint += new Vector3(0f, 1f, 0f);
                            canMove = false;
                        }
                        else if (!Physics2D.OverlapCircle(movePoint + new Vector3(0f, -1f, 0f), .2f, wallLayer))
                        {
                            movePoint += new Vector3(0f, -1f, 0f);
                            canMove = false;
                        }
                    }
                }
                else
                {
                    if (!Physics2D.OverlapCircle(movePoint + new Vector3(0f, -1f, 0f), .2f, playerLayer) && transform.position.y > targetPosition.position.y)
                    {
                        movePoint += new Vector3(0f, -1f, 0f);
                        canMove = false;
                    }
                    else if (!Physics2D.OverlapCircle(movePoint + new Vector3(0f, 1f, 0f), .2f, playerLayer) && transform.position.y < targetPosition.position.y)
                    {
                        movePoint += new Vector3(0f, 1f, 0f);
                        canMove = false;
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Train!" + collision.gameObject.layer.Equals(10));
        if (collision.gameObject.layer.Equals(10))
        {
            TrainHit.Play();
            int i = Random.Range(0, 8);
            switch (i)
            {
                case 0:
                    Instantiate(blood1, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 1:
                    Instantiate(blood2, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 2:
                    Instantiate(blood3, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 3:
                    Instantiate(blood4, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 4:
                    Instantiate(blood5, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 5:
                    Instantiate(blood6, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 6:
                    Instantiate(blood7, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 7:
                    Instantiate(blood8, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer.Equals(11))
        {
            int i = Random.Range(0, 8);
            switch (i)
            {
                case 0:
                    Instantiate(blood1, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 1:
                    Instantiate(blood2, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 2:
                    Instantiate(blood3, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 3:
                    Instantiate(blood4, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 4:
                    Instantiate(blood5, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 5:
                    Instantiate(blood6, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 6:
                    Instantiate(blood7, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 7:
                    Instantiate(blood8, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer.Equals(12))
        {
            int i = Random.Range(0, 8);
            switch (i)
            {
                case 0:
                    Instantiate(blood1, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 1:
                    Instantiate(blood2, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 2:
                    Instantiate(blood3, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 3:
                    Instantiate(blood4, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 4:
                    Instantiate(blood5, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 5:
                    Instantiate(blood6, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 6:
                    Instantiate(blood7, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 7:
                    Instantiate(blood8, new Vector2(movePoint.x, movePoint.y), Quaternion.Euler(Vector3.zero));
                    break;
            }
            Destroy(gameObject);
        }
    }
}
