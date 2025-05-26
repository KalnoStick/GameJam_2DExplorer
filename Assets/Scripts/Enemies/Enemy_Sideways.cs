using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
    public float damage;
    public float speed;
    public float MovingDistance;
    private float rightEdge;
    private float leftEdge;
    private bool movingLeft;

    private void Awake()
    {
        leftEdge = transform.position.x - MovingDistance;
        rightEdge=transform.position.x + MovingDistance;
    }
    private void Update()
    {
        if (movingLeft)
        {
            if(transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z); 
            }
            else 
                movingLeft = false;
        }
        else
        {
            if(transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
