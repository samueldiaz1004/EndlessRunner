using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
