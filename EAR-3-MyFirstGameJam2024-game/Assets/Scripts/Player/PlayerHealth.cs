using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health = 100f, maxHealth = 100f;
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient grad;
    [SerializeField] private Image fill;
    [SerializeField]private Animator anim;

    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            anim.SetTrigger("dead");
        }
    }
    void Update()
    {
        slider.value = health;
        fill.color = grad.Evaluate(slider.normalizedValue);
        if(Input.GetKeyDown(KeyCode.K))
            TakeDamage(100);
    }
}
