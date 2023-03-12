using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timePerLevel;
    public float actualTime;

    public event Action<float> ValueChange;

    private void OnEnable()
    {
        GameManager.instance.OnLevelChange += ResetTimer;
        GameManager.instance.OnSpawn += RunTimer;
    }

    private void ResetTimer()
    {
        actualTime = timePerLevel;
    }

    private void RunTimer()
    {
        StartCoroutine(TimerCoroutine(EndGame));
    }

    private void EndGame()
    {
        GameManager.instance.GameOver();
    }

    private IEnumerator TimerCoroutine(Action callback)
    {
        actualTime = timePerLevel;
        ValueChange?.Invoke(actualTime);
        while (actualTime > 0)
        {
            ValueChange?.Invoke(actualTime);
            actualTime -= Time.deltaTime;
            yield return null;
        }

        callback();
    }
}
