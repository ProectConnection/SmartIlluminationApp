using UnityEngine;
using System.Collections;

public class Fukidasi : MonoBehaviour {
    [SerializeField]
    TextMesh Com_Text;
    [SerializeField]
    SpriteRenderer Com_Sprite;
    [SerializeField]
    MeshRenderer Com_MeshRenderer;
    [SerializeField]
    string[] fukidasiText;

    bool visibleflg;
    float nowtime;
    [SerializeField]
    float limittime;

    

    public TextMesh com_text
    {
        get
        {
            return Com_Text;
        }
    }

    public SpriteRenderer com_sprite
    {
        get
        {
            return Com_Sprite;
        }
    }

	
	// Update is called once per frame
	void Update () {
        if(visibleflg == true)
        {
            nowtime += Time.deltaTime;
            if (nowtime >= limittime)
            {
                ChangeVisible(false);
            }
        }
	}

    public void ChangeText(int Textindex = 0)
    {
        if(Textindex >= fukidasiText.Length || Textindex < 0)
        {
            return;
        }
        Com_Text.text = fukidasiText[Textindex];
    }

    public void ChangeSpriteFlipX(bool flip = false)
    {
        Com_Sprite.flipX = flip;
    }

    public void ChangeVisible(bool visiblity)
    {
        visibleflg = visiblity;
        com_sprite.enabled = visiblity;
        Com_MeshRenderer.enabled = visiblity;
        if(visiblity == true)
        {
            nowtime = 0.0f;
        }
    }

    
}
