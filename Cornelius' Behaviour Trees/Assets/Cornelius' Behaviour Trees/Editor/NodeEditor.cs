using UnityEngine;
using UnityEditor;
 
public class NodeEditor: EditorWindow {
    
    private Rect _window1;
    private Rect _window2;
   
    [MenuItem("Window/Node editor")]
    static void ShowEditor() {
        NodeEditor editor = GetWindow<NodeEditor>();
        editor.Init();
    }
   
    public void Init() {
        _window1 = new Rect(10, 10, 100, 100);  
        _window2 = new Rect(210, 210, 100, 100);
    }

    private void OnGUI() {
        DrawNodeCurve(_window1, _window2); // Here the curve is drawn under the windows
       
        BeginWindows();
        _window1 = GUI.Window(1, _window1, DrawNodeWindow, "Window 1");   // Updates the Rect's when these are dragged
        _window2 = GUI.Window(2, _window2, DrawNodeWindow, "Window 2");
        EndWindows();
    }

    private void DrawNodeWindow(int id) {
        GUI.DragWindow();
    }

    private void DrawNodeCurve(Rect start, Rect end) {
        Vector3 startPos = new Vector3(start.x + start.width, start.y + start.height / 2, 0);
        Vector3 endPos = new Vector3(end.x, end.y + end.height / 2, 0);
        Vector3 startTan = startPos + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Color shadowCol = new Color(0, 0, 0, 0.06f);
        for (int i = 0; i < 3; i++) // Draw a shadow
            Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, 
                null, (i + 1) * 5);
        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, 
            null, 1);
    }
}