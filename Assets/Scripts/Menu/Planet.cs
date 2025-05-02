using UnityEngine;

[CreateAssetMenu(fileName = "Planet", menuName = "Scriptable Objects/Planet")]
public class Planet : ScriptableObject
{
    public new string name;
    public float g_force;
}
