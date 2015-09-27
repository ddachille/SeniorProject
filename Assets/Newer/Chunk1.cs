using UnityEngine;
using System.Collections;

//This automatically adds them
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]

public class Chunk1 : MonoBehaviour {
	
	Block[ , , ] blocks;
	public static int chunkSize = 20;
	public bool update = true;



	MeshFilter filter;
	MeshCollider coll;
	//Use this for initialization
	void Start () {
		filter = gameObject.GetComponent<MeshFilter>();
		coll = gameObject.GetComponent<MeshCollider>();
		
		//past here is just to set up an example chunk
		blocks = new Block[chunkSize, chunkSize, chunkSize];
		
		for (int x = 0; x < chunkSize; x++){
			for (int y = 0; y < chunkSize; y++){
				for (int z = 0; z < chunkSize; z++){
					blocks[x, y, z] = new BlockAir();
				}
			}
		}

		//testing
		//blocks[1, 5, 2] = new Block();
		//blocks[1, 5, 1] = new Block();
		//blocks[2, 5, 2] = new Block();
		//blocks[3, 5, 2] = new Block();
		//blocks[4, 5, 2] = new Block();
		//blocks[5, 5, 2] = new Block();
		//blocks[3, 6, 2] = new BlockYellow();
		for(int z = 1; z<=5; z++){
			for(int y = 11; y<=15 ;y++ ){
				blocks[1,y,z] = new Block();

			}
			for(int y = 4; y <=16 ; y++){
				blocks[2,y,z] = new Block();
			}
			for(int y =3; y <= 16; y++){
				blocks[3,y,z]= new Block();
			}
			for(int y=2; y <= 17; y++){
				blocks[4,y,z] =new Block();
			}
			for(int y = 2; y <= 17; y++){
				blocks[5,y,z] = new Block();
			}
			for(int y = 2; y <= 17; y++){
				blocks[6,y,z] = new Block();
			}
			for(int y = 2; y <= 17; y++){
				blocks[7,y,z] = new Block();
			}
			for(int y = 2; y <= 17; y++){
				blocks[8,y,z] = new Block();
			}
			for(int y = 1; y <= 18; y++){
				blocks[9,y,z] = new Block();
			}
			for(int y = 1; y <= 18; y++){
				blocks[10,y,z] = new Block();
			}
			for(int y = 2; y <= 17; y++){
				blocks[11,y,z] = new Block();
			}
			for(int y = 3; y <= 17; y++){
				blocks[12,y,z] = new Block();
			}
			for(int y = 5; y <= 15; y++){
				blocks[13,y,z] = new Block();
			}
			for(int y = 6; y <= 12; y++){
				blocks[14,y,z] = new Block();
			}
		}

		for(int z = 6; z <=6 ; z++){
			for(int y = 6; y <= 7; y++){
				blocks[2,y,z] = new Block();
			}
			for(int y = 12; y <= 13; y++){
				blocks[2,y,z] = new Block();
			}
			for(int y = 4; y <= 8; y++){
				blocks[3,y,z] = new Block();
			}
			for(int y = 11; y <= 15; y++){
				blocks[3,y,z] = new Block();
			}
			for(int y = 3; y <= 9; y++){
				blocks[4,y,z] = new Block();
			}
			for(int y = 11; y <= 15; y++){
				blocks[4,y,z] = new Block();
			}
			for(int y = 3; y <= 9; y++){
				blocks[5,y,z] = new Block();
			}
			for(int y = 11; y <= 14; y++){
				blocks[5,y,z] = new Block();
			}
			for(int y = 4; y <= 9; y++){
				blocks[6,y,z] = new Block();
			}
			for(int y = 11; y <= 12; y++){
				blocks[6,y,z] = new Block();
			}
			for(int y = 6; y <= 7; y++){
				blocks[7,y,z] = new Block();
			}
			for(int y = 13; y <= 15; y++){
				blocks[8,y,z] = new Block();
			}
			for(int y = 3; y <= 5; y++){
				blocks[9,y,z] = new Block();
			}
			for(int y = 8; y <= 10; y++){
				blocks[9,y,z] = new Block();
			}
			for(int y = 13; y <= 16; y++){
				blocks[9,y,z] = new Block();
			}
			for(int y = 3; y <= 5; y++){
				blocks[10,y,z] = new Block();
			}
			for(int y = 8; y <= 10; y++){
				blocks[10,y,z] = new Block();
			}
			for(int y = 14; y <= 16; y++){
				blocks[10,y,z] = new Block();
			}
			for(int y = 4; y <= 5; y++){
				blocks[11,y,z] = new Block();
			}
			for(int y = 7; y <= 11; y++){
				blocks[11,y,z] = new Block();
			}
			for(int y = 14; y <= 16; y++){
				blocks[11,y,z] = new Block();
			}
			for(int y = 7; y <= 11; y++){
				blocks[12,y,z] = new Block();
			}
			for(int y = 14; y <= 15; y++){
				blocks[12,y,z] = new Block();
			}
			for(int y = 7; y <= 11; y++){
				blocks[13,y,z] = new Block();
			}
		}

		for (int z = 7; z <= 7; z++) {
			for(int y = 7; y <= 7; y++){
				blocks[3,y,z] = new Block();
			}
			for(int y = 12; y <= 13; y++){
				blocks[3,y,z] = new Block();
			}
			for(int y = 5; y <= 8; y++){
				blocks[4,y,z] = new Block();
			}
			for(int y = 12; y <= 14; y++){
				blocks[4,y,z] = new Block();
			}
			for(int y = 5; y <= 8; y++){
				blocks[5,y,z] = new Block();
			}
			for(int y = 12; y <= 13; y++){
				blocks[5,y,z] = new Block();
			}
			for(int y = 6; y <= 7; y++){
				blocks[6,y,z] = new Block();
			}
			for(int y = 14; y <= 15; y++){
				blocks[9,y,z] = new Block();
			}
			for(int y = 4; y <= 4; y++){
				blocks[10,y,z] = new Block();
			}
			for(int y = 9; y <= 10; y++){
				blocks[10,y,z] = new Block();
			}
			for(int y = 15; y <= 15; y++){
				blocks[10,y,z] = new Block();
			}
			for(int y = 8; y <= 10; y++){
				blocks[11,y,z] = new Block();
			}
			for(int y = 15; y <= 15; y++){
				blocks[11,y,z] = new Block();
			}
			for(int y = 8; y <= 10; y++){
				blocks[12,y,z] = new Block();
			}
		}

		/*for (int z=8; z<=8; z++) {
			for(int y = 6; y <= 6; y++){
				blocks[4,y,z] = new Block();
			}
			for(int y = 13; y <= 13; y++){
				blocks[4,y,z] = new Block();
			}
			for(int y = 6; y <= 7; y++){
				blocks[5,y,z] = new Block();
			}
			for(int y = 9; y <= 9; y++){
				blocks[11,y,z] = new Block();
			}
		}*/

	




		UpdateChunk();
	}
	
	//Update is called once per frame
	void Update () {
		
	}
	
	public Block GetBlock(int x, int y, int z){
		return blocks[x, y, z];
	}
	
	//Updates the chunk based on its contents
	void UpdateChunk(){
		MeshData meshData = new MeshData();
		
		for (int x = 0; x < chunkSize; x++){
			for (int y = 0; y < chunkSize; y++){
				for (int z = 0; z < chunkSize; z++){
					meshData = blocks[x, y, z].Blockdata(this, x, y, z, meshData);
				}
			}
		}
		
		RenderMesh(meshData);
	}
	
	//Sends the calculated mesh information
	//to the mesh and collision components
	void RenderMesh(MeshData meshData){
		filter.mesh.Clear();
		filter.mesh.vertices = meshData.vertices.ToArray();
		filter.mesh.triangles = meshData.triangles.ToArray();

		filter.mesh.uv = meshData.uv.ToArray();
		filter.mesh.RecalculateNormals();

		coll.sharedMesh = null;
		Mesh mesh = new Mesh();
		mesh.vertices = meshData.colVertices.ToArray();
		mesh.triangles = meshData.colTriangles.ToArray();
		mesh.RecalculateNormals();
		
		coll.sharedMesh = mesh;
	}
	
}