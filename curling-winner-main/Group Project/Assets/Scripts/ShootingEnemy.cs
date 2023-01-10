using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShootingEnemy : MonoBehaviour
{
    public int enemyAttack = 2;
    public int enemyRange = 4;
    public float lookRadius = 10f;
    public PlayerHealth ph;
    float TimerForNextAttack;
    public float Cooldown;
    //Gun Functions
    public ParticleSystem muzzleFlash;
    public AudioSource shootSound;
    Transform target;
    UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        ph = FindObjectOfType<PlayerHealth>();

        Cooldown = 3;
        TimerForNextAttack = Cooldown;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (TimerForNextAttack > 0)
        {
            TimerForNextAttack -= Time.deltaTime;
        }

        else if (TimerForNextAttack <= 0 && distance <= enemyRange)
        {
            
            Shoot();
            DamagePlayer();
            TimerForNextAttack = Cooldown;
        }

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                // Face the target

                FaceTarget();

                // Attack the target

                // playerhealth.TakeDamage(enemyAttack);
            }
        }
    }

    void DamagePlayer()
    {
        ph.TakeDamage(enemyAttack);
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    void Shoot()
    {
        muzzleFlash.Play();
        shootSound.Play();
    }
}
