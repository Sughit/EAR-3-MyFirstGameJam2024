using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestClock : MonoBehaviour
{
    [SerializeField] private Transform clockHand;

    void Update()
    {
        float dayNormalized = GameManager.instance.currentHour % 1f;

        clockHand.eulerAngles = new Vector3(0, 0, -dayNormalized * 360f);
    }
}
