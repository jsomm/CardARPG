using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class ManaPoint : MonoBehaviour
{
    public Slider Slider;
    // add mana type or color here?
    public float RechargeModifier = 1;
    public bool IsExpended => _currentVal < _maxVal;

    float _maxVal = 100;
    float _currentVal;

    WaitForSeconds _regenTick = new WaitForSeconds(0.1f);

    private void Start()
    {
        _currentVal = _maxVal;
        Slider.maxValue = _maxVal;
        Slider.value = _maxVal;
    }

    public void Consume()
    {
        _currentVal = 0;
        Slider.value = 0;
        StartCoroutine(RegenMana());
    }

    private IEnumerator RegenMana()
    {
        yield return new WaitForSeconds(1.5f);

        while(_currentVal < _maxVal)
        {
            _currentVal += _maxVal / (25 / RechargeModifier);
            Slider.value = _currentVal;
            yield return _regenTick;
        }
    }
}
