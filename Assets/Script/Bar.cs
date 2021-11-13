using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private float Speed; // скорость изменения значения слайдера
    [SerializeField] private ParticleSystem FlameEffect;

    private Slider _slider;
    private float _value; // заносим сюда значение из Input Field

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _value = _slider.value; // _value принимает значение слайдера
    }

    private void Update()
    {
        if (_slider.value != _value) // если значение слайдера не равно _value
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _value, Speed * Time.deltaTime); // двигаем значение слайдера к значению _value со скоростью Speed
            if (_slider.value > _value) // если значение слайдера больше, чем значение _value (количество отображаемых жизней в данный момент больше, чем их на самом деле)
                FlameEffect.Play(); // воспроизводим эффект сгорания жизней
            else 
                FlameEffect.Stop(); // отключаем эффект
        }
        else
        {
            FlameEffect.Stop(); // отключаем эффект
        }
    }

    public void OnEndEdit(string str) // считываем введеное пользователем значение в InputField с помощью события OnEndEdit. Возвращает string
    {
        _value = float.Parse(str); // преобразуем значение строки str с типом string в тип float и записываем его в _value
    }
}
