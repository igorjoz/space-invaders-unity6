using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        Destroy(gameObject, 4);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Alien")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
