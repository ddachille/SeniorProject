using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour {

	public byte[,,] data;
	public int worldX=16;
	public int worldY=16;
	public int worldZ=16;

	// Use this for initialization
	void Start () {
		data = new byte[worldX,worldY,worldZ];

		//0 is air, 1 is stone and 2 is dirt.
		for (int x=0; x<worldX; x++){
			for (int y=0; y<worldY; y++){
				for (int z=0; z<worldZ; z++){
					if(y>8){
						data[x,y,z]=1;
					}
					
				}
			}
		}
	}

	public byte Block(int x, int y, int z){
		
		if( x>=worldX || x<0 || y>=worldY || y<0 || z>=worldZ || z<0){
			return (byte) 1;
		}
		
		return data[x,y,z];
	}

	// Update is called once per frame
	void Update () {
	
	}
}
