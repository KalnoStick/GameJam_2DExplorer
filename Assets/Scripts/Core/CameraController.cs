using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraController: MonoBehaviour
{
    //Room camera
    public float speed;
    private float currentPosX;
    private Vector3 velocity=Vector3.zero;

    public Transform player;
    public float aheadDistance;
    public float cameraSpeed;
    private float lookAhead;
    private void Update()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);
        transform.position= new Vector3(player.position.x+lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance*player.localScale.x),cameraSpeed*Time.deltaTime);
    }

    public void MovetoNewRoom(Transform _newRoom)
    {
        currentPosX=_newRoom.position.x;
    }
}
