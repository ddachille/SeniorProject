using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;
//added in tutorial
using System.Collections.Generic;

public class PolygonGenerator : MonoBehaviour {
	// This first list contains every vertex of the mesh that we are going to render
	public List<Vector3> newVertices = new List<Vector3>();
	
	// The triangles tell Unity how to build each section of the mesh joining
	// the vertices
	public List<int> newTriangles = new List<int>();
	
	// The UV list is unimportant right now but it tells Unity how the texture is
	// aligned on each polygon
	public List<Vector2> newUV = new List<Vector2>();
	
	
	// A mesh is made up of the vertices, triangles and UVs we are going to define,
	// after we make them up we'll save them as this mesh
	private Mesh mesh;
	
	private float tUnit = 0.25f;
	private Vector2 tStone = new Vector2 (0, 0);
	private Vector2 tGrass = new Vector2 (0, 1);
	
	//keeps track of which square
	private int squareCount;
	
	//will store block info, only up to 255ish blocks tho
	public byte[,] blocks;
	
	//for the collision meshes
	public List<Vector3> colVertices = new List<Vector3>();
	public List<int> colTriangles = new List<int>();
	private int colCount;
	private MeshCollider col;

	public bool update=false;
	
	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshFilter> ().mesh;
		
		//start mesh collider
		col = GetComponent<MeshCollider> ();
		
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;
		
		GenTerrain();
		BuildMesh();
		updateMesh();
		
	}
	
	void GenSquare(int x, int y, Vector2 texture){
		newVertices.Add( new Vector3 (x  , y  , 0 ));
		newVertices.Add( new Vector3 (x + 1 , y  , 0 ));
		newVertices.Add( new Vector3 (x + 1 , y-1 , 0 ));
		newVertices.Add( new Vector3 (x  , y-1 , 0 ));
		
		newTriangles.Add(squareCount*4);
		newTriangles.Add((squareCount*4)+1);
		newTriangles.Add((squareCount*4)+3);
		newTriangles.Add((squareCount*4)+1);
		newTriangles.Add((squareCount*4)+2);
		newTriangles.Add((squareCount*4)+3);
		
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2 (tUnit*texture.x+tUnit, tUnit*texture.y+tUnit));
		newUV.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y));
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y));
		
		squareCount++;
	}
	
	void updateMesh(){
		mesh.Clear ();
		mesh.vertices = newVertices.ToArray();
		mesh.triangles = newTriangles.ToArray();
		mesh.uv = newUV.ToArray(); // add this line to the code here
		mesh.Optimize ();
		mesh.RecalculateNormals ();
		
		Mesh newMesh = new Mesh();
		newMesh.vertices = colVertices.ToArray();
		newMesh.triangles = colTriangles.ToArray();
		col.sharedMesh= newMesh;
		
		squareCount=0;
		newVertices.Clear();
		newTriangles.Clear();
		newUV.Clear();
		
		colVertices.Clear();
		colTriangles.Clear();
		colCount=0;
	}
	
	void ColliderTriangles(){
		colTriangles.Add(colCount*4);
		colTriangles.Add((colCount*4)+1);
		colTriangles.Add((colCount*4)+3);
		colTriangles.Add((colCount*4)+1);
		colTriangles.Add((colCount*4)+2);
		colTriangles.Add((colCount*4)+3);
	}
	
	void GenCollider(int x, int y){
		//Top
		if(Block(x,y+1)==0){
			colVertices.Add( new Vector3 (x  , y  , 1));
			colVertices.Add( new Vector3 (x + 1 , y  , 1));
			colVertices.Add( new Vector3 (x + 1 , y  , 0 ));
			colVertices.Add( new Vector3 (x  , y  , 0 ));
			
			ColliderTriangles();
			
			colCount++;
		}
		
		//Bottom
		if(Block(x,y-1)==0){
			colVertices.Add( new Vector3 (x  , y -1 , 0));
			colVertices.Add( new Vector3 (x + 1 , y -1 , 0));
			colVertices.Add( new Vector3 (x + 1 , y -1 , 1 ));
			colVertices.Add( new Vector3 (x  , y -1 , 1 ));
			
			ColliderTriangles();
			colCount++;
		}
		
		//Left
		if(Block(x-1,y)==0){
			colVertices.Add( new Vector3 (x  , y -1 , 1));
			colVertices.Add( new Vector3 (x  , y  , 1));
			colVertices.Add( new Vector3 (x  , y  , 0 ));
			colVertices.Add( new Vector3 (x  , y -1 , 0 ));
			
			ColliderTriangles();
			
			colCount++;
		}
		
		//Right
		if(Block(x+1,y)==0){
			colVertices.Add( new Vector3 (x +1 , y  , 1));
			colVertices.Add( new Vector3 (x +1 , y -1 , 1));
			colVertices.Add( new Vector3 (x +1 , y -1 , 0 ));
			colVertices.Add( new Vector3 (x +1 , y  , 0 ));
			
			ColliderTriangles();
			
			colCount++;
		}
		
	}
	
	//0 is air in tut, 1 is rock, 2 is grass!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	//makes a 10-10 array of blocks, y less than 5 is a rock, the row at 5 is grass
	void GenTerrain(){
		blocks=new byte[10,10];
		
		for(int px=0;px<blocks.GetLength(0);px++){
			for(int py=0;py<blocks.GetLength(1);py++){
				if(py==5){
					blocks[px,py]=2;
				} else if(py<5){
					blocks[px,py]=1;
				}
			}
		}
	}
	
	//Builds based on values set in GenTerrain, using GenSquare
	void BuildMesh(){
		for(int px=0;px<blocks.GetLength(0);px++){
			for(int py=0;py<blocks.GetLength(1);py++){
				//If the block is not air
				if(blocks[px,py]!=0){
					
					// GenCollider here, this will apply it
					// to every block other than air
					GenCollider(px,py);
					
					if(blocks[px,py]==1){
						GenSquare(px,py,tStone);
					} else if(blocks[px,py]==2){
						GenSquare(px,py,tGrass);
					}
				}//End air block check
			}
		}
	}
	
	//Checks content of block. if within array boundaries, it returns 1 solid, or returns value
	byte Block (int x, int y){
		
		if(x==-1 || x==blocks.GetLength(0) ||   y==-1 || y==blocks.GetLength(1)){
			return (byte)1;
		}
		
		return blocks[x,y];
	}
	
	// Update is called once per frame
	void Update () {
		if(update){
			BuildMesh();
			updateMesh();
			update=false;
		}
	}
}
