using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSample : MonoBehaviour
{


    private float H_Input;
    private float V_Input;
    public Transform Cam;
    private Vector3 Inputs;
    private Rigidbody Player_Rb;
    public float Player_Speed;
    public float Rotation_speed;





    // Start is called before the first frame update
    void Start()
    {
        Player_Rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        H_Input = Input.GetAxis("Horizontal");
        V_Input = Input.GetAxis("Vertical");
        Inputs = Direction();
        Player_Rb.MovePosition(transform.position + Inputs * Time.deltaTime * Player_Speed);
        Rotation();


    }

    Vector3 Direction()
    {
        Vector3 _direction = Vector3.zero;
        _direction += Cam.forward * V_Input;
        _direction += Cam.right * H_Input;
        if (_direction.magnitude > 1f)
            _direction.Normalize();
        _direction.y = 0;
        return _direction;

    }

    private void Rotation()
    {
        Quaternion Rotate = Quaternion.LookRotation(Inputs);
     transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotate, Time.deltaTime * Rotation_speed);

    }

}
