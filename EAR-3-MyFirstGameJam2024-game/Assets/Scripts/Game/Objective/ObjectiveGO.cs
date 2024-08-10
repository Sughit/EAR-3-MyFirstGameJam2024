using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveGO : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] TMP_Text text;

    public void SetItem(Sprite icon, int num)
    {
        img.sprite = icon;
        text.text = $"{num}";
    }

    public void SetItem(int num)
    {
        num = Mathf.Clamp(num, 0, 255);
        text.text = $"{num}";
    }
}
