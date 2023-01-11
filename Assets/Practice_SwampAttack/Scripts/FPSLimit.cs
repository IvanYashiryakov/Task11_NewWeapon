using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimit : MonoBehaviour
{
    [SerializeField] private int _fps;

    private void Awake()
    {
        Application.targetFrameRate = _fps;
    }
}
