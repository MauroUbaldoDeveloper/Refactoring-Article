using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{

    bool _Right_Movementation = true;
    bool _Left_Movementation;

    Walk_Enemy _Walk_Left_And_Right_Side_Script;
    Health_System_Enemy _Health_System_Enemy_Script;

    void Start()
    {

        _Health_System_Enemy_Script = GetComponent<Health_System_Enemy>();
        _Walk_Left_And_Right_Side_Script = GetComponent<Walk_Enemy>();

    }

    void Update()
    {

        if (_Right_Movementation == true)
            _Walk_Left_And_Right_Side_Script.Right_Movementation();

        if (_Left_Movementation == true)
            _Walk_Left_And_Right_Side_Script.Left_Movementation();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Left_Limit"))
        {
            _Right_Movementation = true;
            _Left_Movementation = false;
        }

        if (collision.gameObject.CompareTag("Right_Limit"))
        {
            _Right_Movementation = false;
            _Left_Movementation = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            _Health_System_Enemy_Script.Reduce_HP(15);
        }

    }

}