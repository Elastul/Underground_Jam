using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopMovement : MonoBehaviour
{
    Transform targetPosition;
    public float moveSpeed = 5f;
    public Transform bishopMovePoint;
    public LayerMask wallLayer;
    int iteration = 0;
    public bool canMove = false;
    public static BishopMovement bishopInstance;
    public LayerMask trainLayer;
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
        bishopMovePoint.parent = null;
        bishopInstance = this;
        targetPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        iteration = Random.Range(0, 4);
        transform.position = Vector3.MoveTowards(transform.position, bishopMovePoint.position, moveSpeed * Time.deltaTime);
        if(canMove == true)
        {
            if (Vector3.Distance(transform.position, bishopMovePoint.position) == 0f)
            {
                canMove = false;
                if ((transform.position.x + 1f) == targetPosition.position.x && (transform.position.y + 1f) == targetPosition.position.y)
                {
                    bishopMovePoint.position += new Vector3(1f, 1f, 0f);
                }
                else if ((transform.position.x - 1f) == targetPosition.position.x && (transform.position.y - 1f) == targetPosition.position.y)
                {
                    bishopMovePoint.position += new Vector3(-1f, -1f, 0f);
                }
                else if ((transform.position.x - 1f) == targetPosition.position.x && (transform.position.y + 1f) == targetPosition.position.y)
                {
                    bishopMovePoint.position += new Vector3(-1f, 1f, 0f);
                }
                else if ((transform.position.x + 1f) == targetPosition.position.x && (transform.position.y - 1f) == targetPosition.position.y)
                {
                    bishopMovePoint.position += new Vector3(1f, -1f, 0f);
                }
                else if (Mathf.Abs(Mathf.Abs(targetPosition.position.x) - Mathf.Abs(transform.position.x)) == Mathf.Abs(Mathf.Abs(targetPosition.position.y) - Mathf.Abs(transform.position.y)))
                {
                    if (transform.position.x > targetPosition.position.x && transform.position.y > targetPosition.position.y)
                    {
                        bishopMovePoint.position += new Vector3(-1f, -1f, 0f);
                    }
                    else if (transform.position.x < targetPosition.position.x && transform.position.y < targetPosition.position.y)
                    {
                        bishopMovePoint.position += new Vector3(1f, 1f, 0f);
                    }
                    else if (transform.position.x > targetPosition.position.x && transform.position.y < targetPosition.position.y)
                    {
                        bishopMovePoint.position += new Vector3(-1f, 1f, 0f);
                    }
                    else if (transform.position.x < targetPosition.position.x && transform.position.y > targetPosition.position.y)
                    {
                        bishopMovePoint.position += new Vector3(1f, -1f, 0f);
                    }
                }
                else if (iteration == 0)
                {
                    if (!Physics2D.OverlapCircle(bishopMovePoint.position + new Vector3(1f, 1f, 0f), .2f, wallLayer))
                    {
                        bishopMovePoint.position += new Vector3(1f, 1f, 0f);
                    }
                }
                else if (iteration == 1)
                {
                    if (!Physics2D.OverlapCircle(bishopMovePoint.position + new Vector3(1f, -1f, 0f), .2f, wallLayer))
                    {
                        bishopMovePoint.position += new Vector3(1f, -1f, 0f);
                    }
                }
                else if (iteration == 2)
                {
                    if (!Physics2D.OverlapCircle(bishopMovePoint.position + new Vector3(-1f, -1f, 0f), .2f, wallLayer))
                    {
                        bishopMovePoint.position += new Vector3(-1f, -1f, 0f);
                    }
                }
                else if (iteration == 3)
                {
                    if (!Physics2D.OverlapCircle(bishopMovePoint.position + new Vector3(-1f, 1f, 0f), .2f, wallLayer))
                    {
                        bishopMovePoint.position += new Vector3(-1f, 1f, 0f);
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
                    Instantiate(blood1, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 1:
                    Instantiate(blood2, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 2:
                    Instantiate(blood3, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 3:
                    Instantiate(blood4, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 4:
                    Instantiate(blood5, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 5:
                    Instantiate(blood6, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 6:
                    Instantiate(blood7, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 7:
                    Instantiate(blood8, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
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
                    Instantiate(blood1, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 1:
                    Instantiate(blood2, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 2:
                    Instantiate(blood3, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 3:
                    Instantiate(blood4, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 4:
                    Instantiate(blood5, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 5:
                    Instantiate(blood6, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 6:
                    Instantiate(blood7, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 7:
                    Instantiate(blood8, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
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
                    Instantiate(blood1, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 1:
                    Instantiate(blood2, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 2:
                    Instantiate(blood3, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 3:
                    Instantiate(blood4, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 4:
                    Instantiate(blood5, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 5:
                    Instantiate(blood6, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 6:
                    Instantiate(blood7, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
                case 7:
                    Instantiate(blood8, new Vector2(bishopMovePoint.position.x, bishopMovePoint.position.y), Quaternion.Euler(Vector3.zero));
                    break;
            }
            Destroy(gameObject);
        }
    }
}
