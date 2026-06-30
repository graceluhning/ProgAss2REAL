using UnityEngine;

public class NPClogic : MonoBehaviour
{
    public SpawnPoints spawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Kill();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (spawnPoint != null)
            spawnPoint.occupied = false;
    }
}