using UnityEngine;
using TMPro;

public class DeleteBubble : MonoBehaviour
{
    private float timer = 0;
    private const int LIVETIME = 1;
    //private int lineWidth = 5;
    //private int numberOfLines = 1;
    private const int MAXLINEWIDTH = 0;
    public Vector2 size;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Dialogue options
        string[] dialogues = {"small-test", "medium-test afeiofjowjweifj", "large-testj oifjow eao;jew;jf woeijfohweoughouwarghjwoiejfiohgo;awehoifj eowhgowrefj ;iewo;aijfgoi s;gilo ruwajfoiejoaw;oisdfjcldjksbnvdjkfnzxvcwalkejtuhto;faieljfakwjdnsj"};

        // Sets the text in the chatBubble prefab. chatBubble -> TextMeshPro
        TextMeshPro textObject = GetComponentInChildren<TextMeshPro>();
        string dialogue = dialogues[Random.Range(0, dialogues.Length)];

        // Code heavily inspired by https://www.youtube.com/watch?v=K13WnNL1OYM
        textObject.text = dialogue;
        textObject.ForceMeshUpdate();
        size = textObject.GetRenderedValues(true);
        Vector2 padding = new Vector2(1, 1);
        SpriteRenderer background = GetComponentInChildren<SpriteRenderer>();
        background.size = size + padding;
        Vector3 backgroundSize = background.gameObject.transform.position;
        Vector3 offset = new Vector3(-1f * background.size[0], background.size[1], 0);
        gameObject.transform.position = backgroundSize + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < LIVETIME) {
            timer += Time.deltaTime;
        }
        else {
            Destroy(gameObject);
        }
    }
}
