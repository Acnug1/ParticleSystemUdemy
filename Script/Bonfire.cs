using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Fireable>()) // если коллайдер, который вошел в триггер имеет компонент Fireable (который можно поджечь)
        {
            other.GetComponent<Fireable>().OnEnter(); // то вызываем у него метод OnEnter() (сообщаем что он вошел в костер)
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Fireable>()) // если коллайдер, который вышел из триггера имеет компонент Fireable
        {
            other.GetComponent<Fireable>().OnExit(); // то вызываем у него метод OnExit() (сообщаем что он вышел из костра)
        }
    }
}
