using System.Collections;
using TMPro;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    public float damage;

    [Header ("FireTrap Timers")]
    public float activationDelay;
    public float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool active;
    private bool triggered;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered)
        {
            StartCoroutine(ActivateFiretrap());
        }
        if (active)
            collision.GetComponent<Health>().TakeDamage(damage);
    }

    private IEnumerator ActivateFiretrap()
    {
        triggered = true;
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("activated", true);

        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
