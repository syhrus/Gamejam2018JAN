using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPermanence : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
