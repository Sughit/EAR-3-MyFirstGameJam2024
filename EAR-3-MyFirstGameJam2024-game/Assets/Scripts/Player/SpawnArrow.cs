using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    [SerializeField] private GameObject arrow;

    public void SpawnArrowUp()
    {
        GameObject arrowGO = Instantiate(arrow, transform.position, Quaternion.identity);
        arrowGO.transform.eulerAngles = Vector3.forward * 90;
    }

    public void SpawnArrowDown()
    {
        GameObject arrowGO = Instantiate(arrow, transform.position, Quaternion.identity);
        arrowGO.transform.eulerAngles = Vector3.forward * -90;
    }

    public void SpawnArrowSide()
    {
        GameObject arrowGO = Instantiate(arrow, transform.position, Quaternion.identity);
        if(transform.localScale.x == -1) arrowGO.transform.eulerAngles = Vector3.forward * 180;
    }
}
