using UnityEngine;

public class NPClogic : MonoBehaviour
{
    public SpawnPoints spawnPoint;
    public IceCreamOrderGenerator orderGenerator;
    public AudioClip dollarSound;

    [SerializeField] public NPCTimer npcTimer;

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
            int moneyGained = cup.totalPrice;

            if (npcTimer != null && npcTimer.currentTime >= 10f)
            {
                moneyGained += 2;
                Debug.Log("Customer tipped $2 for fast service!");
            }
            
            AudioSource.PlayClipAtPoint(dollarSound, transform.position);
            MoneyManager.Instance.AddMoney(moneyGained);
            

            Debug.Log("Customer paid $" + moneyGained);

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