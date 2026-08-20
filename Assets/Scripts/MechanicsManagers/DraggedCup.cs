using UnityEngine;


public class DraggedCup : MonoBehaviour
{
    public bool isDragging;


    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
    }


    public void BeginDrag()
    {
        isDragging = true;
        rb.gravityScale = 1f;
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


        // Mouse released
        if (Input.GetMouseButtonUp(0))
        {
            Drop();
        }
    }


    private void Drop()
    {
        isDragging = false;
        rb.gravityScale = 1f;


        Debug.Log("CUP DROPPED");
    }


    public void SetPlaced()
    {
        isDragging = false;
        rb.gravityScale = 0f;
    }
}