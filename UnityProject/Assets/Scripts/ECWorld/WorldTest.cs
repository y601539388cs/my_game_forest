using UnityEngine;
using System.Collections;

public class WorldTest : MonoBehaviour {

	
    public Vector3[] m_vertices;


    public Vector2[] m_uv;


    public Color[] m_color;


    public Vector3[] m_normals;


    public int[] m_triangles;

 	public Vector3 root;

    private int m_width=100;
    private int m_height = 50;

    private Mesh mesh;

    public void SetGridColor(int i,int j,Color newColor)
    {
        m_color[(i*m_height+j)*8]=newColor;
        m_color[(i*m_height+j)*8+1]=newColor;
        m_color[(i*m_height+j)*8+2]=newColor;
        m_color[(i*m_height+j)*8+3]=newColor;
        m_color[(i*m_height+j)*8+4]=newColor;
        m_color[(i*m_height+j)*8+5]=newColor;
        m_color[(i*m_height+j)*8+6]=newColor;
        m_color[(i*m_height+j)*8+7]=newColor;
    }

    void CreateCube()
    {
    	m_vertices = new Vector3[m_width*m_height*8];
    	for(int i=0;i<m_width;++i)
    	{
    		for(int j=0;j<m_height;++j)
    		{
    			m_vertices[(i*m_height+j)*8]=new Vector3(root.x+i,root.y+j,root.z);
    			m_vertices[(i*m_height+j)*8+1]=new Vector3(root.x+i+1,root.y+j,root.z);
    			m_vertices[(i*m_height+j)*8+2]=new Vector3(root.x+i+1,root.y+j+1,root.z);
    			m_vertices[(i*m_height+j)*8+3]=new Vector3(root.x+i,root.y+j+1,root.z);
    			m_vertices[(i*m_height+j)*8+4]=new Vector3(root.x+i,root.y+j,root.z-1);
    			m_vertices[(i*m_height+j)*8+5]=new Vector3(root.x+i+1,root.y+j,root.z-1);
    			m_vertices[(i*m_height+j)*8+6]=new Vector3(root.x+i+1,root.y+j+1,root.z-1);
    			m_vertices[(i*m_height+j)*8+7]=new Vector3(root.x+i,root.y+j+1,root.z-1);
    		}
    	}

        m_color = new Color[m_width*m_height*8];
        
        for(int i=0;i<m_width;++i)
        {
            for(int j=0;j<m_height;++j)
            {
               SetGridColor(i,j,Color.green);
            }
        }


        m_triangles = new int[m_width*m_height*6*6]; // 两个三角面的连接


       
        for(int i=0;i<m_width;++i)
        {
            for(int j=0;j<m_height;++j)
            {   
                //front
                m_triangles[(i*m_height+j)*6*6] = (i*m_height+j)*8;
                m_triangles[(i*m_height+j)*6*6+1] = (i*m_height+j)*8+1;
                m_triangles[(i*m_height+j)*6*6+2] = (i*m_height+j)*8+2;

                m_triangles[(i*m_height+j)*6*6+3] = (i*m_height+j)*8;
                m_triangles[(i*m_height+j)*6*6+4] = (i*m_height+j)*8+2;
                m_triangles[(i*m_height+j)*6*6+5] = (i*m_height+j)*8+3;

             
                //left
                m_triangles[(i*m_height+j)*6*6+6] = (i*m_height+j)*8;
                m_triangles[(i*m_height+j)*6*6+7] = (i*m_height+j)*8+3;
                m_triangles[(i*m_height+j)*6*6+8] = (i*m_height+j)*8+7;

                m_triangles[(i*m_height+j)*6*6+9] = (i*m_height+j)*8;
                m_triangles[(i*m_height+j)*6*6+10] = (i*m_height+j)*8+7;
                m_triangles[(i*m_height+j)*6*6+11] = (i*m_height+j)*8+4;

                
                //right
                m_triangles[(i*m_height+j)*6*6+12] = (i*m_height+j)*8+1;
                m_triangles[(i*m_height+j)*6*6+13] = (i*m_height+j)*8+2;
                m_triangles[(i*m_height+j)*6*6+14] = (i*m_height+j)*8+6;

                m_triangles[(i*m_height+j)*6*6+15] = (i*m_height+j)*8+1;
                m_triangles[(i*m_height+j)*6*6+16] = (i*m_height+j)*8+6;
                m_triangles[(i*m_height+j)*6*6+17] = (i*m_height+j)*8+5;

                   //back
                m_triangles[(i*m_height+j)*6*6+18] = (i*m_height+j)*8+4;
                m_triangles[(i*m_height+j)*6*6+19] = (i*m_height+j)*8+5;
                m_triangles[(i*m_height+j)*6*6+20] = (i*m_height+j)*8+6;

                m_triangles[(i*m_height+j)*6*6+21] = (i*m_height+j)*8+4;
                m_triangles[(i*m_height+j)*6*6+22] = (i*m_height+j)*8+6;
                m_triangles[(i*m_height+j)*6*6+23] = (i*m_height+j)*8+7;

                   //top
                m_triangles[(i*m_height+j)*6*6+24] = (i*m_height+j)*8+2;
                m_triangles[(i*m_height+j)*6*6+25] = (i*m_height+j)*8+3;
                m_triangles[(i*m_height+j)*6*6+26] = (i*m_height+j)*8+7;

                m_triangles[(i*m_height+j)*6*6+27] = (i*m_height+j)*8+2;
                m_triangles[(i*m_height+j)*6*6+28] = (i*m_height+j)*8+7;
                m_triangles[(i*m_height+j)*6*6+29] = (i*m_height+j)*8+6;


                //bottom
                m_triangles[(i*m_height+j)*6*6+30] = (i*m_height+j)*8;
                m_triangles[(i*m_height+j)*6*6+31] = (i*m_height+j)*8+1;
                m_triangles[(i*m_height+j)*6*6+32] = (i*m_height+j)*8+4;

                m_triangles[(i*m_height+j)*6*6+33] = (i*m_height+j)*8+1;
                m_triangles[(i*m_height+j)*6*6+34] = (i*m_height+j)*8+5;
                m_triangles[(i*m_height+j)*6*6+35] = (i*m_height+j)*8+4;

           

            }
        }
          
       

    }

    void Start()


    {
        CreateCube();
    	MeshFilter meshFilter = (MeshFilter)this.GetComponent(typeof(MeshFilter)); 
        mesh = meshFilter.mesh;







    }


     

    int index=0;
    void Update () 


    {


       // 清除mesh信息，下面可以做相应的mesh动画


        mesh.Clear();  


        mesh.vertices = m_vertices;
        


        //mesh.uv = m_uv;

        SetGridColor(index,10,Color.red);
        if(index>=1)
        {
             SetGridColor(index-1,10,Color.green);
        }
        index=(index+1)%m_width;

        mesh.colors = m_color;  

        mesh.triangles = m_triangles;
      //  mesh.normals = m_normals;


        


       // mesh.RecalculateNormals();


        


    }

}
