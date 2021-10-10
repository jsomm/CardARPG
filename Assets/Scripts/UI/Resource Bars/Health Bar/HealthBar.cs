using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    // add mana type or color here?
    public float RechargeModifier = 1;

    public bool IsExpended => _currentVal == 0;
    public bool IsRegen { get => _isRegen; }

    float _maxVal = 50;
    float _currentVal;
    bool _isRegen = false;

    WaitForSeconds _regenTick = new WaitForSeconds(0.1f);

    private void Start()
    {
        _currentVal = _maxVal;
        Slider.maxValue = _maxVal;
        Slider.value = _maxVal;
    }

    public float TakeDamage(float dmgAmount)
    {
        float dmgRemainder = 0;

        if(dmgAmount > _currentVal)
        {
            dmgRemainder = dmgAmount - _currentVal;
            _currentVal = 0;
            Slider.value = _currentVal;
            return dmgRemainder;
        }

        _currentVal -= dmgAmount;
        Slider.value = _currentVal;
        return dmgRemainder;
    }

    public void StartRegen() => StartCoroutine(Regen());
    public void StopRegen()
    {
        StopAllCoroutines();
        _isRegen = false;
    }

    IEnumerator Regen()
    {
        _isRegen = true;
        yield return new WaitForSeconds(5f);

        while (_currentVal < _maxVal)
        {
            _currentVal += _maxVal / (25 / RechargeModifier);
            Slider.value = _currentVal;
            yield return _regenTick;
        }
        _isRegen = false;
    }
}
