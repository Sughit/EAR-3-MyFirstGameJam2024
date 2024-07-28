using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLamp : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private Transform lampPoint;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, lampPoint.position, Time.deltaTime * 10);
        rb.MovePosition(newPos);
    }
}
