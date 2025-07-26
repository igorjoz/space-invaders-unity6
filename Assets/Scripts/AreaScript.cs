using UnityEngine;

public class AreaScript : MonoBehaviour
{
    public FleetScript fleet;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Alien")
        {
            fleet.StopGame(false);
        }
    }

}
