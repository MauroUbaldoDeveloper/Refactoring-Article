using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{

    float _Time;

    [SerializeField]
    bool _Right_Movementation;
    [SerializeField]
    bool _Left_Movementation;
    [SerializeField]
    bool _Up_Movementation;
    [SerializeField]
    bool _Down_Movementation;

    Health_System_Enemy _Health_System_Enemy_Script;
    Walk_Enemy _Walk_Enemy_Script;

    void Start()
    {

        _Left_Movementation = true;
        _Up_Movementation = true;

        _Health_System_Enemy_Script = GetComponent<Health_System_Enemy>();
        _Walk_Enemy_Script = GetComponent<Walk_Enemy>();

    }

    void Update()
    {

        if (_Right_Movementation == true && _Up_Movementation == true)
            _Walk_Enemy_Script.Right_Up_Diagonal();

        if (_Right_Movementation == true && _Down_Movementation == true)
            _Walk_Enemy_Script.Right_Down_Diagonal();

        if (_Left_Movementation == true && _Up_Movementation == true)
            _Walk_Enemy_Script.Left_Up_Diagonal();

        if (_Left_Movementation == true && _Down_Movementation == true)
            _Walk_Enemy_Script.Left_Down_Diagonal();

        Manage_Timer();

    }

    void Manage_Timer()
    {
        _Time += Time.deltaTime;

        if (_Time > 5)
        {
            _Time = 0;
            Change_Behavior();
        }

    }

    void Change_Behavior()
    {

        if (_Up_Movementation == true)
            Change_For_Down_Movementation();


        if (_Down_Movementation == true)
            Change_For_Up_Movementation();


        if (_Left_Movementation == true)
            Change_For_Right_Movementation();


        if (_Right_Movementation == true)
            Change_For_Left_Movementation();

    }

    void Change_For_Up_Movementation()
    {
        _Up_Movementation = true;
        _Down_Movementation = false;
    }

    void Change_For_Down_Movementation()
    {
        _Up_Movementation = false;
        _Down_Movementation = true;
    }

    void Change_For_Left_Movementation()
    {
        _Left_Movementation = true;
        _Right_Movementation = false;
    }

    void Change_For_Right_Movementation()
    {
        _Left_Movementation = false;
        _Right_Movementation = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Left_Limit"))
            Change_For_Right_Movementation();

        if (collision.gameObject.CompareTag("Right_Limit"))
            Change_For_Left_Movementation();

        if (collision.gameObject.CompareTag("Up_Limit"))
            Change_For_Down_Movementation();

        if (collision.gameObject.CompareTag("Down_Limit"))
            Change_For_Up_Movementation();

        if (collision.gameObject.CompareTag("Player"))
            _Health_System_Enemy_Script.Reduce_HP(15);

    }

}