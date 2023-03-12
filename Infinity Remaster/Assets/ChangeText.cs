
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private UnityAction<float> valueUnityEvent;
    private Text text;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        text = GetComponent<Text>();
        valueUnityEvent += ChangeTextValue;
    }

    private void ChangeTextValue(float value)
    {
        text.text = value.ToString("#");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
