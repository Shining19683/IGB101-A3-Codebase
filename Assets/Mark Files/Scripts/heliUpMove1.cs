using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MarkSteele;

namespace MarkSteele
{
	/// <summary>
	/// Author: Mark Steele
	/// Description: This script demonstrates how to add an object in inspector and decides how fast it moves and how far it goes up and down continuously in Unity
	/// </summary>
	public class heliUpMove1 : MonoBehaviour
    {
        [SerializeField] [Range(0, 2)] float speed = 1f;
        [SerializeField] [Range(0, 5)] float range = 1f;
        private float orignalYpos;

        private void Start()
        {
            orignalYpos = this.transform.position.y;
        }

        private void Update()
        {
            moveUp();
        }
        void moveUp()
        {
            float yPos = Mathf.PingPong(Time.time * speed, 1) * range;
            transform.position = new Vector3(transform.position.x, yPos + orignalYpos, transform.position.z);
        }

       
    }
}


