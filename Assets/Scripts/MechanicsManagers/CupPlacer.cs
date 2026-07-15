using UnityEngine;

public class CupPlacer : MonoBehaviour
{
    [SerializeField] private Transform snapPoint;
    [SerializeField] private float snapDistance = 0.5f;

    private bool slotFull;
    private GameObject currentCup;

    private void Update()
    {
        if (slotFull && currentCup == null)
        {
            slotFull = false;
            Debug.Log("Cup slot is empty.");
        }

        if (slotFull)
            return;

        GameObject[] cups = GameObject.FindGameObjectsWithTag("Cup");

        foreach (GameObject cup in cups)
        {
            DraggedTopping draggedCup = cup.GetComponent<DraggedTopping>();

            if (draggedCup == null || !draggedCup.isDragging)
                continue;

            float distance = Vector2.Distance(cup.transform.position, snapPoint.position);

            if (distance <= snapDistance)
            {
                SnapCup(cup, draggedCup);
                break;
            }
        }
    }

    private void SnapCup(GameObject cup, DraggedTopping draggedCup)
    {
        cup.transform.position = snapPoint.position;
        cup.transform.rotation = Quaternion.identity;

        cup.transform.SetParent(transform);

        draggedCup.isDragging = false;

        currentCup = cup;
        slotFull = true;

        Debug.Log("Cup Snapped!");
    }

    public void RemoveCup()
    {
        if (currentCup != null)
        {
            currentCup.transform.SetParent(null);
        }

        currentCup = null;
        slotFull = false;

        Debug.Log("Cup Removed!");
    }
}