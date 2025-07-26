using UnityEngine;

public class PaddleMove : MonoBehaviour
{
    public float speed = 5f;

    public float fireRate = 1f;
    float timeFromLastShoot = 0;
    public GameObject bullet;

    void Update()
    {
        Move();
        Shoot();
    }

    //funkcja odpowiedzialna za ruch
    void Move()
    {
        //Odczytujemy z GetAxisRaw w kt�r� stron� chcemy si� porusza�
        float x = Input.GetAxisRaw("Horizontal");
        //wyliczamy pr�dko�� w wbranym kierunku
        float speedDir = x * speed * Time.deltaTime;
        transform.position += new Vector3(speedDir, 0, 0);
    }

    void Shoot()
    {
        //liczymy kidy ostatnio wystrzelili�my
        timeFromLastShoot += Time.deltaTime;
        //wyliczamy gdzie ma si� pojawi� pocisk
        Vector3 pos = transform.position + new Vector3(0, 0.1f, 0);
        //je�eli czas od ostatniego wystrza�u jest wystarczaj�co du�y
        if (timeFromLastShoot >= (1f / fireRate))
        {
            //Po naci�ni�ciu klawisza
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //tworzymy pocisk
                Instantiate(bullet, pos, Quaternion.identity);
                //zerujemy czas od wystrzelenia
                timeFromLastShoot = 0;
            }
        }
    }
}
