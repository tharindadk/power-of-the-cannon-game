using UnityEngine;

public class FireEnemyBullet : MonoBehaviour
{
    private float timer = 0.0f;
    public GameObject enemyBullet;
    public Transform enemyBulletSpawn;
    public float enemyBulletSpeed;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGameOver = FindObjectOfType<GameManager>().isGameOver;
        var line = FindObjectOfType<Line>();

        if (!isGameOver)
        {
            timer += Time.deltaTime;

            if (timer > 1)
            {
                // Fire enemy bullet
                GameObject newEnemyBullet = Instantiate(enemyBullet);
                newEnemyBullet.transform.position = enemyBulletSpawn.position;
                newEnemyBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(enemyBulletSpeed, 0));

                timer = 0;
            }
        }

        if (line.transform.position.x < gameObject.transform.position.x)
        {
            Destroy(gameObject);
        }

        // Instantiate enemy if the enemy count is less than 1
        //var enemies = FindObjectsOfType<FireEnemyBullet>();
        //if (enemies.Length < 1)
        //{
            //var enemyPos = new Vector3(Random.Range(-7f, line.transform.position.x - 0.5f), Random.Range(-5f, 5f));
            //Instantiate(gameObject, enemyPos, Quaternion.identity);
        //}
    }
}
