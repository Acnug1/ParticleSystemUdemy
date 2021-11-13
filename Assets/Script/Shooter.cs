using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private ParticleSystem _shootEffect; // эффект выстрела

    private void Start()
    {
        _shootEffect = GetComponent<ParticleSystem>();
    }

    public void Emit()
    {
        _shootEffect.Emit(1); // излучает одну частицу при вызове метода
    }

    public void SetScale(float scale)
    {
        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z); // меняем локальный Scale шутера для того, чтобы стрелять в противоположную сторону
    }
}
