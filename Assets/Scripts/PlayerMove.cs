using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator animator;

    public float speed;
    [SerializeField] bool directionCheck;

    public enum PLAYER_STATE
    {
        STOP,
        LEFT,
        RIGHT,
        UP,
        DOWN,
    }

    [SerializeField] PLAYER_STATE state;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        DirectionCheck();
        Move();
        StartCoroutine("PlayerAnim");
    }

    public void DirectionCheck()
    {
        if(directionCheck)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Move()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            directionCheck = false;
            state = PLAYER_STATE.LEFT;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            directionCheck = true;
            state = PLAYER_STATE.RIGHT;
            transform.Translate(Vector3.right * speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            state = PLAYER_STATE.UP;
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            state = PLAYER_STATE.DOWN;
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (!Input.anyKey)
        {
            state = PLAYER_STATE.STOP;
        }
    }

    public IEnumerator PlayerAnim()
    {
        switch(state)
        {
            case PLAYER_STATE.STOP:
                animator.SetBool("isMove", false);
                break;
            case PLAYER_STATE.LEFT:
                animator.SetBool("isMove", true);
                break;
            case PLAYER_STATE.RIGHT:
                animator.SetBool("isMove", true);
                break;
            case PLAYER_STATE.UP:
            case PLAYER_STATE.DOWN:
                animator.SetBool("isMove", true);
                break;
        }

        yield return 0;
    }
}
