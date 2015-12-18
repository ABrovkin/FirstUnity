using UnityEngine;

namespace Assets
{
    public class CameraBehavior : MonoBehaviour
    {
        public GameObject Player;

        private Vector3 _offset;
        private Rigidbody _playeRigidbody;

        void Start ()
        {
            _offset = transform.position - Player.transform.position;
            _playeRigidbody = Player.GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.RotateAround(Player.transform.position, Vector3.up, -5);
            else if (Input.GetKey(KeyCode.RightArrow))
                transform.RotateAround(Player.transform.position, Vector3.up, 5);

            _offset = transform.position - Player.transform.position;

            var forceValue = 0.0f;
            if (Input.GetKey(KeyCode.UpArrow))
                forceValue = -1500;
            else if (Input.GetKey(KeyCode.DownArrow))
                forceValue = 1500;

            if (Mathf.Abs(forceValue) < 0.0001f)
                return;
            
            var direction = new Vector3(_offset.x, 0, _offset.z);
            direction.Normalize();
            _playeRigidbody.AddForce(forceValue * direction);
        }

        void LateUpdate ()
        {
            transform.position = Player.transform.position + _offset;
        }
    }
}
