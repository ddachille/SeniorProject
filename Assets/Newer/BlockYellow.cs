using UnityEngine;
using System.Collections;

public class BlockYellow : Block{
	
	public BlockYellow()
		: base()
	{
		
	}
	
	public override Tile TexturePosition(Direction direction){
		Tile tile = new Tile();
		
		tile.x = 0;
		tile.y = 2;
		
		return tile;
	}
}