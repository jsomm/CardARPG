using UnityEngine;
public class CardCreator
{

    public GameObject CreateCardObject(CardData cardData, Transform parent)
    {
        // create blank card
        GameObject defaultCardPrefab = Resources.Load<GameObject>("Cards/_Card");
        GameObject newCard = GameObject.Instantiate(defaultCardPrefab, parent.position, Quaternion.identity, parent);

        // feed card data to the display fields
        CardController controller = newCard.GetComponent<CardController>();
        controller.CardData = cardData;
        controller.QuickFlip(); // this flips newly created card face down

        return newCard;
    }
}