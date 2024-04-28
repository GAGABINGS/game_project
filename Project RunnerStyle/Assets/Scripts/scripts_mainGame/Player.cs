using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private CharacterController _characterController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _characterController.Move(Vector3.right * _speed * Input.GetAxis("Horizontal") * Time.deltaTime);
    }
}
