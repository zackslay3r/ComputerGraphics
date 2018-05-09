using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{

   

    public float scale = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;


    /// <summary>
    /// Testing
    /// </summary>
    public List<GameObject> cubes;
    public int amountOfCubes = 0;
    public float perlinNoise = 0f;
    public float refinement = 0f;
    public float multiplier = 0f;
    public int cubeCount = 0;
    public int width = 0;
    public int length = 0;

    public enum CubeAxis {X,Y,Z };
    public CubeAxis cubeaxis;
    private void Start()
    {
        
        offsetX = Random.Range(0f, 99999f);
        offsetY = Random.Range(0f, 99999f);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                perlinNoise = Mathf.PerlinNoise(i * refinement, j * refinement);
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.transform.position = new Vector3(i, perlinNoise * multiplier, j);
                cubes.Add(go);
                cubeCount++;
            }
        }


    }


    void Update()
    {
        //Renderer renderer = GetComponent<Renderer>();
        //renderer.material.mainTexture = GenerateTexture();
        offsetY += Time.deltaTime * 5.0f;

        foreach (GameObject cube in cubes)
        {
            cubeaxis = CubeAxis.X;
            float scaledX = ScaleACoord(cube.transform.position.x, cubeaxis);
            cubeaxis = CubeAxis.Z;
            float scaledZ = ScaleACoord(cube.transform.position.z , cubeaxis);

                    perlinNoise = Mathf.PerlinNoise(scaledX + Time.time, scaledZ + Time.time);
                    //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(cube.transform.position.x, perlinNoise * multiplier, cube.transform.position.z);
                    //cubes.Add(go);
                
        }

        


    }
    public float ScaleACoord(float coord, CubeAxis cubeax)
    {


        float scaledCoord = 0f;

        if (cubeax == CubeAxis.X)
        {
            scaledCoord = ConvertRange(0f, width, 0f, 1f, coord);
            return scaledCoord;
        }
        else if (cubeax == CubeAxis.Z)
        {
            scaledCoord = ConvertRange(0f, length, 0f, 1f, coord);
            return scaledCoord;
        }
        else
        {
            return scaledCoord;
        }
    //float scaledCoord, normalizedCoord;
    // first, normalize the coord.
    //normalizedCoord = (coord - 0.0f) / (1.0f - 0.0f);

    //scaledCoord = Mathf.Clamp(coord, 0.0f, 1.0f);

    

    
    }
  


    public float ConvertRange(float originalMin, float OriginalMax, float newMin, float newMax, float value)
    {
        float scale = (float)(newMax - newMin) / (OriginalMax - originalMin);
        return (float)(newMin + ((value - originalMin) * scale));
    }

}



    //    Texture2D GenerateTexture()
    //    {
    //        Texture2D texture = new Texture2D(width, height);

    //        // Generate a perlin noise map for the texture
    //        for (int x = 0; x < width; x++)
    //        {
    //            for (int y = 0; y < height; y++)
    //            {
    //                Color color = CalculateColor(x, y);
    //                texture.SetPixel(x, y, color);
    //            }
    //        }


    //        texture.Apply();
    //        return texture;
    //    }
    //    Color CalculateColor(int x, int y)
    //    {
    //        float xCoord = (float)x / width * scale + offsetX;
    //        float yCoord = (float)y / height * scale + offsetY;


    //        float sample = Mathf.PerlinNoise(xCoord, yCoord);
    //        return new Color(sample, sample, sample);
    //    }
    


