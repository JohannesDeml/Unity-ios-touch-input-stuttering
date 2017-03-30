// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrameCounter.cs" company="Supyrb">
//   Copyright (c) 2017 Supyrb. All rights reserved.
// </copyright>
// <author>
//   Johannes Deml
//   send@johannesdeml.com
// </author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine.UI;

namespace Supyrb
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class FrameCounter : MonoBehaviour
	{
		[SerializeField] private Text uiText;
		private bool active;
		private bool startRecording;
		private int startFrameCount;
		private float startTime;
		private int frameDifference;

		void Update()
		{
			if (startRecording)
			{
				StartRecording();
				return;
			}

			if (!active)
			{
				return;
			}
			var newDifference = CalculateFrameDifference();
			if (newDifference == frameDifference)
			{
				return;
			}
			frameDifference = newDifference;
			UpdateText();
		}

		public void TriggerStartRecording()
		{
			startRecording = true;
		}

		private void StartRecording()
		{
			active = true;
			startRecording = false;
			startFrameCount = Time.frameCount;
			startTime = Time.realtimeSinceStartup;
			frameDifference = 0;
			UpdateText();
		}

		private int CalculateFrameDifference()
		{
			var expectedPassedFrames = Mathf.RoundToInt((Time.realtimeSinceStartup - startTime)*60f);
			var passedFrames = Time.frameCount - startFrameCount;
			return expectedPassedFrames - passedFrames;
		}

		private void UpdateText()
		{
			uiText.text = frameDifference.ToString();
		}

		
#if UNITY_EDITOR
		void Reset()
		{
			if (uiText == null)
			{
				uiText = GetComponent<Text>();
			}
		}
#endif
	}
}