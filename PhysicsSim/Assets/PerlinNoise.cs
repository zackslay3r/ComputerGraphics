using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{

    public int width = 256;
    public int height = 256;

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

    private void Start()
    {
        offsetX = Random.Range(0f, 99999f);
        offsetY = Random.Range(0f, 99999f);

        for (int i = 0; i < amountOfCubes; i++)
        {
            for (int j = 0; j < amountOfCubes; j++)
            {
                perlinNoise = Mathf.PerlinNoise(i * refinement, j * refinement);
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.transform.position = new Vector3(i, perlinNoise * multiplier, j);
                cubes.Add(go);
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

            float scaledX = ScaleACoord(cube.transform.position.x);

                    perlinNoise = Mathf.PerlinNoise((cube.transform.position.x * refinement / 10), (cube.transform.position.z * refinement / 10));
                    //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(cube.transform.position.x, perlinNoise * multiplier, cube.transform.position.z);
                    //cubes.Add(go);
                
        }

            //for (int i = 0; i < amountOfCubes; i++)
            //{
            //    for (int j = 0; j < amountOfCubes; j++)
            //    {
            //       // perlinNoise = Mathf.PerlinNoise(i * refinement, j * refinement);
            //    }
            //}
            //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //cube.transform.position = new Vector3(cube.transform.position.x, perlinNoise * multiplier, cube.transform.position.x);





    }
    public float ScaleACoord(float coord)
    {
    float scaledCoord, normalizedCoord;
    // first, normalize the coord.
    //normalizedCoord = (coord - 0.0f) / (1.0f - 0.0f);

    scaledCoord = Mathf.Clamp(coord, 0.0f, 1.0f);

    

    return scaledCoord;
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
    


