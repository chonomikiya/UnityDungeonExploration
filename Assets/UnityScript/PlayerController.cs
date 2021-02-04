// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [RequireComponent(typeof(Animator))]
// [RequireComponent(typeof(Rigidbody))]
// [RequireComponent(typeof(CapsuleCollider))]

// public class PlayerController : MonoBehaviour
// {
//     Rigidbody m_rigidbody;
//     Animator m_animator;
//     Transform m_Camera;
//     Vector3 m_CameraForward;
//     Vector3 m_Move;
//     float m_CapsuleHeight;
//     Vector3 m_CapsuleCenter;

//     // Start is called before the first frame update
//     void Start()
//     {
//         m_animator = GetComponent<Animator>();
//         m_rigidbody = GetComponent<Rigidbody>();
//         m_Camera = Camera.main.transform;
        
//         m_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        
//     }
//     public void Move(Vector3 move){
//         if (move.magnitude > 1f) move.Normalize();
//         move = transform.InverseTransformDirection(move);
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
//     private void FixedUpdate() {
//         float h = Input.GetAxis("Horizontal");
//         float v = Input.GetAxis("Vertical");
//         if(m_Camera != null){
//             //cameraから見た方向で操作
//             m_CameraForward = Vector3.Scale(m_Camera.forward, new Vector3(1, 0, 1)).normalized;
//             m_Move = v*m_CameraForward + h*m_Camera.right;
//         }else{
//             Debug.Log("err,no setting main camera");
//         }
//     }
//     void PlayerMove(Vector3 move){
        
//     }
// }
