
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void OnEnable()
    {
        InputManager.OnTap += ChangeToGameScene;
    }

    private void OnDisable()
    {
        InputManager.OnTap -= ChangeToGameScene;
    }

    private void ChangeToGameScene(Vector3 obj)
    {
        SceneManager.LoadScene("Game");
    }
}

