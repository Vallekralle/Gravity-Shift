using TMPro;
using UnityEngine;

public class Inspector : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private TMP_Text nameTxt;
    [SerializeField] private TMP_Text positionTxt;
    [SerializeField] private TMP_Text velocityTxt;
    [SerializeField] private TMP_Text rotationTxt;
    [SerializeField] private float updateTime;

    private ForceDependent forceDependentObj;
    private Vector3 lastPos;
    private float period;

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            setForceDependentObj(hit.transform.GetComponent<ForceDependent>());
        }

        if (forceDependentObj == null)
        {
            return;
        }

        if (period > updateTime)
        {
            nameTxt.text = "Name: " + forceDependentObj.getName();
            positionTxt.text = "Position: " + forceDependentObj.transform.position.ToString();

            if (lastPos != null)
            {
                // Differenz zwischen letzter Position und Neuer
                float posDistance = Vector3.Distance(forceDependentObj.transform.position, lastPos);
                velocityTxt.text = "Velocity (Geschwindigkeit): " + posDistance.ToString("0.00") + " m/s";

                // Berechnung der Rotationsgeschwindigkeit
                float angularSpeed = forceDependentObj.getRb().angularVelocity.magnitude * Mathf.Rad2Deg;
                rotationTxt.text = $"Rotation Speed: " + angularSpeed.ToString("0.00") + "°/s";
            }

            lastPos = forceDependentObj.transform.position;
            period = 0;
        }
        period += Time.deltaTime;
    }

    public void setForceDependentObj(ForceDependent forceDependentObj)
    {
        this.forceDependentObj = forceDependentObj;
    }
}
