using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SIDE { Left, Mid, Right }

public class CharacterPlayer : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed = 5;
    public SIDE m_Side = SIDE.Mid;
    float NewXPos = 0f;
    public bool SwipeLeft, SwipeRight, SwipeUp, SwipeDown;
    [HideInInspector]
    public float XValue;
    private CharacterController m_char;
    private Animator m_Animator;
    private Rigidbody rd;
    private Animator anim;
    public float JumpPower = 7f;
    private float y;
    private float x;
    public bool InJump;
    public bool InRoll;
    public float SpeedDodge;
    bool is_ground = false;
    public float force = 6;



    void Start()
    {
        rd = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();


        m_char = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
        transform.position = Vector3.zero;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Ground")
        {
            is_ground = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Ground")
        {
            is_ground = false;
        }
    }

    void Update()
    {
        SwipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        SwipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        if (SwipeLeft)
        {
            if (m_Side == SIDE.Mid)
            {
                NewXPos = -XValue;
                m_Side = SIDE.Left;
                m_Animator.Play("dodgeLeft");
            }
            else if (m_Side == SIDE.Right)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
                m_Animator.Play("dodgeLeft");
            }
        }
        else if (SwipeRight)
        {
            if (m_Side == SIDE.Mid)
            {
                NewXPos = XValue;
                m_Side = SIDE.Right;
                m_Animator.Play("dodgeRight");
            }
            else if (m_Side == SIDE.Left)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
                m_Animator.Play("dodgeRight");
            }
        }

        x = Mathf.Lerp(x, NewXPos, Time.deltaTime * SpeedDodge);
        Vector3 moveVectore = new Vector3(x - transform.position.x, y * Time.deltaTime, 0);
        m_char.Move(moveVectore);
        m_char.Move((NewXPos - transform.position.x) * Vector3.right);
        Jump();
    }

    public void Jump()
    {
        if (m_char.isGrounded)
        {
            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Falling"))
            {
                m_Animator.Play("Landing");
                InJump = false;
            }

            if (SwipeUp)
            {
                y = JumpPower;
                m_Animator.CrossFadeInFixedTime("Jump", 0.1f);
                InJump = true;
            }
        }
        else
        {
            y -= JumpPower * 2 * Time.deltaTime;
            if (m_char.velocity.y < -0.1f)
                m_Animator.Play("Falling");
        }
    }
}