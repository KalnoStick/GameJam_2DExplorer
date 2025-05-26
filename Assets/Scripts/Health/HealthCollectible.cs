using System.Runtime.CompilerServices;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public float HealthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            collision.GetComponent<Health>().AddHealth(HealthValue);
            gameObject.SetActive(false);
        }
    }
}
