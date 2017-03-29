// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinimalTouchInput.cs" company="Supyrb">
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
	using UnityEngine.Events;

    public class MinimalTouchInput : MonoBehaviour
    {
		[SerializeField] private UnityEvent onTouchStarted;

		// Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.touchCount == 0)
            {
                return;
            }
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
				onTouchStarted.Invoke();
            }
        }
    }
}
