using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireable : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireEffect;
    [SerializeField] private float _fireDuration;

    private Coroutine _previousesTask;

    public void OnEnter()
    {
        _fireEffect.gameObject.SetActive(true); // если объект вошел в костер активируем поджег (эффект горения)
    }

    public void OnExit()
    {
        if (_previousesTask != null) // если предыдущая корутина не равна null
            StopCoroutine(_previousesTask); // останавливаем корутину

        _previousesTask = StartCoroutine(StopEffect(_fireDuration)); // запускаем корутину горения с продолжительностью _fireDuration и записываем её значение в _previousesTask
    }

    private IEnumerator StopEffect(float delay)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(delay); // задаем продолжительность горения объекта (задержка перед остановкой горения)
        yield return waitForSeconds; // ждем пока не закончится горение
        _fireEffect.gameObject.SetActive(false); // после чего отключаем его
    }
}
