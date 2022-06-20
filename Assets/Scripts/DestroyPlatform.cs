using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{

    [SerializeField] private int timeToDestroy = 3;

    private void Start()
    {
        StartCoroutine("destroyPlatform");
    }

    IEnumerator destroyPlatform()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
