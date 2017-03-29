// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleMobileSettings.cs" company="Supyrb">
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
    
    public class SimpleMobileSettings : MonoBehaviour 
    {
		[SerializeField] private bool neverTurnOffScreen = true;
		[SerializeField, Range(-1, 60)] private int targetFrameRate = 60;

		void Start()
		{
			ApplyValues();
		}

		private void ApplyValues()
		{
			if(neverTurnOffScreen)
			{
				Screen.sleepTimeout = SleepTimeout.NeverSleep;
			}
			Application.targetFrameRate = targetFrameRate;
		}

#if UNITY_EDITOR
		void OnValidate()
		{
			ApplyValues();
		}
#endif
    }
}