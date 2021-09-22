using UnityEngine;
using UniRx;
using UniRx.Triggers;


public class InputTest : MonoBehaviour {

    
    private Controls _controls;
    [SerializeField] private Player player;
    [SerializeField] private Rigidbody2D rb;

    private float _moveInput;
    private bool _isGround;
    private const float JumpForce = 10f;
    private const float MoveSpeed = 10f;


    private void Start() {
        this.ObserveEveryValueChanged(x => _moveInput)
            .Subscribe(x => {
                if (Mathf.Abs(x) > 0) {
                    player.SetBehaviorRun();
                } else {
                    player.SetBehaviorIdle();
                }
            });
        
        this.FixedUpdateAsObservable()
            .Subscribe(_ => Move());
    }
    
    private void Awake() {
        _controls = new Controls();
        _controls.Player.Jump.performed += context => Jump();
    }

    private void OnEnable() {
        _controls.Enable();
    }

    private void OnDisable() {
        _controls.Disable();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Ground ground = other.collider.GetComponent<Ground>();
        if (!ground && _moveInput > 0 ) return;
        _isGround = true;
        player.SetBehaviorIdle();
        Debug.Log("ground");
    }

    private void Move() {
        _moveInput = _controls.Player.Run.ReadValue<float>();
        rb.velocity = new Vector2(_moveInput * MoveSpeed, rb.velocity.y);
    }

    private void Jump() {
        if (!_isGround) return;
        rb.velocity = Vector2.up * JumpForce;
        player.SetBehaviorJump();
        _isGround = false;
    }
}
