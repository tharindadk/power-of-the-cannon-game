// Attached to MachineGun

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float bulletSpeed = 1.0f;
    public GameObject bullet;
    public Transform bulletSpawn;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGameOver = FindObjectOfType<GameManager>().isGameOver;

        if (Input.GetKeyDown(KeyCode.Space) && !isGameOver) {
            // Play audio
            AudioManager.Instance.PlaySFX("CannonBullet");

            // Instantiate bullet
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = bulletSpawn.position;
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletSpeed, 0));
        }
    }
}
