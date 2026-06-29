using UnityEngine;

public class CupPlacer : MonoBehaviour
{
    [SerializeField] private GameObject cupPrefab;
    [SerializeField] private Transform cupPos;

    private bool slotFull;
    private GameObject currentCup;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Cup"))
            return;

        if (slotFull)
        {
            Debug.Log("Slot Full");
            return;
        }

        DraggedTopping topping = other.GetComponent<DraggedTopping>();
        if (topping == null)
            return;

        ToppingTypes type = topping.toppingType;

        Destroy(other.gameObject);

        SpawnCupVisual(type, cupPos.position);

        slotFull = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == currentCup)
        {
            Debug.Log("Placed cup removed");

            slotFull = false;
            currentCup = null;
        }
    }

    private void SpawnCupVisual(ToppingTypes type, Vector3 position)
    {
        GameObject prefab = GetCupPrefab(type);
        if (prefab == null) return;

        currentCup = Instantiate(prefab, position, Quaternion.identity, transform);
    }

    private GameObject GetCupPrefab(ToppingTypes type)
    {
        return type switch
        {
            ToppingTypes.Cup => cupPrefab,
            _ => null
        };
    }
}