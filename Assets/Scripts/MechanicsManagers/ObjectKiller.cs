using UnityEngine;

public class KillOnCollision : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip cupCrashSound;
    [SerializeField] private AudioClip toppingCrashSound;
    [SerializeField] private AudioClip iceCreamCrashSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cup"))
        {
            audioSource.PlayOneShot(cupCrashSound);
        }
        else if (collision.CompareTag("RealTopping"))
        {
            audioSource.PlayOneShot(toppingCrashSound);
        }
        else if (collision.CompareTag("IceCream"))
        {
            audioSource.PlayOneShot(iceCreamCrashSound);
        }

        Destroy(collision.gameObject);
    }

}