using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform point;
    [SerializeField] private PentruAnimatiiArcher animScript;
    [SerializeField] private MeniuInGame menu;

    void Update()
    {
        if(!animScript.isAttacking && !menu.menuCheck)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            Vector2 lookDir = mousePos - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            point.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }
    public void SpawnArrowFunc()
    {
        GameObject arrowGO = Instantiate(arrow, point.position, point.rotation);
    }
}
