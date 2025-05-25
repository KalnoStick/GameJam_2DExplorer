using UnityEngine;

public class Door: MonoBehaviour 
{
    public Transform prevoiusRoom;
    public Transform nextRoom;
    public CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if (collision.transform.position.x < transform.position.x)
                cam.MovetoNewRoom(nextRoom);
            else
                cam.MovetoNewRoom(prevoiusRoom);
        }
    }

}
