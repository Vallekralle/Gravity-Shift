using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] planets;
    [SerializeField] private TMP_Dropdown planetDropdown;
    [SerializeField] private Slider timeSlider, massSlider;
    [SerializeField] private Rigidbody sunRb;
    [SerializeField] private TMP_Text planetSpeedTxt, planetDistanceToSunTxt, speedTxt, massTxt;
    
    private GameObject currentPlanet;
    private float sunMass;

    private void Start()
    {
        currentPlanet = sunRb.gameObject;
        sunMass = sunRb.mass;

        timeSlider.onValueChanged.AddListener(delegate
        {
            ChangeTimeSpeed();
        });

        massSlider.onValueChanged.AddListener(delegate
        {
            ChangeSunMass();
        });

        planetDropdown.onValueChanged.AddListener(delegate
        {
            ChangePlanet();
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1; // Bug fix, time stops also in the menu
            SceneManager.LoadScene("Menu");
        }
        if (currentPlanet == null)
        {
            return;
        }

        transform.position = new Vector3(currentPlanet.transform.position.x, transform.position.y, currentPlanet.transform.position.z);
        planetSpeedTxt.text = $"{currentPlanet.GetComponent<Rigidbody>().linearVelocity.magnitude.ToString("0.00")} km/s";
        planetDistanceToSunTxt.text = $"{Vector3.Distance(sunRb.gameObject.transform.position, currentPlanet.transform.position).ToString("0.00")} mkm";
    }

    private void ChangeTimeSpeed()
    {
        Time.timeScale = timeSlider.value;
        speedTxt.text = $"x{Time.timeScale.ToString("0.00")}";
    }

    private void ChangeSunMass()
    {
        sunRb.mass = sunMass * massSlider.value;
        massTxt.text = $"x{massSlider.value.ToString("0.000")}";
    }

    private void ChangePlanet()
    {
        foreach(GameObject planet in planets)
        {
            if(planet.name.Equals(planetDropdown.options[planetDropdown.value].text))
            {
                currentPlanet = planet;
            }
        }
    }
}
