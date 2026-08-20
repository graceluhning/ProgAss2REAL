using Unity.VisualScripting;
using UnityEngine;

public class ToppingSpawner : MonoBehaviour
{
    [SerializeField] private GameObject toppingPrefab;
    [SerializeField] ToppingTypes toppingType;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip scoop1;
    [SerializeField] AudioClip scoop2;
    [SerializeField] AudioClip scoop3;


    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject topping = Instantiate(toppingPrefab, worldPos, Quaternion.identity);

        topping.GetComponent<DraggedTopping>().BeginDrag();

        AudioClip[] scoopSounds = { scoop1, scoop2, scoop3 };
        AudioClip randomSound = scoopSounds[Random.Range(0, scoopSounds.Length)];

        audioSource.PlayOneShot(randomSound);


    }

}