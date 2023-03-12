using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Camera camera;


    public static event Action<Vector3> OnTap;
    public static event Action<Vector3> OnDoupleTap;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {

        ChechTouches();
    }

    private void ChechTouches()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchposition = camera.ScreenToWorldPoint(touch.position);
                OnTap?.Invoke(touchposition);
            }
            if (touch.tapCount > 1)
            {

                Vector3 doupleTapPosition = camera.ScreenToWorldPoint(touch.position);
                OnDoupleTap?.Invoke(doupleTapPosition);
            }
        }
    }
}




