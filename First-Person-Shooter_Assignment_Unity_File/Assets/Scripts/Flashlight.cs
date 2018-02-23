using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour
{

    public KeyCode flashlightToggleKey = KeyCode.F;
    public AudioClip toggleSound;
    public float batteryLifeInSeconds = 60f;

    public float maxIntensity = 1f;

    private float batteryLife;
    private bool isActive;

    private AudioSource myAudioSource;
    private Light myLight;

    Light testLight;
    public float minWaitTime;
    public float maxWaitTime;

    void Start ()
    {
        myAudioSource = GetComponent<AudioSource>();
        myLight = GetComponent<Light>();
        batteryLife = myLight.intensity;
    }


    void Update()
    {
        if (Input.GetKeyDown(flashlightToggleKey))
        {
            isActive = !isActive;

            if (myAudioSource != null && toggleSound != null)
                myAudioSource.PlayOneShot(toggleSound);
        }

        if (isActive)
        {
            myLight.enabled = true;
            myLight.intensity -= batteryLife / batteryLifeInSeconds * Time.deltaTime;
        }
        else
        {
            myLight.enabled = false;
        }
    }

    public void AddBatteryLife(float _batteryPower)
        {
                myLight.intensity += _batteryPower;
            if (myLight.intensity > maxIntensity)
                myLight.intensity = maxIntensity;
        }

}
