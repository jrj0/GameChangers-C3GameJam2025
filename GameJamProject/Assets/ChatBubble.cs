using UnityEngine;
using TMPro;

public class DeleteBubble : MonoBehaviour
{
    private float timer = 0;
    private const int LIVETIME = 2;
    private int lineWidth = 5;
    private int numberOfLines = 1;
    private const int MAXLINEWIDTH = 0;
    public Vector2 size;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Dialogue options
        string[] dialogues = {"small-test", "medium-testiojpewjfoiwjefjwea fjeowifjaoiejfiowe", "large-testj oifjow eao;jew;jf woeijfohweoughouwarghjwoiejfiohgo;awehoifj eowhgowrefj ;iewo;aijfgoi s;gilo ruwajfoiejoaw;oisdfjcldjksbnvdjkfnzxvcwalkejtuhto;faieljfakwjdnsj"};

        // Sets the text in the chatBubble prefab. chatBubble -> TextMeshPro
        TextMeshPro textObject = GetComponentInChildren<TextMeshPro>();
        string dialogue = dialogues[Random.Range(0, dialogues.Length)];
        textObject.text = dialogue;
        textObject.ForceMeshUpdate();
        size = textObject.GetRenderedValues(true);
        Vector2 padding = new Vector2(1, 1);
        SpriteRenderer background = GetComponentInChildren<SpriteRenderer>();
        background.size = size + padding;
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
