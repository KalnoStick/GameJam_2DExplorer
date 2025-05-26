using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class Health:MonoBehaviour
{
    [Header("Health")]
    public float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool down = false;

    [Header("iFrames")]
    public float iFramesDuration;
    public int numberOfFlashes;
    private SpriteRenderer spriteRend;
    private void Awake()
    {
        currentHealth=startingHealth;
        anim=GetComponent<Animator>();
        spriteRend=GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth>0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
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
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 5f);
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false) ;
    }
}
