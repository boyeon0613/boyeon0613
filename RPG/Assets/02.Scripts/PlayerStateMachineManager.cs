using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachineManager : MonoBehaviour
{
    public PlayerState playerState;

    [SerializeField] private Transform cam;
    Transform tr;
    private PlayerMove playerMove;
    private Animator animator;
    private PlayerAnimator playerAnimator;
    private PlayerStateMachine_Jump jumpMachine;
    private CharacterController characterController;

    

    private void Awake()
    {
        tr=GetComponent<Transform>();
        playerMove=GetComponent<PlayerMove>(); 
        animator=GetComponent<Animator>();
        playerAnimator = GetComponent<PlayerAnimator>();
        jumpMachine = GetComponent<PlayerStateMachine_Jump>();
    }

    private void Update()
    {
        //movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        animator.SetFloat("h", h);
        animator.SetFloat("v", v);

        tr.rotation = Quaternion.Euler(0,cam.eulerAngles.y,0);
        Vector3 move = cam.rotation * new Vector3(h, 0, v);
        playerMove.SetMove(move.x, move.z);

        //Jump
        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpMachine.IsExecuteOK())
            {
                jumpMachine.Execute();
            }
        }
        jumpMachine.Workflow();
    }

}
public enum PlayerState
{
    Idle,
    Move,
    Jump
}


