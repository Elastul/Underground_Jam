using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmStickEmptyController : MonoBehaviour
{
    public float rhythm = 1f;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-2.85f, 4f), rhythm * Time.deltaTime);
        if (transform.position.y == 4f)
        {
            StartCoroutine(IDestroy());
        }
    }

    IEnumerator IDestroy()
    {
        sr.enabled = false;
        yield return new WaitForSecondsRealtime(.2f);
        Destroy(gameObject);
    }
}
