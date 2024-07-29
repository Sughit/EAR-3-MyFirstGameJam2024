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
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        point.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        GameObject arrowGO = Instantiate(arrow, point.position, point.rotation);

        //arrowGO.transform.eulerAngles = point.transform.position * 90;
    }

    public void SpawnArrowDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        point.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        GameObject arrowGO = Instantiate(arrow, point.position, point.rotation);
    }

    public void SpawnArrowSide()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        point.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        GameObject arrowGO = Instantiate(arrow, point.position, point.rotation);
    }
}
