using UnityEngine;

public class NPClogic : MonoBehaviour
{
    public SpawnPoints spawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ParfaitCup cup = other.GetComponent<ParfaitCup>();

        if (cup == null)
            return;
        
        MoneyManager.Instance.AddMoney(cup.totalPrice);

        Debug.Log("Customer paid $" + cup.totalPrice);
        
        Destroy(other.gameObject);
        
        Kill();
    }

    private void Timer()
    {
        
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