// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstantMovementUpdate.cs" company="Supyrb">
//   Copyright (c) 2017 Supyrb. All rights reserved.
// </copyright>
// <author>
//   Johannes Deml
//   send@johannesdeml.com
// </author>
// --------------------------------------------------------------------------------------------------------------------

namespace Supyrb
{
    using UnityEngine;
    using System.Collections;
    
    public class ConstantMovementUpdate : MonoBehaviour 
    {
        [SerializeField] private Space space = Space.Self;
        [SerializeField, Tooltip("per second")] private Vector3 movementVector = Vector3.zero;
	    [SerializeField] private float jumpBackToStartTime;

	    private float lastJumpTime;
		private Vector3 startPosition;


		void Start()
		{
			if (space == Space.Self)
			{
				startPosition = transform.localPosition;
			}
			else
			{
				startPosition = transform.position;
			}
			lastJumpTime = Time.time;
		}

		void Update()
		{
			if (Time.time - lastJumpTime > jumpBackToStartTime)
			{
				ResetToStartPosition();
				return;
			}
			transform.Translate(movementVector* Time.smoothDeltaTime, space);
		}

		public void ResetToStartPosition()
		{
			if (space == Space.Self)
			{
				transform.localPosition = startPosition;
			}
			else
			{
				transform.position = startPosition;
			}
			lastJumpTime = Time.time;
		}
    }
}
