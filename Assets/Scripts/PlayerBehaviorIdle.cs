
using UnityEngine;

public class PlayerBehaviorIdle : IPLayerBehavior {
    
    public void Enter() {
        Debug.Log("Enter idle state");
    }

    public void Exit() {
        Debug.Log("Exit idle state");
    }

    public void Update() {
        Debug.Log("idle state");
    }
}