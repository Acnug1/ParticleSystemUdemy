using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private GameObject _fireballPrefab;
    [SerializeField] private GameObject _spawnPoint;

    private void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 50)); // находим координаты курсора мыши внутри камеры и преобразуем их в мировые координаты
        transform.LookAt(mouse); // поворачиваем взгляд к позиции мыши

        if (Input.GetMouseButtonDown(0)) // если нажата левая кнопка мыши
        {
            Instantiate(_fireballPrefab, _spawnPoint.transform.position, transform.rotation); // создаем наш fireball в _spawnPoint.transform.position c поворотом, в зависимости от поворота сферы transform.rotation
        }
    }
}
