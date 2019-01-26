using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public Texture2D map;

	public ColourtoPrefab[] colourMappings;
	
	// Use this for initialization
	void Start () 
	{
		GenerateLevel();
	}

	void GenerateLevel()
	{
		for (int x = 0; x < map.width; x++)
		{
			for (int y = 0; y < map.height; y++)
			{
				GenerateTile(x,y);
			}
		}
	}

	void GenerateTile(int x, int y)
	{
		Color pixelColour = map.GetPixel(x,y);

		// If the pixel is of a transparent colour.
		if(pixelColour.a == 0)
		{
			return;
		}

		foreach (ColourtoPrefab colourMapping in colourMappings)
		{
			if (colourMapping.colour.Equals(pixelColour))
			{
				Vector2 position = new Vector2(x,y);
				Instantiate(colourMapping.prefab, position, Quaternion.identity, transform);
			}
		}
		
		// Debug.Log(pixelColour);

		// Debug.Log("Hello there!");
	}
}
