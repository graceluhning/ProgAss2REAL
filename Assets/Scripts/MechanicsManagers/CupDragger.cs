using UnityEngine;

public class CupDragger : MonoBehaviour
{
    private bool isDragging;
    private bool placedSuccessfully;

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

    public void SetPlaced()
    {
        placedSuccessfully = true;
    }
}