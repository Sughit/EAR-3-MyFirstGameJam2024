using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomAttack : AgentAttack
{
    [SerializeField] private float projectileMaxMoveSpeed, projectileMaxHeight;
    [SerializeField] private AnimationCurve trajectoryAnimationCurve, axisCorrectionAnimationCurve, projectileSpeedAnimationCurve;
    [SerializeField] private GameObject projectilePrefab;
    private Transform target;
    [SerializeField] private AIData aiData;
    [SerializeField] private GameObject targetSpot;

    void Awake()
    {
        aiData = transform.parent.gameObject.GetComponent<AIData>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(target != null) Debug.Log(target.position);
    }

    public override void Attack()
    {
        anim.SetTrigger("attack");
        target = Instantiate(targetSpot, aiData.currentTarget.position, Quaternion.identity).transform;
    }

    public void SpawnBoom()
    {
        Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();

        projectile.InitializeProjectile(target, projectileMaxMoveSpeed, projectileMaxHeight);
        projectile.InitializeAnimationCurves(trajectoryAnimationCurve, axisCorrectionAnimationCurve, projectileSpeedAnimationCurve);
    }
}
