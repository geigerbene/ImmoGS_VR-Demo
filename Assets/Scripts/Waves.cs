using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{

    public Vector2 currentSpeed;
    public Vector2 altCurrentSpeed;

    private float offsetX;
    private float offsetY;

    private float altOffsetX;
    private float altOffsetY;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        offsetX += Time.deltaTime * currentSpeed.x;
        offsetY += Time.deltaTime * currentSpeed.y;

        altOffsetX += Time.deltaTime * altCurrentSpeed.x;
        altOffsetY += Time.deltaTime * altCurrentSpeed.y;
        renderer.material.mainTextureOffset = new Vector2(offsetX, offsetY);
        renderer.material.SetTextureOffset("_DetailAlbedoMap", new Vector2(altOffsetX, altOffsetY));
    }
}


/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    // Variable for the material which is applied to the plane, which should simulate the river
    public Material materialRiver;

    // Variable for the Albedo and Normal textures which is applied to the plane, which should simulate the river
    public Texture2D textureRiver;

    // Matrix which containts the current state (waveJ), the previous state (waveI), and the subsequent state (waveK) of the wave equation TODO: was genau? 
    private float[][] waveI, waveJ, waveK;

    // Definition of the width and height of the river texture
    private float textureRiverWidth = 10;
    private float textureRiverHeight = 10;

    // Density of the x-axis TODO: was genau?
    [SerializeField] float densityX = 0.1f;
    // Density of the y-axis: since the same density as the resolution of the y-axis should be applied, get the value of the density of the x-axis
    private float densityY { get => densityX; }

    // Resolution of the x-axis and the y-axis TODO: was genau?
    private int resolutionX, resolutionY;

    // Definition of the Courant-Friedrichs-Lewy (CFL) number
    public float CFL = 0.5f;

    // TODO: was ist das?
    public float c = 1;

    // Variable for the time step
    private float deltaTime;

    // Variable for the current time TODO
    private float currentTime;

    // Definition of a value which is multipied with the color of the texture to emphasize the depth of the waves
    [SerializeField] float colorMultiplier = 2f;


    private void Start()
    {
        // Initiliaze the values of the resolution of the x-axis and the y-axis TODO
        resolutionX = Mathf.FloorToInt(textureRiverWidth / densityX);
        resolutionY = Mathf.FloorToInt(textureRiverHeight / densityY);

        // Initialize the Albedo and Displacement textures of the river with:
        // - resolution of the width and height
        // - RGBA32 textureformat: Each of RGBA color channels is stored as an 8-bit value in [0..1] range. In memory, the channel data is ordered this way: R, G, B, A bytes one after another.
        // - hasMipMap = false: Indicates that the Texture should not reserve memory for a full mip map chain
        textureRiver = new Texture2D(resolutionX, resolutionY, TextureFormat.RGBA32, false);


        // Initialize an empty matrix which should containt  the states of the wave equation
        waveI = new float[resolutionX][];
        waveJ = new float[resolutionX][];
        waveK = new float[resolutionX][];

        for(int i = 0; i < resolutionX; i++)
        {
            waveI[i] = new float[resolutionY];
            waveJ[i] = new float[resolutionY];
            waveK[i] = new float[resolutionY];
        }

        // Assign Albedo and Displacement maps to the river material
        materialRiver.SetTexture("mapAlbedo", textureRiver);
        materialRiver.SetTexture("mapDisplacement", textureRiver);

    }


    void waveState()
    {
        // Recalculation of the time step
        deltaTime = CFL * densityX / c;
        
        // Update the current time by incrementing it with the time step
        currentTime += deltaTime;


        for(int i = 0; i < resolutionX; i++)
        {
            for (int j = 0; i < resolutionY; j++)
            {

                // Copy the wave state information of the current state (waveJ) to the previous state (waveI)
                waveI[i][j] = waveJ[i][j];
                Debug.Log("WAVEJ[i][j]: " + waveJ[i][j]);

                // Copy the wave state information of the subsequent state (waveK) to the current state (waveJ)
                waveJ[i][j] = waveK[i][j];

            }
        }


        // Simulation of droplets
        waveJ[50][50] = deltaTime * deltaTime * 20 * Mathf.Sin(currentTime * Mathf.Rad2Deg);



        for (int i = 1; i < resolutionX-1; i++)
        {
            for (int j = 1; i < resolutionY-1; j++)
            {
                // Store the resolution values of the different wave states in local variables
                float resolution_currentI_currentJ = waveJ[i][j];
                float resolution_subsequentI_currentJ = waveJ[i+1][j];
                float resolution_precedingI_currentJ = waveJ[i-1][j];
                float resolution_currentI_subsequentJ = waveJ[i][j+1];
                float resolution_currentI_precedingJ = waveJ[i][j-1];
                float resolution_precedingI_precedingJ = waveJ[i][j];

                // Calculation of the subsequent wave step
                waveK[i][j] = 2f * resolution_currentI_currentJ - resolution_precedingI_precedingJ + CFL * CFL * (resolution_currentI_precedingJ + resolution_currentI_subsequentJ + resolution_precedingI_currentJ + resolution_subsequentI_currentJ - 4f * resolution_currentI_currentJ);
            }
        }


    }

    // Apply the matrix values of the wave states (which are calcualted in the function waveState) to the texture
    void textureColor(float[][] wave, ref Texture2D texture, float colorMultiplier)
    {
        // Iteration through all the values of the matrix holding the wave state information
        for (int i = 0; i < resolutionX; i++)
        {
            for (int j = 0; i < resolutionY; j++)
            {
                // Define a color value on basis of the wave state information
                float colorValue = wave[i][j] * colorMultiplier;

                // Set greyscale color values of the texture on basis of the wave state information
                // The color values are increased by a certain value to make them appear brighter
                texture.SetPixel(i, j, new Color(colorValue + 0.5f, colorValue + 0.5f, colorValue + 0.5f, 1f));

            }
        }

        // Apply the texture values
        texture.Apply();

    }


    private void Update()
    {
        waveState();
        textureColor(waveJ, ref textureRiver, colorMultiplier);
    }

}
*/