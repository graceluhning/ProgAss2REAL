using UnityEngine;
using TMPro;
using DG.Tweening;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    public void ShowMoney(int amount)
    {
        gameObject.SetActive(true);

        moneyText.text = "+$" + amount;

        transform.localScale = Vector3.zero;

        transform.DOScale(1f, 0.2f)
            .SetEase(Ease.OutBack);

        transform.DOLocalMoveY(
            transform.localPosition.y + 50f,
            0.8f
        ).SetEase(Ease.OutQuad);

        moneyText.DOFade(0f, 0.8f)
            .SetDelay(0.2f)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
                
                transform.localPosition = new Vector3(
                    transform.localPosition.x,
                    transform.localPosition.y - 50f,
                    transform.localPosition.z
                );

                moneyText.color = new Color(
                    moneyText.color.r,
                    moneyText.color.g,
                    moneyText.color.b,
                    1f
                );
            });
    }
}