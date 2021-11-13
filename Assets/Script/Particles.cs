using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private ParticleSystemRenderer PSR;

    private void Start()
    {
        PSR = GetComponent<ParticleSystemRenderer>(); // получаем компонент системы частиц на объекте
    }

    private float InputX;

    private void Update()
    {
        InputX = Input.GetAxis("Horizontal"); // возвращает значение движения игрока по оси X

        if (InputX > 0) // если игрок движется вправо
            PSR.flip = new Vector3(1, 0, 0); // поворачиваем текстуры частицы вправо
        else if (InputX < 0) // если игрок движется влево
            PSR.flip = new Vector3(0, 0, 0); // поворачиваем текстуры частицы влево
    }
}
