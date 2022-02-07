using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnvController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 7.5f);
    }
}
