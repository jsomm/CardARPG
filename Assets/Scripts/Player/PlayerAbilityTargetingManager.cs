using Mirror;

using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilityTargetingManager : NetworkBehaviour
{
    [SerializeField] LayerMask _groundMask;
    [SerializeField] Canvas _indicatorCanvas;
    [SerializeField] Image _skillshotImage, _rangeIndicatorImage;
    [SerializeField] Transform _aoeIndicatorTransform;

    public Transform AoeIndicatorTransform => _aoeIndicatorTransform;

    float _radiusOfRange;

    private void Start()
    {
        HideIndicators();

        // do these calculations in start, as they only need to be done one time
        Vector3[] rangeBoundaries = new Vector3[4];
        _rangeIndicatorImage.rectTransform.GetWorldCorners(rangeBoundaries);
        _radiusOfRange = Vector3.Distance(rangeBoundaries[0], rangeBoundaries[1]) / 2; // gets distance from center to outer edge of range image

    }

    private void Update()
    {
        if (!hasAuthority)
            return;

        Ray ray = Utilities.CameraRaycast();
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _groundMask))
        {
            #region Skillshot
            Vector3 mousePosition = new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
            Quaternion rotation = Quaternion.LookRotation(mousePosition - _indicatorCanvas.transform.position); // the target rotation to face the mouse position
            rotation.eulerAngles = new Vector3(0, rotation.eulerAngles.y, rotation.eulerAngles.z); // 0 out the x rotation so the indicator will not point "up" or "down"
            _indicatorCanvas.transform.rotation = Quaternion.Lerp(rotation, _indicatorCanvas.transform.rotation, 0f); // rotate the canvas to face the mouse position
            #endregion

            #region AOE
            Vector3 direction = (hitInfo.point - transform.position).normalized;
            float distance = Mathf.Clamp(Vector3.Distance(hitInfo.point, transform.position), 0, _radiusOfRange);
            Vector3 targetPosition = transform.position + direction * distance;

            _aoeIndicatorTransform.position = targetPosition;
            #endregion
        }
    }

    public void ShowIndicatorForCard(CardData card)
    {
        ScaleRange(card.RangeModifier);
        switch (card.IndicatorType)
        {
            case CardData.CardIndicatorType.Skillshot:
                ShowSkillshot(true);
                break;

            case CardData.CardIndicatorType.AOE:
                ShowAOE(true);
                ShowRange(true);
                break;
        }
    }

    public void HideIndicators()
    {
        ShowSkillshot(false);
        ShowAOE(false);
        ShowRange(false);
    }

    private void ScaleRange(float rangeModifier)
    {
        var currentScale = _indicatorCanvas.transform.localScale;
        _indicatorCanvas.transform.localScale = new Vector3(currentScale.x * rangeModifier, currentScale.y, currentScale.z * rangeModifier);
    }

    private void ShowSkillshot(bool show) => _skillshotImage.gameObject.SetActive(show);
    private void ShowAOE(bool show) => _aoeIndicatorTransform.gameObject.SetActive(show);
    private void ShowRange(bool show) => _rangeIndicatorImage.gameObject.SetActive(show);

}

