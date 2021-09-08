using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Jump Value")]
    public Vector3 m_right_jump_value;
    [Space]
    public Animator m_chiken_anim;
    [Space]
    public int m_platform_gen_count=3;
    [Space]
    public bool m_input;
    [Header("Scriptable Object Events")]
    public GameEvent m_platform_genrator;
    public GameEvent m_game_over;


    [Header("Script holder")]
    public ScriptRefrenceHolder m_script_ref;
    public Valueholder m_value_holder;

    private int m_screenwidth;

    public float m_dead_check_pos;

    private bool m_grounded;
    private bool m_right;

    private Rigidbody m_rb;

    private Vector3 m_center_pos;
    private Vector3 m_temp_rotation;

    private void Awake()
    {
        m_script_ref.m_player_Controller = GetComponent<PlayerController>();
        m_value_holder.m_player_position = Vector3.zero;
    }

    private void Start()
    {

        m_screenwidth = Screen.width / 2;

        m_rb = gameObject.GetComponent<Rigidbody>();

        //Rotate Acording To InitialDirection
        m_temp_rotation = transform.eulerAngles;


        if (m_script_ref.m_platform_controller.m_initial_direction == 0)
        {
            m_temp_rotation.y = 0f;
        }
        else
        {
            m_temp_rotation.y = -90f;
        }

        transform.eulerAngles = m_temp_rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if (!m_input)
        {
            return;
        }

        //Check For Fall
        if ( transform.position.y<m_dead_check_pos)
        {
            Debug.Log("Dead");
            m_input = false;
            m_game_over._Raise();
        }

        if (!m_grounded)
        {
            return;
        }

#if UNITY_EDITOR
        _EditorControl();
#endif


#if UNITY_ANDROID || UNITY_IOS
        _TouchControl();
#endif

    }

    void _EditorControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > m_screenwidth)
            {
                //Debug.Log("Right");
                m_right = true;
                _RotateObject();
                _Jump();
                return;
            }
            if (Input.mousePosition.x < m_screenwidth)
            {
                 m_right = false;
                _RotateObject();
                _Jump();
                return;
            }

        }
    }

    void _TouchControl()
    {
        if (Input.touchCount>0)
        {
            if (Input.GetTouch(0).position.x > m_screenwidth)
            {
                //Debug.Log("Right");
                m_right = true;
                _RotateObject();
                _Jump();
                return;
            }
            if (Input.GetTouch(0).position.x < m_screenwidth)
            {
                m_right = false;
                _RotateObject();
                _Jump();
                return;
            }
        }

    }

    void _RotateObject()
    {
        if (m_right)
        {
            m_temp_rotation.y = 0f;
            transform.eulerAngles = m_temp_rotation;
        }
        else
        {
            m_temp_rotation.y = -90f;
            transform.eulerAngles = m_temp_rotation;
        }
    }

    void _Jump()
    {
        //Genrate Next Platform
        m_platform_gen_count++;

        if (m_platform_gen_count==5)
        {
            m_platform_gen_count = 0;
            m_platform_genrator._Raise();
        }

        m_value_holder.m_player_position = transform.position;

        m_grounded = false;
        m_chiken_anim.SetBool("Head", true);

        if (m_right)
        {
          
            m_rb.velocity = new Vector3(m_right_jump_value.x, Mathf.Sqrt(-2.0f * Physics.gravity.y * m_right_jump_value.y),0f);
        }
        else
        {
            m_rb.velocity = new Vector3(0, Mathf.Sqrt(-2.0f * Physics.gravity.y * m_right_jump_value.y),m_right_jump_value.z);
        }
    }

    private void OnCollisionEnter(Collision m_col)
    {

        if (m_col.collider.CompareTag("Platform"))
        {
            //Debug.Log(m_col.transform.position.y);
            m_grounded = true;
            m_chiken_anim.SetBool("Head", false);
            m_rb.angularVelocity = Vector3.zero;
            m_rb.velocity = Vector3.zero;

            m_center_pos = m_col.transform.position;
            m_center_pos.y += 0.5f;
            transform.position = m_center_pos;
            m_dead_check_pos = transform.position.y-1f;
            return;
        }

        if (m_col.collider.CompareTag("Dead"))
        {
            //Debug.Log(m_col.transform.position.y);
            m_grounded = true;
            m_chiken_anim.SetBool("Head", false);
            m_rb.angularVelocity = Vector3.zero;
            m_rb.velocity = Vector3.zero;

            m_center_pos = m_col.transform.position;
            m_center_pos.y += 0.5f;
            transform.position = m_center_pos;

            m_input = false;
            m_game_over._Raise();
            return;
        }


    }
}

