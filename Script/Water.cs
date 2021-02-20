using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    private void OnCollisionEnter2D(Collision2D collision) // при столкновении объектов
    {
        Physics2D.IgnoreCollision(collision.collider, collision.otherCollider); // игнорируем физическое взаимодействие объектов при столкновении

        var effect = Instantiate(_effect, collision.GetContact(0).point, Quaternion.identity); // в месте первого столкновения наших коллизий создаем эффект брызг
        effect.transform.rotation = Quaternion.FromToRotation(effect.transform.forward, collision.GetContact(0).normal * -1) * effect.transform.rotation; // поварачиваем наш эффект лицом в противоположную сторону от нормали и докручиваем его на свой поворот
    }
}
