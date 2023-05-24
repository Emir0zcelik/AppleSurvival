using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject apple;

    private Animator anim;
    private PlayerMovement playerMovement;
    private ItemCollector collector;

    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        collector = GetComponent<ItemCollector>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Attack") && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            if(collector.appleCounter > 0)
            {
                collector.appleCounter--;
                
            }

            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("isAttack");
        cooldownTimer = 0;

        Instantiate(apple, firePoint.position, transform.rotation);
    }
}
