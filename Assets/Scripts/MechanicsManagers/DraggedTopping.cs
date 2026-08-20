using UnityEngine;

public class DraggedTopping : MonoBehaviour
{
    public bool isDragging;
    private bool placedSuccessfully;

    public int toppingPrice;
    public ToppingTypes toppingType;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void BeginDrag()
    {
        isDragging = true;

        // If this cup is currently inside a CupPlacer,
        // remove it immediately.
        CupPlacer placer = GetComponentInParent<CupPlacer>();

        if (placer != null)
        {
            placer.RemoveCup();
        }

        transform.SetParent(null);

        // Restore physics
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1f;
            rb.mass = 1f;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    private void OnMouseDown()
    {
        BeginDrag();
    }

    private void Update()
    {
        if (!isDragging)
            return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = new Vector3(
            worldPos.x,
            worldPos.y,
            transform.position.z
        );

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    public void SetPlaced()
    {
        placedSuccessfully = true;
        isDragging = false;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.gravityScale = 0f;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}