using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float followRange, attackRange;

    private GameObject playerGO;
    private RaycastHit2D hit;

    void Awake()
    {
        playerGO = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        hit = Physics2D.Raycast(transform.position, (playerGO.transform.position - transform.position).normalized, followRange);
        
        if(hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "Player") transform.Translate(playerGO.transform.position * moveSpeed * Time.deltaTime, Space.World);
        }

        Debug.DrawRay(transform.position, playerGO.transform.position, Color.blue);
    }
}
