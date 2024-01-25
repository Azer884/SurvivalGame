using UnityEngine;

public class MeleeSystem : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public float attackRange = 1.0f;
    public float attackDamage = 10;
    public float nextAttackTime = 0;
    public float AttackRate = 2f;
    public Animator Anim;
    public Enemy PlayerHealth;
    private void Start()
    {

    }

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (PlayerHealth.currentHealth > 20f)
                {
                    Anim.SetTrigger("hit");
                    Attack();
                }
                else
                {
                    Debug.Log("Broo do u wanna die");
                }
                nextAttackTime = Time.time + 1f / AttackRate ;
            }
        }
    }

    private void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
