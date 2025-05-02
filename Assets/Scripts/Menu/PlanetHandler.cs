using TMPro;
using UnityEngine;

public class PlanetHandler : MonoBehaviour
{
    #region SerializeField

    [SerializeField] private TMP_Text text;
    [SerializeField] private Planet planet;

    #endregion

    #region private Attributes

    private Vector3 initialScale, rotateAmount;

    #endregion

    #region private Methods

    private void Start()
    {
        initialScale = transform.localScale;
        rotateAmount = new Vector3(0, 5, 0);
    }

    private void Update()
    {
        transform.Rotate(rotateAmount * Time.deltaTime);
    }

    #endregion

    #region Getter and Setter

    public Vector3 getInitialScale()
    {
        return initialScale;
    }

    public Planet getPlanet()
    {
        return planet;
    }

    public void setTextColor(Color32 color)
    {
        text.color = color;
    }

    #endregion
}
