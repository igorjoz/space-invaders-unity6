using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    void Start()
    {
        //ustawiamy po jakim czasie nas pocisk sam siê zniszczy
        Destroy(gameObject, 3);
    }
    // Update is called once per frame
    void Update()
    {
        //poruszamy pociskiem
        Move();
    }
    void Move()
    {
        //przesuwamy siê w górê o nasz¹ prêdkoœæ
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Je¿eli dotkniemy element z tagiem Alien
        if (collision.gameObject.tag == "Alien")
        {
            //zniszczymy ten obiekt
            Destroy(collision.gameObject);
            //oraz siebie
            Destroy(gameObject);
        }
    }
}