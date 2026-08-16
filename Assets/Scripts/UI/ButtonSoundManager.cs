using UnityEngine;
using UnityEngine.EventSystems;

public class UIAudio : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public ShopUILogic shopLogic;

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(hoverSound);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.PlayOneShot(clickSound);
    }

}