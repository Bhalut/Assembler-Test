using UnityEngine;

public class SetSunLight : MonoBehaviour
{
    public Renderer water;
    public Renderer lightwall;
    public Transform worldProbe;

    bool lighton = false;

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.T))
        {
            lighton = !lighton;
        }


        if (lighton)
        {
            Color final = Color.white * Mathf.LinearToGammaSpace(5);
            lightwall.material.SetColor("_EmissionColor", final);
            DynamicGI.SetEmissive(lightwall, final);
        }
        else
        {
            Color final = Color.white * Mathf.LinearToGammaSpace(0);
            lightwall.material.SetColor("_EmissionColor", final);
            DynamicGI.SetEmissive(lightwall, final);
        }

        Vector3 tvec = Camera.main.transform.position;
        worldProbe.transform.position = tvec;

        water.material.mainTextureOffset = new Vector2(Time.time / 100, 0);
    }
}
