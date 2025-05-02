using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    [SerializeField] bool isOrbiting = false;

    private GameObject[] planets;
    private float G = 1000f;

    void Start()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");

        SetInitialVelocity();
    }

    void FixedUpdate()
    {
        Gravity();
    }

    void SetInitialVelocity()
    {
        foreach (GameObject planetA in planets)
        {
            foreach (GameObject planetB in planets)
            {
                if (!planetA.Equals(planetB))
                {
                    float m2 = planetB.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(planetA.transform.position, planetB.transform.position);

                    planetA.transform.LookAt(planetB.transform);

                    if (isOrbiting)
                    {
                        planetA.GetComponent<Rigidbody>().linearVelocity += planetA.transform.right * Mathf.Sqrt((G * m2) * ((2 / r) - (1 / (r * 1.5f))));
                    }
                    else
                    {
                        planetA.GetComponent<Rigidbody>().linearVelocity += planetA.transform.right * Mathf.Sqrt((G * m2) / r);
                    }
                }
            }
        }
    }

    void Gravity()
    {
        foreach (GameObject planetA in planets)
        {
            foreach (GameObject planetB in planets)
            {
                if (!planetA.Equals(planetB))
                {
                    float m1 = planetA.GetComponent<Rigidbody>().mass;
                    float m2 = planetB.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(planetA.transform.position, planetB.transform.position);

                    planetA.GetComponent<Rigidbody>().AddForce((planetB.transform.position - planetA.transform.position).normalized * (G * (m1 * m2) / (r * r)));
                }
            }
        }
    }
}
