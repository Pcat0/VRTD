using UnityEngine;
using System.Collections;

///<summary>
///This class allows Unity Messages to reatch class that dont inherent from MonoBehaviour 
///</summary>
[DisallowMultipleComponent]
public class UnityMessageExtender : MonoBehaviour {
    public delegate void Callback();
    public delegate void Callback<T>(T param1);
    public delegate void Callback<T, U>(T param1, U param2);

    /// <summary>
    /// Runs at void Update(){...}
    /// </summary>
    public static event Callback UpdateCall;
    /// <summary>
    /// Runs at void FixedUpdate(){...}
    /// </summary>
    public static event Callback FixedUpdateCall;
    /// <summary>
    /// Runs at void LateUpdate(){...}
    /// </summary>
    public static event Callback LateUpdateCall;


    private void Update() {
        if (UpdateCall != null)
            UpdateCall();
    }
    private void FixedUpdate() {
        if (FixedUpdateCall != null)
            FixedUpdateCall();
    }
    private void LateUpdate() {
        if (LateUpdateCall != null)
            LateUpdateCall();
    }
}
