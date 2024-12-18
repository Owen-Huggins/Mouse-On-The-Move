namespace Gaskellgames.CameraController
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Cinemachine;

    public class IntroDollyCam : MonoBehaviour
    {
        private float rotationSpeed = 1f;
        public Transform roach1;
        public Transform cheese;
        public Transform roach2;
        public Transform mouseTrap;
        public Transform mouse;
        private Vector3 targetPosition;
        private CinemachineDollyCart cdc;
   
        void Start ()
        {
            cdc = transform.GetComponent<CinemachineDollyCart>();
            targetPosition = cheese.position;
        }

        
        void Update()
        {
            if (Input.anyKeyDown) Destroy(this.gameObject);
            
            float dist = cdc.m_Position;
            if (dist >= 8.5f)
            {
                targetPosition = mouse.position;
            } else if (dist >= 7.3f)
            {
                targetPosition = mouseTrap.position;
            } else if (dist >= 5f)
            {
                targetPosition = roach2.position;
            } else if (dist >= 2.5f)
            {
                targetPosition = roach1.position;
            } else 
            {
                targetPosition = cheese.position;
            }

            float step = rotationSpeed * Time.deltaTime;
            Vector3 targetDirection = targetPosition - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0f);
            transform.rotation = Quaternion.LookRotation(newDirection); 

            if (dist >= 12.8) Destroy(this.gameObject);


        }
    }
}
