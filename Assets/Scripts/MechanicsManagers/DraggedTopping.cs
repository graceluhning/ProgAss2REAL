using UnityEngine;

public class DraggedTopping : MonoBehaviour
{
    public bool isDragging;
    private bool placedSuccessfully;
    
    public int toppingPrice;
    public ToppingTypes toppingType;
    
    public void BeginDrag()
    {
        isDragging = true;
    }

    private void Update()
    {
        if (!isDragging)
            return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = new Vector3(worldPos.x, worldPos.y, transform.position.z);

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;

            if (!placedSuccessfully)
            {
                Destroy(gameObject);
            }
        }
    }
    
    private void OnMouseDown()
    {
        isDragging = true;

        CupPlacer placer = GetComponentInParent<CupPlacer>();

        if (placer != null)
        {
            placer.RemoveCup();
        }

        transform.SetParent(null);
    }

    public void SetPlaced()
    {
        DraggedTopping topping = gameObject.GetComponent<DraggedTopping>();

        toppingPrice += topping.toppingPrice;
        
        placedSuccessfully = true;
    }
}