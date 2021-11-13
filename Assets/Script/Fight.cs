using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    [SerializeField] private GameObject _fightEffect;

    private ParticleSystemRenderer _PSR;
    private ParticleSystem _PS;

    private void Start()
    {
        _PS = _fightEffect.GetComponent<ParticleSystem>();
        _PSR = _fightEffect.GetComponent<ParticleSystemRenderer>(); // получаем компонент системы частиц на объекте
    }

    private float InputX;

    private void Update()
    {
        InputX = Input.GetAxis("Horizontal"); // возвращает значение движения игрока по оси X

        if (InputX > 0) // если игрок движется вправо
            _PSR.flip = new Vector3(1, 0, 0); // поворачиваем текстуры частицы вправо
        else if (InputX < 0) // если игрок движется влево
            _PSR.flip = new Vector3(0, 0, 0); // поворачиваем текстуры частицы влево

        if (Input.GetMouseButtonDown(0)) // если игрок нажимает на кнопку атаки
        {
            _PS.Play();
        }
    }
}
