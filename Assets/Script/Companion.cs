using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    [SerializeField] private Bandit _player; // информация об игроке, к которому привязан компаньон
    [SerializeField] private float _returnSpeed; // скорость, с которой компаньон будет возвращаться на свое место
    [SerializeField] private Shooter _shooter1; // мы знаем о двух шутерах
    [SerializeField] private Shooter _shooter2;
    [SerializeField] private Heal _heal; // мы знаем о компоненте Heal

    private int _shootCount; // количество сделанных выстрелов
    private Transform _companionPlace; // место для размещения компаньона

    private void Start()
    {
        _companionPlace = _player.CompanionPlace; // берем место для размещения компаньона у игрока
    }

    private void Update()
    {
        FollowingCharacter(); // перемещает компаньона за игроком

        if (Input.GetMouseButtonDown(0)) // если игрок нажал на левую кнопку мыши
        {
            if (transform.position.x < _player.transform.position.x) // если компаньон находится левее, чем игрок
            {
                _shooter1.SetScale(1); // стреляем вправо
                _shooter2.SetScale(1);
            }
            else
            {
                _shooter1.SetScale(-1); // стреляем влево
                _shooter2.SetScale(-1);
            }

            if (_shootCount % 2 == 0) // если выстрел четный
            {
                _shooter1.Emit(); // стреляем из верхнего орудия
                _shootCount++; // увеличиваем количество выстрелов на единицу
            }
            else
            {
                _shooter2.Emit(); // стреляем из нижнего орудия
                _shootCount = 0; // обнуляем количество выстрелов
            }
        }

        if (Input.GetKeyDown(KeyCode.H)) // при нажатии на клавишу H
        {
            if (transform.position.x < _player.transform.position.x) // если компаньон находится левее, чем игрок
            {
                _heal.SetScale(-1); // хилим вправо
            }
            else
            {
                _heal.SetScale(1); // хилим влево
            }

            _heal.Emit();
        }
    }

    private void FollowingCharacter()
    {
        if (transform.position != _companionPlace.position)
        {
            transform.position = Vector3.Lerp(transform.position, _companionPlace.position, _returnSpeed * Time.deltaTime);
        }
    }
}
