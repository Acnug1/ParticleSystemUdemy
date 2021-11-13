using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Camera _shootingCamera;
    [SerializeField] private GameObject _effect;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // когда мы нажимаем левую кнопку мыши
        {
            var ray = _shootingCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)); // делаем рейкаст из центра камеры по координатам курсора мыши
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f)) // проверяем и записываем наши попадания на дистации в 100 ед в RaycastHit hit
            {
                var effect = Instantiate(_effect, hit.point, Quaternion.identity); // создаем на месте коллизии луча эффект попадания
                effect.transform.rotation = Quaternion.FromToRotation(effect.transform.forward, hit.normal) * effect.transform.rotation; // поворачиваем объект таким образом, чтобы он смотрел лицом по нормали поверхности, по котором мы попали и умножаем на наш екущий поворот, чтобы довернуть в нужную сторону
            }
        }
    }
}
