using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private ParticleSystem _healEffect; // эффект хила игрока компаньоном

    private void Start()
    {
        _healEffect = GetComponent<ParticleSystem>();
    }

    public void Emit()
    {
        _healEffect.Play(); // включаем эффект хила
    }

    public void SetScale(float scale)
    {
        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z); // меняем локальный Scale хила для того, чтобы хилить в противоположную сторону
    }
}
