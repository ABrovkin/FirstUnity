﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class SphereBehavior : MonoBehaviour
    {
        public Text CountText;
        public float Speed;

        private Rigidbody _rigidbody;
        private int _ballsCollided;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _ballsCollided = 0;
            CountText.text = "Collides: " + _ballsCollided;
        }

        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.RightArrow))
                _rigidbody.AddForce(Speed, 0, 0);
            if (Input.GetKey(KeyCode.LeftArrow))
                _rigidbody.AddForce(-Speed, 0, 0);
            if (Input.GetKey(KeyCode.UpArrow))
                _rigidbody.AddForce(0, 0, Speed);
            if (Input.GetKey(KeyCode.DownArrow))
                _rigidbody.AddForce(0, 0, -Speed);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                _ballsCollided++;
                CountText.text = "Collides: " + _ballsCollided;
            }
        }
    }
}
