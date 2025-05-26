using UnityEngine;

public class PlayerAttack: MonoBehaviour
{
    public float attackColldown;
    public Transform firePoint;
    public GameObject[] fireballs;
    

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer=Mathf.Infinity;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackColldown && playerMovement.canAttack())
            Attack();
        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {   
        cooldownTimer = 0;
        anim.SetTrigger("attack");

        fireballs[FindFireball()].transform.position = firePoint.transform.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)return i;
        }
        return 0;
    }
}
