using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform door;   // assign the child door
    public float speed = 2f;
    private bool open = false;

    void Update()
    {
        if (open)
        {
            // Move door to the left (-x)
            door.Translate(-1 * speed * Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open = true;
        }
    }
}