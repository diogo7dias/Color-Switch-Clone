using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
 {
	public float jumpForce = 7f;
	public Rigidbody2D rb;
	public string currentColor;
	public SpriteRenderer sr;
	public Color colorCyan;
	public Color colorYellow;
	public Color colorPink;
	public Color colorMagenta;

	void Start()
	{
		SetRandomColor();
	}

	void Update ()
	{
		if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
			rb.velocity = Vector2.up * jumpForce;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "ColorChanger")
		{
			SetRandomColor();
			Destroy(other.gameObject);
			return;
		}
		if(other.tag != currentColor)
		{
			Debug.Log("GAME OVER");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	void SetRandomColor()
	{
		int index = Random.Range(0,4);

		switch(index)
		{
			case 0:
				currentColor = "Cyan";
				sr.color = colorCyan;
			break;
			case 1:
				currentColor = "Yellow";
				sr.color = colorYellow;
			break;
			case 2:
				currentColor = "Pink";
				sr.color = colorPink;
			break;
			case 3:
				currentColor = "Magenta";
				sr.color = colorMagenta;
			break;
		}
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	}
}
