using UnityEngine;

public class AnimalHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);      // destrói o animal
            Destroy(other.gameObject); // destrói o projétil
        }
    }
}