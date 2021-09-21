using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XNode;
public class NodeParser : MonoBehaviour
{
    public DialougeGraph graph;
    Coroutine _parser;
    Coroutine waitKey;
    public GameObject chatBoxObject;
    public Text speaker;
    public Text dialogue;
    public Image speakerImage;
    public KeyCode keyBinding;
    private bool drawing = false;
    public bool isComplete = true;
    private BaseNode nodeToBeRead;
    void Start()
    {

    }
    public void StartDialouge()
    {
        // set bool, set start node as current, start coroutine
        isComplete = false;

        foreach (BaseNode b in graph.nodes)
        {

            if (b.GetString() == "Start")
            {


                graph.current = b;
                break;
            }
        }
        _parser = StartCoroutine(ReadGraphFixed());

    }

    public BaseNode NextNode(string fieldName)
    {


        foreach (NodePort p in graph.current.Ports)
        {
            if (p.fieldName == fieldName)
            {
                return p.Connection.node as BaseNode;

            }
        }
        return null;



    }
    public bool CheckIfCurrentNodeIsEndNode(){
        return graph.current.IsEndNode();
    }

    public void DrawNode(BaseNode b)
    {
        drawing = true;
        string data = b.GetString();

        string[] dataParts = data.Split('/');

        speaker.text = dataParts[1];
        dialogue.text = dataParts[2];
        speakerImage.sprite = b.GetSprite();
        drawing = false;
    }


   
    private IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            if (Input.GetKeyDown(key))
            {
                done = true; // breaks the loop
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }

        // now this function returns
    }


    IEnumerator ReadGraphFixed()
    {
        // while not complete
        while (!isComplete)
        {
            // graph current is set to start prior so pointer moves forward
            graph.current = NextNode("exit");
            // Draw and wait untill drawing is complete
            DrawNode(graph.current);
            while (drawing)
            {
                yield return null;
            }
            //check if end of graph
            if(CheckIfCurrentNodeIsEndNode()){
                isComplete =true;
            }

            yield return waitForKeyPress(keyBinding); // wait for this ienum to return


        }
        Debug.Log("coroutine done");
        GameManager.Instance.UpdateGameState(GameState.FreeRoam);
    }

}