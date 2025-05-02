using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlanetSelector : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private LayerMask layer;
    [SerializeField] private Button solarSystemBtn;
    [SerializeField] private float scaleTime, multiplicator;
    [SerializeField] private string planetScene;
    [SerializeField] private GameObject menuOverlay, creditsOverlay;
    [SerializeField] private TMP_Text creditsTxt;

    #endregion

    #region private Attributes

    private PlanetHandler[] planets;
    private PlanetHandler currentPlanet;
    private GameObject currentOverlay;
    private bool hasHit, showCredits;

    #endregion

    #region private Methods

    private void Start()
    {
        currentOverlay = menuOverlay;
        showCredits = false;

        // Get all available planets
        planets = GetComponentsInChildren<PlanetHandler>();

        solarSystemBtn.onClick.AddListener(delegate
        {
            OpenSolarSystem();
        });
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (showCredits)
        {
            SwitchOverlays(-30, 1);
        }
        else
        {
            SwitchOverlays(0, 0);
        }

        if (hasHit = Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            // Save the PlanetHandler from the selected planet
            currentPlanet = hit.transform.GetComponentInChildren<PlanetHandler>();

            // Change color of text under the planet
            currentPlanet.setTextColor(new Color32(255, 89, 15, 255));

            // Enlarge the selected planet
            hit.transform.localScale = Vector3.Lerp(hit.transform.localScale, currentPlanet.getInitialScale() * multiplicator, Time.deltaTime * scaleTime);

            // React to left mouse click
            if (Input.GetMouseButtonDown(0))
            {
                // Tell the GameManager about the selected planet
                GameMananger.instance.setPlanet(currentPlanet.getPlanet());
                // Load planet scene
                SceneManager.LoadScene(planetScene);
            }
        }

        resetAllPlanets();
    }

    private void resetAllPlanets()
    {
        // Iterate through every planet
        foreach (PlanetHandler planet in planets)
        {
            // Skip planet if it is already reseted
            if (planet.transform.localScale != planet.getInitialScale())
            {
                if (planet != currentPlanet || !hasHit)
                {
                    // Reset the text color
                    planet.setTextColor(Color.white);
                }

                // Shrink the planet
                planet.transform.localScale = Vector3.Lerp(planet.transform.localScale, planet.getInitialScale(), Time.deltaTime * scaleTime);
            }
        }
    }

    private void SwitchOverlays(int x, int a)
    {
        Vector3 newPos = new Vector3(x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        float alpha = Mathf.Lerp(creditsTxt.color.a, a, 0.00075f);

        Camera.main.transform.position = newPos = Vector3.Lerp(Camera.main.transform.position, newPos, 0.002f);
        creditsTxt.color = new Color(creditsTxt.color.r, creditsTxt.color.g, creditsTxt.color.b, alpha);
    }

    public void OpenSolarSystem()
    {
        SceneManager.LoadScene("SolarSystem");
    }

    public void OpenCreditsView(GameObject newOVerlay)
    {
        showCredits = !showCredits;
        currentOverlay.SetActive(false);
        newOVerlay.SetActive(true);
        currentOverlay = newOVerlay;
    }

    #endregion
}
