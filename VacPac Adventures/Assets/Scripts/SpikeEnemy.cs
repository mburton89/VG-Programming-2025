using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpikeEnemy : MonoBehaviour
{
    public GameObject target;

    public Animator animator;

    public GameObject slimeDropPrefab;

    public float attackRange;

    public float spikeEnemyHealth;
    public float spikeEnemyDamage;

    public float attackCooldown;
    private float lastAttackTime;

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        if (distanceToTarget <= attackRange && Time.time >= attackCooldown + lastAttackTime)
        {
            lastAttackTime = Time.time;
            StartCoroutine(AttackWithSpikes());
        }
    }

    IEnumerator AttackWithSpikes()
    {
        animator.SetBool("isAttacking", true);

        AudioManager.Instance.PlaySound("Spike", false);

        yield return new WaitForSeconds(0.5f);

        PlayerTemp.Instance.currenthealth -= 2;

        animator.SetBool("isAttacking", false);

        StopCoroutine(AttackWithSpikes());
    }

    public void TakeDamage()
    {
        spikeEnemyHealth -= 3;

        if (spikeEnemyHealth <= 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(slimeDropPrefab, transform.position, transform.rotation);
            }
            AudioManager.Instance.PlaySound("SlimeDeath", false);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SlimeBullet"))
        {
            TakeDamage();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
