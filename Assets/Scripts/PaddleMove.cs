using UnityEngine;

public class PaddleMove : MonoBehaviour
{
    public float speed = 5f;

    public float fireRate = 3f;
    float timeFromLastShot = 0;
    public GameObject bullet;

    void Update()
    {
        HandleShooting();

        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");

        float speedDirectionX = x * speed * Time.deltaTime;

        if (transform.position.x + speedDirectionX >= 9f)
        {
            return;
        }

        transform.position += new Vector3(speedDirectionX, 0, 0);
    }

    void HandleShooting()
    {
        timeFromLastShot += Time.deltaTime;
        Vector3 position = transform.position + new Vector3(0, 0.2f, 0);

        if (timeFromLastShot >= (1f / fireRate))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bullet, position, Quaternion.identity);
                timeFromLastShot = 0;
            }
        }
    }
}
