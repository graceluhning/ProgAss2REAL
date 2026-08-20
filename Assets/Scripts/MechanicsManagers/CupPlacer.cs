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
        }

        if (slotFull)
            return;

        GameObject[] cups = GameObject.FindGameObjectsWithTag("Cup");

        foreach (GameObject cup in cups)
        {
            DraggedTopping draggedCup = cup.GetComponent<DraggedTopping>();

            if (draggedCup == null || !draggedCup.isDragging)
                continue;

            float distance = Vector2.Distance(
                cup.transform.position,
                snapPoint.position
            );

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

        Rigidbody2D rb = cup.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.gravityScale = 0f;
            rb.mass = 0f;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        draggedCup.isDragging = false;

        currentCup = cup;
        slotFull = true;
    }

    public void RemoveCup()
    {
        if (currentCup != null)
        {
            currentCup.transform.SetParent(null);

            Rigidbody2D rb = currentCup.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = 1f;
                rb.mass = 1f;
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }

        currentCup = null;
        slotFull = false;
    }
}