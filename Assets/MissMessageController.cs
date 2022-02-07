using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissMessageController : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rt;
    void Start()
    {
        rt = GetComponent<RectTransform>();
        Destroy(gameObject, 1.5f);
    }

    private void Update()
    {
        rt.position = Vector2.MoveTowards(rt.position, new Vector2(rt.position.x, rt.position.y + 32f), 1f * Time.deltaTime);
    }
}
