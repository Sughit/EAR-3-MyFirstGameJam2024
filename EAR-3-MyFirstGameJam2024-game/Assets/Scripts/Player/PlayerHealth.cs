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
    [SerializeField] private GameObject deathMenu;
    bool isDead;

    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0 && !isDead)
        {
            anim.SetTrigger("dead");
            isDead = true;
        }
    }

    public void ShowDeathMenu()
    {
        deathMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        slider.value = health;
        fill.color = grad.Evaluate(slider.normalizedValue);
    }
}
