using UnityEngine;

[System.Serializable] // используем сериализацию для считывания данных из файла или программы (если значения не заданы в инспекторе)

public class MoveToMouse : MonoBehaviour
{
    [SerializeField] private float _speed = 8.0f;
    [SerializeField] private float _distanceFromCamera = 5.0f;

    void Update()
    {
        Vector3 MousePosition = Input.mousePosition; // находим локальные координаты позиции мыши в области видимости камеры
        MousePosition.z = _distanceFromCamera; // позицию по оси z задаем как дистанцию от камеры до объекта

        Vector3 MouseScreenToWorld = Camera.main.ScreenToWorldPoint(MousePosition); // преобразуем локальные координаты курсора мыши в мировые

        Vector3 Position = Vector3.Lerp(transform.position, MouseScreenToWorld, _speed * Time.deltaTime); // находим координату перемещения объекта за курсором мыши в каждом кадре

        transform.position = Position; // перемещаем пустой gameObject с составной системой частиц в позицию курсора мыши в реальном времени
    }
}