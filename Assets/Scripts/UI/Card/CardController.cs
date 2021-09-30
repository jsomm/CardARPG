using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System;

public class CardController : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] TMP_Text _title;
    [SerializeField] TMP_Text _description;
    [SerializeField] TMP_Text _cost;
    [SerializeField] Image _image;
    [SerializeField] GameObject _cardBack;
    [SerializeField] GameObject _cardFront;
    [SerializeField] CardData _cardData;
    [SerializeField] CardDragDrop _dragDrop;

    // properties
    public bool IsFaceUp => _cardFront.activeSelf;
    public CardData CardData
    {
        get => _cardData ?? Resources.Load<CardData>("Cards/_Default");
        set
        {
            _cardData = value;
            DisplayCardData();
        }
    }
    public CardDragDrop DragDrop { get => _dragDrop; }
    public CardUISlot CurrentSlot { get; set; }

    // local variables
    bool _cardFlipCoroutineAllowed = true;

    public void QuickFlip()
    {
        // use this to flip without animation
        _cardBack.SetActive(!_cardBack.activeSelf);
        _cardFront.SetActive(!_cardBack.activeSelf);
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
                    _cardFront.SetActive(true);
                    _cardBack.SetActive(false);
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
                    _cardFront.SetActive(false);
                    _cardBack.SetActive(true);
                }

                yield return new WaitForSeconds(0.01f);
            }
        }

        _cardFlipCoroutineAllowed = true;
    }

    public void DisplayCardData()
    {
        _title.text = CardData.Title;
        _description.text = CardData.DescriptionText;
        _cost.text = CardData.Cost.ToString();
        //if (CardData.CardArt != null)
        //    _image.sprite = CardData.CardArt;
        //else
            _image.gameObject.SetActive(false);
    }
}
