using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    private Dictionary<Type, IPLayerBehavior> _behaviorsMap;
    private IPLayerBehavior _behaviorCurrentState;


    private void Start() {
        InitBehaviors();
        SetBehaviorByDefault();
    }
    
    private void Update() {
        _behaviorCurrentState?.Update();
    }

    private void InitBehaviors() {
       _behaviorsMap = new Dictionary<Type, IPLayerBehavior> {
           [typeof(PlayerBehaviorIdle)] = new PlayerBehaviorIdle(),
           [typeof(PlayerBehaviorRun)] = new PlayerBehaviorRun(),
           [typeof(PlayerBehaviorJump)] = new PlayerBehaviorJump()
       };
    }

    private void SetBehavior(IPLayerBehavior newBehavior) {
        _behaviorCurrentState?.Exit();
        _behaviorCurrentState = newBehavior;
        _behaviorCurrentState.Enter();
    }

    private void SetBehaviorByDefault() {
        SetBehaviorIdle();
    }

    private IPLayerBehavior GetBehavior<T>() where T : IPLayerBehavior {
        var type = typeof(T);
        return _behaviorsMap[type];
    }

    public void SetBehaviorIdle() {
        var behavior = GetBehavior<PlayerBehaviorIdle>();
        SetBehavior(behavior);
    }
    
    public void SetBehaviorRun() {
        var behavior = GetBehavior<PlayerBehaviorRun>();
        SetBehavior(behavior);
    }
    
    public void SetBehaviorJump() {
        var behavior = GetBehavior<PlayerBehaviorJump>();
        SetBehavior(behavior);
    }
    
}
