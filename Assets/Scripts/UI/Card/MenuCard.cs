using UnityEngine;
using UnityEngine.EventSystems;

public class MenuCard : CardController, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject ParentCard;
    [SerializeField] CardDetail _cardDetail;

    Transform _viewSlot;

    private void Start()
    {
        _viewSlot = GameObject.Find("Card Detail Slot").transform;
        _cardDetail.DisplayCardDetailData(CardData);
        _cardDetail.transform.SetParent(_viewSlot);
        _cardDetail.transform.localScale = Vector3.one;
    }

    public void OnPointerEnter(PointerEventData eventData) => _cardDetail.gameObject.SetActive(true);
    public void OnPointerExit(PointerEventData eventData) => _cardDetail.gameObject.SetActive(false);
}

