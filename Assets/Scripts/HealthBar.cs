using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{	
	public Slider slider;
	
	void Start()
	{
		slider = GetComponent<Slider>();
		InitialHealth();
	}

	public void  InitialHealth()
	{
		SetMaxHealth(GameManagement.manager.playerMaxHealth);
		SetHealth(GameManagement.manager.playerHealth);
	}

	
	
	public void SetHealth (float health)
	{
		slider.value = health;
	}
	
	public void SetMaxHealth (float maxHealth)
	{
		slider.maxValue = maxHealth;

	}
	
	public float GetHealth()
	{
		return slider.value;
	}
}