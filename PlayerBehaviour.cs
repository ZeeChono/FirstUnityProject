using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // customized player attributes:
    [SerializeField] private float MoveSpeed = 10f;
    [SerializeField] private float RotateSpeed = 75f;
    [SerializeField] private float JumpVelocity = 5f;
    [SerializeField] private float DistanceToGround = 0.1f;
    [SerializeField] private float BulletSpeed = 100f;
    [SerializeField] private LayerMask GroundLayer; // layer mask selected in game to prevent infinite jumping of player
    [SerializeField] private GameObject Bullet;     // gameobject of bullets
    


    private float _vInput;          // W/S, up/down
    private float _hInput;          // A/D, left/right
    private bool _isJumping;        // boolean to determine when space is pressed
    private bool _isShooting;

    // ingame objects
    private CapsuleCollider _col;   
    private Rigidbody _rb;

    void Start()
    {
        // initialize the ingame objects
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        /* old player movement control using transform 
        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);   // rotate the player through y-axis
        */
        // update the conditions
        _isJumping = Input.GetKeyDown(KeyCode.Space) | _isJumping;
        _isShooting |= Input.GetMouseButtonDown(0);
    }

    void FixedUpdate()  // any physics and Rigidbody code always goes in here.
    {
        Vector3 rotation = Vector3.up * _hInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime); // moving object using rigidbody will apply correspondence force.

        _rb.MoveRotation(_rb.rotation * angleRot);

        if (_isJumping && IsGrounded())
        {
            Debug.Log("player collider y:" + _col.bounds.min.y);
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }
        _isJumping = false;
        if (_isShooting)
        {
            GameObject newBullet = Instantiate(Bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation);
            Debug.Log("Player's transform: " + this.transform.position);
            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();
            BulletRB.velocity = this.transform.forward * BulletSpeed;
        }      
        _isShooting = false;
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);

        // check if the player capsule is colliding with the ground layer
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, DistanceToGround, GroundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }
}
