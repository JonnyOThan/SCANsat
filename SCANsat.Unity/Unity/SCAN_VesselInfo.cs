﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SCANsat.Unity.Interfaces;

namespace SCANsat.Unity.Unity
{
	public class SCAN_VesselInfo : MonoBehaviour
	{
		[SerializeField]
		private TextHandler m_VesselText = null;

		private Guid _id;
		private string vesselName;
		private ISCAN_MainMap mapInterface;

		public Guid ID
		{
			get { return _id; }
		}

		public void SetVessel(Guid id, string name, ISCAN_MainMap map)
		{
			if (m_VesselText == null || map == null)
				return;

			_id = id;
			vesselName = !string.IsNullOrEmpty(name) && name.Length > 26 ? name.Substring(0, 26) : name;
			mapInterface = map;

			m_VesselText.OnTextUpdate.Invoke(name);
		}

		public void UpdateText(int i, string value)
		{
			if (m_VesselText == null)
				return;

			m_VesselText.OnTextUpdate.Invoke(string.Format("[{0}] {1}: {2}", i, vesselName, value));
		}

	}
}
