using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float JumpForce;
    public float speed;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;

    private CharacterController _characterController;
 
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Передвижение
        _moveVector = Vector3.zero; //_moveVector обнуляется

        if (Input.GetKey(KeyCode.W)) //Проверяется зажата ли клавиша W
        {
            _moveVector += transform.forward; //Добавляется направление взгляда персонажа
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right; 
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }


        //Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -JumpForce;
        }
    }

    void FixedUpdate()
    {
        //Передвижение
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        //Падение и прыжок
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        //Прекращает накопление fallvelocy пока игрок стоит
        if (_characterController.isGrounded) 
        {
            _fallVelocity = 0;
        }
    }
}
