using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    [SerializeField] private TMP_Text gravityDirTxt;
    private ForceDependent[] forceDependentObjs;

    private void Start()
    {
        forceDependentObjs = GetComponentsInChildren<ForceDependent>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) // ESCAPE
        {
            // Pressing escape redirectes the player to the menu page
            Time.timeScale = 1; // bug fixing, if the player leaves the room while freezing time
            SceneManager.LoadScene("Menu");
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)) // UP
        {
            GravityHandler.setGravity(new Vector3(0, GravityHandler.getGForce(), 0));
            setGravityDir("Oben");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) // DOWN
        {
            GravityHandler.setGravity(new Vector3(0, -GravityHandler.getGForce(), 0));
            setGravityDir("Unten");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) // LEFT
        {
            GravityHandler.setGravity(new Vector3(GravityHandler.getGForce(), 0, 0));
            setGravityDir("Links");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) // RIGHT
        {
            GravityHandler.setGravity(new Vector3(-GravityHandler.getGForce(), 0, 0));
            setGravityDir("Rechts");
        }
        else if (Input.GetKeyDown(KeyCode.W)) // FRONT
        {
            GravityHandler.setGravity(new Vector3(0, 0, -GravityHandler.getGForce()));
            setGravityDir("Vorne");
        }
        else if (Input.GetKeyDown(KeyCode.S)) // BACK
        {
            GravityHandler.setGravity(new Vector3(0, 0, GravityHandler.getGForce()));
            setGravityDir("Hinten");
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) // SHIFT
        {
            // If the player wants to freeze the time, press shift
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            resetForceDependentObj();
        }
    }

    private void resetForceDependentObj()
    {
        Time.timeScale = 1;
        GravityHandler.setGravity(new Vector3(0, -GravityHandler.getGForce(), 0));

        foreach(ForceDependent obj in forceDependentObjs)
        {
            obj.getRigidbody().linearVelocity = Vector3.zero;
            obj.getRigidbody().angularVelocity = Vector3.zero;
            obj.getRigidbody().position = obj.getStartPosition();
            obj.getRigidbody().rotation = obj.getStartRotation();
        }
    }

    private void setGravityDir(string direction)
    {
        gravityDirTxt.text = "Gravitationsrichtung: " + direction;
    }
}
