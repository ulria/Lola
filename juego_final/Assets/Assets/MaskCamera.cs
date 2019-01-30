using UnityEngine;
using System.Collections;

public class MaskCamera : MonoBehaviour
{
	public AudioClip dramaSound;

    public Material EraserMaterial;
    private bool firstFrame;
    private Vector2? newHolePosition;

	/*private bool[] hotSpots = {false, false, false, false };
	private Vector2 hotSpot1 = new Vector2 (50f, 1150f);
	private Vector2 hotSpot2 = new Vector2 (1575f, 1150f);
	private Vector2 hotSpot3 = new Vector2 (50f, 275f);
	private Vector2 hotSpot4 = new Vector2 (1575f, 275f);
	private Vector2[] hotSpotsCoord = new Vector2[4];*/

	private int startX = 50, startY = 275, endX = 1575, endY = 1150;
	private int Height, Width;
	private int rows = 3, columns = 4;
	private int numberHotSpots;

	private bool[,] hotSpots;
	private Vector2[,] hotSpotsCoord; 

    private void CutHole(Vector2 imageSize, Vector2 imageLocalPosition)
    {
		float dist = 0;
		int indexRows = 0;
		int indexColumns = 0;
		int j;
		int k;
		//Debug.Log ("Start");
		for (k = 0; k < columns; k++) 
		{
			for (j = 0; j < rows; j++) {
				float tempDist = Mathf.Sqrt (Mathf.Pow (imageLocalPosition.x - hotSpotsCoord [k, j].x, 2) + Mathf.Pow (imageLocalPosition.y - hotSpotsCoord [k, j].y, 2));
				//Debug.Log ("j : " + j);
				//Debug.Log ("k : " + k);
				//Debug.Log ("hotSpotsCoord[" + k + ", " + j + "].x = " + hotSpotsCoord [k, j].x);
				//Debug.Log ("hotSpotsCoord[" + k + ", " + j + "].y = " + hotSpotsCoord [k, j].y);
				//Debug.Log ("imageLocalPosition.x = " + imageLocalPosition.x);
				//Debug.Log ("imageLocalPosition.y = " + imageLocalPosition.y);
				if (j == 0 && k == 0) {
					dist = tempDist;
					indexColumns = 0;
					indexRows = 0;
				} else {
					if (tempDist < dist) {
						dist = tempDist;
						indexColumns = k;
						indexRows = j;
					}
				}
			}
		}

		hotSpots [indexColumns, indexRows] = true;

		//Debug.Log (" HotSpot : (" + indexColumns + " , " + indexRows + ")");

        Rect textureRect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        Rect positionRect = new Rect(
			((imageLocalPosition.x - 0.5f * EraserMaterial.mainTexture.width*2) / imageSize.x),
			((imageLocalPosition.y - 0.5f * EraserMaterial.mainTexture.height*2) / imageSize.y),
			(EraserMaterial.mainTexture.width*2 / imageSize.x),
			(EraserMaterial.mainTexture.height*2 / imageSize.y)
		);
        GL.PushMatrix();
        GL.LoadOrtho();
        for (int i = 0; i < EraserMaterial.passCount; i++)
        {
            EraserMaterial.SetPass(i);
            GL.Begin(GL.QUADS);
			GL.Color(Color.red);
            GL.TexCoord2(textureRect.xMin, textureRect.yMax);
            GL.Vertex3(positionRect.xMin, positionRect.yMax, 0.0f);
            GL.TexCoord2(textureRect.xMax, textureRect.yMax);
			GL.Vertex3(positionRect.xMax, positionRect.yMax, 0.0f);
            GL.TexCoord2(textureRect.xMax, textureRect.yMin);
			GL.Vertex3(positionRect.xMax, positionRect.yMin, 0.0f);
            GL.TexCoord2(textureRect.xMin, textureRect.yMin);
			GL.Vertex3(positionRect.xMin, positionRect.yMin, 0.0f);
            GL.End();
        }
        GL.PopMatrix();
    }

    public void Start()
    {
		AudioSource audio = GetComponent<AudioSource>();

		//audio.Play();
		//WaitForSeconds(audio.clip.length);
		audio.clip = dramaSound;
		audio.Play();

		Height = endY - startY;
		Width = endX - startX;

		numberHotSpots = rows * columns;

		hotSpots = new bool[columns, rows];
		hotSpotsCoord = new Vector2[columns, rows];

        firstFrame = true;

		/*hotSpotsCoord [0] = hotSpot1;
		hotSpotsCoord [1] = hotSpot2;
		hotSpotsCoord [2] = hotSpot3;
		hotSpotsCoord [3] = hotSpot4;*/

		int distColumns = Width/(columns - 1), distRows = Height/(rows - 1);
		for(int i = 0; i < columns; i++)
		{
			for(int j = 0; j < rows; j++)
			{
				hotSpots[i, j] = false;
				hotSpotsCoord[i, j].x = startX + i*distColumns;
				hotSpotsCoord[i, j].y = startY + j*distRows;
			}
		}
    }

    public void Update()
    {
        newHolePosition = null;
        if (Input.GetMouseButton(0))
        {
            Vector2 v = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            Rect worldRect = new Rect(-8.0f, -6.0f, 16.0f, 12.0f);
            if (worldRect.Contains(v))
                newHolePosition = new Vector2(1600 * (v.x - worldRect.xMin) / worldRect.width, 1200 * (v.y - worldRect.yMin) / worldRect.height);
        }

		bool allHotSpotsTrue = true;
		for(int i = 0; i < columns && allHotSpotsTrue; i++)
		{
			for(int j = 0; j < rows && allHotSpotsTrue; j++)
			{
				if(!hotSpots[i, j])
				{
					allHotSpotsTrue = false;
				}
			}
		}
		if (allHotSpotsTrue) {
			GameObject.Find("GlobalCounter").GetComponent<GlobalCounterScript>().numberSuccessfulLevels++;
			GameObject.FindGameObjectWithTag ("Timer").GetComponent<timer> ().ChangeLevel ();
		}
    }

	public void OnPostRender()
	{
	    if (firstFrame)
	    {
	        firstFrame = false;
            GL.Clear(false, true, new Color(0.0f, 0.0f, 0.0f, 0.0f));
	    }
        if (newHolePosition != null)
            CutHole(new Vector2(1600.0f, 1200.0f), newHolePosition.Value);
	}
}
