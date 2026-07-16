using UnityEngine;

public class NPClogic : MonoBehaviour
{
    public SpawnPoints spawnPoint;
    public IceCreamOrderGenerator orderGenerator;

    private void Start()
    {
        if (orderGenerator == null)
            orderGenerator = GetComponent<IceCreamOrderGenerator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ParfaitCup cup = other.GetComponent<ParfaitCup>();

        if (cup == null)
            return;

        bool correctOrder = orderGenerator.CheckOrder(
            cup.slot1Type,
            cup.slot2Type,
            cup.slot3Type
        );

        if (correctOrder)
        {
            MoneyManager.Instance.AddMoney(cup.totalPrice);

            Debug.Log("Customer paid $" + cup.totalPrice);

            Destroy(other.gameObject);
            Kill();
        }
        else
        {
            Debug.Log("Wrong order! Customer rejected it.");
        }
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