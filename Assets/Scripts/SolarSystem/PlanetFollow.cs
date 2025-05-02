using UnityEngine;
using TMPro;

public class PlanetFollow : MonoBehaviour
{
    [SerializeField] private TMP_Text planetNameTxt;
    
    public float offsetZ = 20f;

    private void Update()
    {
        planetNameTxt.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + offsetZ);
    }
}
