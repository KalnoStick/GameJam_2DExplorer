using Unity.VisualScripting;
using UnityEngine;

public class Health:MonoBehaviour
{
    public float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool down = false;

    private void Awake()
    {
        currentHealth=startingHealth;
        anim=GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth>0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!down)
            {
                anim.SetTrigger("down");
                GetComponent<PlayerMovement>().enabled = false;
                down = true;
            }
        }
    }
}
