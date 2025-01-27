using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogManager : MonoBehaviour
{
    // Variables publicas
    public float maxFogDensity, maxFogTime, maxSkyboxFogOpacity;
    public bool fogState;

    // Variables privadas
    private Material m_Material;
    private float opacity, originalFogDensity;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializacion de variables
        m_Material = RenderSettings.skybox;
        opacity = 0f;
        originalFogDensity = RenderSettings.fogDensity;
    }

    // Update is called once per frame
    void Update()
    {
        ModifyFog();
    }

    // Funcion para regresar la niebla a los valores originales instantaneamente (Realizar al salir del nivel)
    public void SetOriginalValues()
    {
        m_Material.SetFloat("_Opacity", 0f);
        RenderSettings.fogDensity = originalFogDensity;
    }

    // Activar o desactivar la niebla
    public void SetFogState(bool _state)
    {
        fogState = _state;
    }

    // Funcion para aumentar o disminuir la niebla dependiendo de su estado
    public void ModifyFog()
    {
        // Si la niebla está activada la aumentamos a sus valores limite
        if (fogState)
        {
            if (opacity < 1f)
            {
                m_Material.SetFloat("_Opacity", Mathf.Lerp(0f, maxSkyboxFogOpacity, opacity));
                RenderSettings.fogDensity = Mathf.Lerp(originalFogDensity, maxFogDensity, opacity);

                opacity += (1f / maxFogTime) * Time.deltaTime;
            }
        }
        // Si esta desactivada la regresamos a los valores originales
        else
        {
            if (opacity > 0f)
            {
                m_Material.SetFloat("_Opacity", Mathf.Lerp(0f, maxSkyboxFogOpacity, opacity));
                RenderSettings.fogDensity = Mathf.Lerp(originalFogDensity, maxFogDensity, opacity);

                opacity -= (1f / maxFogTime) * Time.deltaTime;
            }
        }
    }
}
