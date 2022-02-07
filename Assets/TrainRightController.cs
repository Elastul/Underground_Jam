using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainRightController : MonoBehaviour
{
    Vector3 movePoint;
    Vector2 targetPosition;
    public float moveSpeed = 5f;
    public bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {
        movePoint = transform.position;
        targetPosition = new Vector2(transform.position.x + -15f, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint, moveSpeed * Time.deltaTime);
        if (canMove == true)
        {
            if ((Vector2)transform.position == targetPosition)
            {
                Destroy(gameObject);
            }
            else if (Vector3.Distance(transform.position, movePoint) == 0f)
            {
                movePoint += new Vector3(-1f, 0f, 0f);
                canMove = false;
            }
        }
    }
}
