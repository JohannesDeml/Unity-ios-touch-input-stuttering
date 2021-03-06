﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrameCounter.cs" company="Supyrb">
//   Copyright (c) 2017 Supyrb. All rights reserved.
// </copyright>
// <author>
//   Johannes Deml
//   send@johannesdeml.com
// </author>
// --------------------------------------------------------------------------------------------------------------------

using System;
using UnityEngine.UI;

namespace Supyrb
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class FrameCounter : MonoBehaviour
	{
		public int ExpectedFramesPerSecond = 60;
		public int RecordTimeSeconds = 60;
		[SerializeField] private Text counterText = null;
		[SerializeField] private Text resultText = null;
		[SerializeField] private GameObject conterInfo = null;

		private bool active = false;
		private bool startRecording = false;
		private int startFrameCount = -1;
		private float startTime = -1f;
		private float exactDifference = 0f;
		private int frameDifference = 0;
		private int buttonInputCounter = 0;

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
			exactDifference = CalculateFrameDifference();
			var roundedDifference = Mathf.RoundToInt(exactDifference);
			if (roundedDifference != frameDifference)
			{
				frameDifference = roundedDifference;
				UpdateCounterText();
			}

			if (Time.realtimeSinceStartup - startTime >= RecordTimeSeconds)
			{
				FinishRecording();
			}
		}

		public void TriggerStartRecording()
		{
			startRecording = true;
		}

		public void IncrementButtonInputCounter()
		{
			buttonInputCounter++;
		}

		private void StartRecording()
		{
			active = true;
			startRecording = false;
			startFrameCount = Time.frameCount;
			startTime = Time.realtimeSinceStartup;
			frameDifference = 0;
			exactDifference = 0f;
			buttonInputCounter = 0;
			resultText.text = "";
			conterInfo.SetActive(false);
			UpdateCounterText();
		}

		private float CalculateFrameDifference()
		{
			var expectedPassedFrames = (Time.realtimeSinceStartup - startTime)* ExpectedFramesPerSecond;
			var passedFrames = Time.frameCount - startFrameCount;
			return expectedPassedFrames - passedFrames;
		}

		private void UpdateCounterText()
		{
			counterText.text = frameDifference.ToString();
		}

		private void FinishRecording()
		{
			counterText.text = "-";
			resultText.text = String.Format("Result\n " +
			                                "Frame difference: {0}\n" +
											"Duration: {1} seconds\n" +
											"Inputs: {2} touches", 
											exactDifference.ToString("0.000"), RecordTimeSeconds, buttonInputCounter);
			active = false;
			conterInfo.SetActive(true);
		}
	}
}