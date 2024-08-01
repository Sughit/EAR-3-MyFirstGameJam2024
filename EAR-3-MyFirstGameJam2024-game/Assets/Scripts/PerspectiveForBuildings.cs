using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveForBuildings : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer renderer))
        {
            renderer.sortingOrder = 6;
        }
        else
        {
            SpriteRenderer ren = other.gameObject.GetComponentInChildren<SpriteRenderer>();
            if(ren != null) ren.sortingOrder = 6;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer renderer))
        {
            renderer.sortingOrder = 10;
        }
        else
        {
            SpriteRenderer ren = other.gameObject.GetComponentInChildren<SpriteRenderer>();
            if(ren != null) ren.sortingOrder = 10;
        }
    }
}
