using System;
using UnityEngine;

#pragma warning disable 649
namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%

        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;

        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.

        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.

        private Transform m_CeilingCheck;   // A position marking where to check for ceilings

        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.

        private Ability[] abilities;

        private float move;
        private bool isCrouch;
        private bool isJump;

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();

            abilities = new Ability[]
            {
                new MovementAbility(this),
                new JumpingAbility(this),
                new CrouchingAbility(this)
            };
        }


        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);

            for (int i = 0; i < abilities.Length; i++)
            {
                abilities[i].AbilityFixedUpdate();
            }

            DrawDebugRay();
        }

        public void Move(float move, bool crouch, bool jump)
        {
            this.move = move;
            isCrouch = crouch;
            isJump = jump;
        }


        public void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        public float GetMove()
        {
            // Reduce the speed if crouching by the crouchSpeed multiplier
            return (isCrouch ? move * m_CrouchSpeed : move);
        }

        public bool IsGrounded()
        {
            return m_Grounded;
        }

        public bool IsAirControlerActive()
        {
            return m_AirControl;
        }

        public void SetSpeedValueToAnimator(float speed)
        {
            // The Speed animator parameter is set to the absolute value of the horizontal input.
            m_Anim.SetFloat("Speed", speed);
        }

        public void SetVelocity(Vector2 velocity)
        {
            // Move the character
            m_Rigidbody2D.velocity = velocity;
        }

        public float GetMaxSpeed()
        {
            return m_MaxSpeed;
        }

        public Vector2 GetVelocity()
        {
            return m_Rigidbody2D.velocity;
        }

        public bool GetIsFacingRight()
        {
            return m_FacingRight;
        }

        public bool IsJump()
        {
            return isJump;
        }

        public bool IsAnimatorGroundState()
        {
            return m_Anim.GetBool("Ground");
        }

        public void SetGrounded(bool isGrounded)
        {
            m_Grounded = isGrounded;
        }

        public void SetAnimatorGroundState(bool isGrounded)
        {
            m_Anim.SetBool("Ground", isGrounded);
        }

        public void AddJumpForce(float m_JumpForce)
        {
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }

        public bool IsCrouch()
        {
            return isCrouch;
        }

        public bool IsAnimatorStateCrouch()
        {
            return m_Anim.GetBool("Crouch");
        }

        public void SetCrouchStateOfAnimator()
        {
            // Set whether or not the character is crouching in the animator
            m_Anim.SetBool("Crouch", isCrouch);
        }

        public void SetIsCrouch(bool isCrouch)
        {
            this.isCrouch = isCrouch;
        }

        public Vector2 GetCeilingCheckTransformPosition()
        {
            return m_CeilingCheck.position;
        }

        public float GetCeilingRadius()
        {
            return k_CeilingRadius;
        }

        public LayerMask GetWhatIsGround()
        {
            return m_WhatIsGround;
        }

        private void DrawDebugRay()
        {
            var rayLenght = .5f;

            Debug.DrawLine(m_GroundCheck.position, m_GroundCheck.position - new Vector3(0, rayLenght, 0), Color.green);
            Debug.DrawLine(m_CeilingCheck.position, m_CeilingCheck.position + new Vector3(0, rayLenght, 0), Color.blue);
            
        }

        private void OnDrawGizmos()
        {
            if (m_CeilingCheck == null)
            {
                return;
            }

            if (m_GroundCheck == null)
            {
                return;
            }

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(m_GroundCheck.position, k_GroundedRadius);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(m_CeilingCheck.position, k_CeilingRadius);
        }
    }
}
