using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class CardCollectionViewManager : MonoBehaviour
{
    [SerializeField] protected CardCollectionBase ViewTarget;
    [SerializeField] protected Transform ScrollViewContentParent;
    [SerializeField] protected GameObject GFXWrapper;
    [SerializeField] protected bool ShuffleBeforeViewing = false;
    [SerializeField] protected TMP_Text TitleTextTMP;
    [SerializeField] protected string TitleText = "Cards in Deck";

    protected CardCollectionBase Deck;
    protected GameObject DeckViewCardPrefab;
    protected List<MenuCard> MenuCards = new List<MenuCard>();

    protected bool IsOpen = false;

    void Awake()
    {
        DeckViewCardPrefab = Resources.Load<GameObject>("Cards/_MenuCard");
        Deck = GameObject.Find("Player Deck").GetComponent<CardCollectionBase>();
    }

    private void Start()
    {
        TitleTextTMP.text = TitleText;
        CreateCardClonesFromDeck();
    }

    void CreateCardClonesFromDeck()
    {
        foreach (CardController card in Deck.Cards)
        {
            GameObject deckViewCard = Instantiate(DeckViewCardPrefab, ScrollViewContentParent);
            MenuCard newMenuCard = deckViewCard.GetComponent<MenuCard>();
            newMenuCard.CardData = card.CardData;
            newMenuCard.ParentCard = card.gameObject;
            MenuCards.Add(newMenuCard);

            deckViewCard.SetActive(false);
        }
    }

    public void ToggleView()
    {
        if (!IsOpen)
        {
            GFXWrapper.SetActive(true);
            ShowView();
        }
        else
        {
            GFXWrapper.SetActive(false);
            HideView();
        }

        IsOpen = !IsOpen;
    }

    void ShowView()
    {
        if (ShuffleBeforeViewing)
            ViewTarget.Shuffle();

        for (int i = 0; i < ViewTarget.Cards.Count; i++)
        {
            CardController menuCard = MenuCards.Find(x => x.ParentCard == ViewTarget.Cards[i].gameObject);
            if (menuCard != null)
            {
                menuCard.gameObject.SetActive(true);
                if (!ShuffleBeforeViewing)
                    menuCard.transform.SetSiblingIndex(i);
            }
        }

        foreach (CardController card in ViewTarget.Cards)
        {
            CardController menuCard = MenuCards.Find(x => x.ParentCard == card.gameObject);
            if (menuCard != null)
            {
                menuCard.gameObject.SetActive(true);
            }
        }
    }

    void HideView()
    {
        foreach (CardController card in MenuCards)
        {
            card.gameObject.SetActive(false);
        }
    }
}
