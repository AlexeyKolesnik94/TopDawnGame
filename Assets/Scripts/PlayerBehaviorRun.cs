using UnityEngine;

public class PlayerBehaviorRun : IPLayerBehavior {
    
    public void Enter() {
        Debug.Log("Enter run state");
    }

    public void Exit() {
        Debug.Log("Exit run state");
    }

    public void Update() {
        Debug.Log("run state");
    }
}