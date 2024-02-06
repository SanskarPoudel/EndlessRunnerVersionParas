    using System;
    using System.Xml.Serialization;
    using UnityEngine;

    public class Movement : MonoBehaviour
    {
        Rigidbody2D rb;
        [SerializeField] float speed = 5f;
        [SerializeField] float jumpForce = 10f;
        private bool jumpAllowed;

        private Vector2 swipeStartPos, endTouchPos;

        private float minimumSwipeDistance = 10f;
        private bool swiping;

        private void Awake()
        {

        }

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                swipeStartPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (swiping)
                {
                    Vector2 swipeEndPos = Input.mousePosition;
                    float swipeDistance = (swipeEndPos - swipeStartPos).magnitude;

                    if (swipeDistance > minimumSwipeDistance)
                    {
                        Jump();
                    }
                }

                swiping = false;
            }
            MoveForward();
        }

        private void Jump()
        {
            // Your jump logic here
            Debug.Log("Jump!");
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }

        private void MoveForward()
        {
            rb.AddForce(speed * Vector2.right, ForceMode2D.Force);
        }

    }
