// Attached to MachineGun

using UnityEngine;

public class MachineGunMovement : MonoBehaviour
{
    private bool isGameOver;

    void Update()
    {
        isGameOver = FindObjectOfType<GameManager>().isGameOver;

        if (!isGameOver)
        {
            if (Input.GetKeyDown("up") && transform.position.y < 4)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
            }

            if (Input.GetKeyDown("down") && transform.position.y > -3)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 1f);
            }
        }
    }
}
