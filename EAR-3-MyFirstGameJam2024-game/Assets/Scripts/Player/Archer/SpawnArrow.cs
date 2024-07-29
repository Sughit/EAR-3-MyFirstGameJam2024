using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform point;

    public void SpawnArrowUp()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        point.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    
        GameObject arrowGO = Instantiate(arrow, transform.position, Quaternion.identity);
        arrowGO.transform.eulerAngles = point.transform.position * 90;
    }

    public void SpawnArrowDown()
    {
        GameObject arrowGO = Instantiate(arrow, transform.position, Quaternion.identity);
        arrowGO.transform.position = arrowGO.transform.position;
    }

    public void SpawnArrowSide()
    {
        GameObject arrowGO = Instantiate(arrow, transform.position, Quaternion.identity);
        if(transform.localScale.x == -1) arrowGO.transform.eulerAngles = Vector3.forward * 180;
    }
}
