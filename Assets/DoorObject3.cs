using UnityEngine;

public class DoorObject : MonoBehaviour
{
    public Transform door;            // The door to move
    public float speed = 2f;          // Movement speed
    public float openDistance = 3f;   // How far to open the door

    private bool open = false;        // Is door opening?
    private float moved = 0f;         // How far the door has moved so far

    void Update()
    {
        if (open && moved < openDistance)
        {
            float moveAmount = speed * Time.deltaTime;
            door.Translate(-moveAmount, 0, 0);
            moved += moveAmount;

            // Clamp moved to openDistance to avoid overshoot
            if (moved > openDistance)
                moved = openDistance;
        }
        else if (!open && moved > 0f)
        {
            float moveAmount = speed * Time.deltaTime;
            door.Translate(moveAmount, 0, 0);
            moved -= moveAmount;

            // Clamp moved to 0 to avoid overshoot
            if (moved < 0f)
                moved = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open = false;
        }
    }
}