using UnityEngine;


public class PlayerBehaviorJump : IPLayerBehavior {
    
    public void Enter() {
        Debug.Log("Enter jump state");
    }

    public void Exit() {
        Debug.Log("Exit jump state");
    }

    public void Update() {
        Debug.Log("jump state");
    }
}