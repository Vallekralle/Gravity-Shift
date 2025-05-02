using TMPro;
using UnityEngine;

public class GravityHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text planetNameTxt;

    private static float gForce;

    private void Start()
    {
        // Get the gForce from the selected planete
        gForce = GameMananger.instance.getPlanet().g_force;
        // Direct the gravity direction at the bottom
        setGravity(new Vector3(0, -Mathf.Abs(gForce), 0));
        planetNameTxt.text = $"{GameMananger.instance.getPlanet().name} ~ {gForce}g";
    }

    public static float getGForce()
    {
        return gForce;
    }

    public static void setGravity(Vector3 gravity)
    {
        // Run the game in standard playtime
        Time.timeScale = 1;
        // Set the new gravity
        Physics.gravity = gravity;
    }

    
}
