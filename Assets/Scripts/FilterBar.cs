using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterBar : MonoBehaviour
{	
	public Slider slider;
	
	void Start()
	{
		slider = GetComponent<Slider>();
		InitialFilter();
	}

		public void  InitialFilter()
	{
		SetMaxFilter(GameManagement.manager.filterMax);
		SetFilter(GameManagement.manager.filterLife);
	}
	
	public void SetFilter (float filterLife)
	{
		slider.value = filterLife;
	}
	
	public void SetMaxFilter (float filterMax)
	{
		slider.maxValue = filterMax;

	}
	
	public float GetFilter()
	{
		return slider.value;
	}
}