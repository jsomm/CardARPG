using TMPro;

using UnityEngine;
using UnityEngine.UI;

class CardDetail : MonoBehaviour
{
    [SerializeField] TMP_Text Title;
    [SerializeField] TMP_Text DetailText;
    [SerializeField] TMP_Text Cost;
    [SerializeField] Image Image;

    public void DisplayCardDetailData(CardData cardData)
    {
        Title.text = cardData.Title;
        DetailText.text = cardData.DetailText.Replace("\\n", "\n");
        Cost.text = cardData.Cost.ToString();
        if (cardData.CardArt != null)
            Image.sprite = cardData.CardArt;
        else
            Image.gameObject.SetActive(false);
    }
}

