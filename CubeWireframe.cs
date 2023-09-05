/* ------------------------------------------
Use GL to draw cube wireframe.
Color gradually changes from c1 to c2, along the z axis (from z to zz). 
*/ ------------------------------------------

public class CubeWireframe : MonoBehaviour
{
    public bool showWireframe = false;
    
    public Color c1 = Color.cyan;
    private Color c2 = new Color(1, 1, 1, 0.1f);
    
    public  float z = 0f;
    public  float zz = -1f;
    
    static Material lineMaterial;
    static void CreateLineMaterial(){
            if (!lineMaterial){
                // Unity has a built-in shader that is useful for drawing simple colored things.
                Shader shader = Shader.Find("Hidden/Internal-Colored");
                lineMaterial = new Material(shader);
                lineMaterial.hideFlags = HideFlags.HideAndDontSave;
                // Turn on alpha blending
                lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                // Turn backface culling off
                lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
                // Turn off depth writes
                lineMaterial.SetInt("_ZWrite", 0);
            }
        }
    
    void OnRenderObject(){
        if (showWireframe){
                CreateLineMaterial();
                lineMaterial.SetPass(0);
                GL.PushMatrix();//渲染入栈///////////////////////////////////////////////////////////
                GL.MultMatrix(transform.localToWorldMatrix);
                //下面的Vertex3会被视为local space里的坐标，然后变换到world space
    
                GL.Begin(GL.LINES);// Z方向渐变 --------------------------------------------------
                GL.Color(c1);//new Color(1, 0, 0)
                GL.Vertex3(0.5f, 0.5f, z);
                GL.Vertex3(0.5f, -0.5f, z);
                GL.Vertex3(0.5f, -0.5f, z);
                GL.Vertex3(-0.5f, -0.5f, z);
                GL.Vertex3(-0.5f, -0.5f, z);
                GL.Vertex3(-0.5f, 0.5f, z);
                GL.Vertex3(-0.5f, 0.5f, z);
                GL.Vertex3(0.5f, 0.5f, z);
                //--------------------------------
                GL.Vertex3(0.5f, 0.5f, z);
                GL.Color(c2);
                GL.Vertex3(0.5f, 0.5f, zz);
                GL.Color(c1);
                GL.Vertex3(0.5f, -0.5f, z);
                GL.Color(c2);
                GL.Vertex3(0.5f, -0.5f, zz);
                GL.Color(c1);
                GL.Vertex3(-0.5f, -0.5f, z);
                GL.Color(c2);
                GL.Vertex3(-0.5f, -0.5f, zz);
                GL.Color(c1);
                GL.Vertex3(-0.5f, 0.5f, z);
                GL.Color(c2);
                GL.Vertex3(-0.5f, 0.5f, zz);
                //--------------------------------
                GL.Vertex3(0.5f, 0.5f, zz);
                GL.Vertex3(0.5f, -0.5f, zz);
                GL.Vertex3(0.5f, -0.5f, zz);
                GL.Vertex3(-0.5f, -0.5f, zz);
                GL.Vertex3(-0.5f, -0.5f, zz);
                GL.Vertex3(-0.5f, 0.5f, zz);
                GL.Vertex3(-0.5f, 0.5f, zz);
                GL.Vertex3(0.5f, 0.5f, zz);
                GL.End();//------------------------------------------------------------
                GL.PopMatrix();//渲染出栈///////////////////////////////////////////////////////////
        }
    }
}
