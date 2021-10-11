using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System;

public class CardController : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] protected TMP_Text Title;
    [SerializeField] protected TMP_Text Description;
    [SerializeField] protected TMP_Text Cost;
    [SerializeField] protected Image Image;
    [SerializeField] protected GameObject CardBack;
    [SerializeField] protected GameObject CardFront;
    [SerializeField] protected GameObject CardHighlight;
    [SerializeField] private protected CardData _cardData;
    [SerializeField] private protected CardDragDrop _dragDrop;

    // properties
    public bool IsFaceUp => CardFront.activeSelf;
    public bool IsHighlighted => CardHighlight.activeSelf;
    public CardData CardData
    {
        get => _cardData ?? Resources.Load<CardData>("Cards/_Default");
        set
        {
            _cardData = value;
            DisplayCardData();
        }
    }
    public CardDragDrop DragDrop => _dragDrop;
    public CardUISlot CurrentSlot { get; set; }

    // local variables
    bool _cardFlipCoroutineAllowed = true;

    public void QuickFlip()
    {
        // use this to flip without animation
        CardBack.SetActive(!CardBack.activeSelf);
        CardFront.SetActive(!CardBack.activeSelf);
    }

    public void FlipCard()
    {
        if (_cardFlipCoroutineAllowed)
            StartCoroutine(RotateCard());
    }

    private IEnumerator RotateCard()
    {
        _cardFlipCoroutineAllowed = false;

        if (!IsFaceUp)
        {
            for (float i = 180f; i >= 0f; i -= 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    CardFront.SetActive(true);
                    CardBack.SetActive(false);
                }

                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            for (float i = -180f; i <= 0f; i += 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == -90f)
                {
                    CardFront.SetActive(false);
                    CardBack.SetActive(true);
                }

                yield return new WaitForSeconds(0.01f);
            }
        }

        _cardFlipCoroutineAllowed = true;
    }

    public void DisplayCardData()
    {
        Title.text = CardData.Title;
        Description.text = CardData.DescriptionText;
        Cost.text = CardData.Cost.ToString();
        if (CardData.CardArt != null)
            Image.sprite = CardData.CardArt;
        else
            Image.gameObject.SetActive(false);
    }

    public void ToggleCardHighlight() => CardHighlight.SetActive(!CardHighlight.activeSelf);
}
