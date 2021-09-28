using UnityEngine;
public class CardCreator
{

    public GameObject CreateCardObject(GameObject prefab, Transform parent)
    {
        // create blank card
        GameObject newCard = GameObject.Instantiate(prefab, parent.position, Quaternion.identity, parent);

        // feed card data to the display fields
        CardController controller = newCard.GetComponent<CardController>();
        controller.DisplayCardData();
        controller.QuickFlip(); // this flips newly created card face down

        return newCard;
    }
}