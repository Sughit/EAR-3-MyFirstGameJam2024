using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] private float seconds = 2f;

    void Awake()
    {
        Destroy(this.gameObject, seconds);
    }
}
