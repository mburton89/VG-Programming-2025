using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpikeEnemy : MonoBehaviour
{
    public GameObject target;

    public List<GameObject> spikes;

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
            Attack();
        }

        //For testing out Spike Enemy death - remove after merge
        if(Input.GetKeyDown(KeyCode.V))
        {
            TakeDamage();
        }
    }

    public void Attack()
    {
        Debug.Log("Attack");
        StartCoroutine(GrowSpikes());
        //Player.TakeDamage(spikeEnemyDamage);
    }

    IEnumerator GrowSpikes()
    {
        foreach (var spike in spikes)
        {
            spike.transform.localScale = new Vector3(6f, spike.transform.localScale.y, spike.transform.localScale.z);
        }

        yield return new WaitForSeconds(0.5f);

        foreach (var spike in spikes)
        {
            spike.transform.localScale = new Vector3(0.2f, spike.transform.localScale.y, spike.transform.localScale.z);
        }

        StopCoroutine(GrowSpikes());
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
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
