using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayRotation : MonoBehaviour
{
    private void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 50)); // находим координаты курсора мыши внутри камеры и преобразуем их в мировые координаты
        transform.LookAt(mouse); // поворачиваем взгляд к позиции мыши
    }
}
