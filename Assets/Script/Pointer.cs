using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private GameObject _pointerPref;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // если нажата левая клавиша мыши
        {
            RaycastHit hit; // записывает информацию о попадании луча
            var ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)); // пускаем луч из центра камеры в позицию курсора мыши внутри области видимости этой камеры

            if (Physics.Raycast(ray, out hit)) // если мы куда-то попали
                Instantiate(_pointerPref, new Vector3(hit.point.x, hit.point.y + 1, hit.point.z), Quaternion.identity); // создаем префаб поинтера в позиции мирового пространства, где наш луч соприкасается с коллайдером 
                // (по y поднимаем на 1 ед, чтобы поинтер не появился внутри текстуры)
        }
    }
}
