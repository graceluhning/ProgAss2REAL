using UnityEngine;

public class ToppingSpawner : MonoBehaviour
{
    [SerializeField] private GameObject toppingPrefab;
    [SerializeField] ToppingTypes toppingType;
    

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject topping = Instantiate(toppingPrefab, worldPos, Quaternion.identity);

        topping.GetComponent<DraggedTopping>().BeginDrag();
    }
    
    
}