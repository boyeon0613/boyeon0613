using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_Dice
{// Hint
 // 만들어야 하는 클래스 :
 // TileMap (맵을 세팅하고 맵에대한 정보를 가지고 있을 클래스 )
 // TileInfo ( 각 칸들의 정보를 멤버로 가지는 클래스 )
 // TileInfo_Star ( 샛별칸을 위한 클래스. TileInfo 를 상속받고 샛별칸에 대한 특수 정보를 멤버로 추가함 )
 // 주사위는 아래처럼 콘솔창에 찍어서 보여주면 됨.
    public class TileMap
    {
     public Dictionary<int, TileInfo> dic_tile=new Dictionary<int, TileInfo>();//칸 번호, 칸 정보를 저장할 사전
                                                                               //maxTileNum
        public void MapSetup(int maxTileNum)
        {
            for (int i = 1; i <= maxTileNum; i++)
            {
                // tile star
                if (i % 5 == 0)
                {
                    TileInfo tile_Star = new TileInfo_Star
                    {
                        index = i,
                        name = "Star",
                        discription = "This is star tile, You'll get star and star amount on this tile increase 1."
                    };
                    dic_tile.Add(i, tile_Star);
                }
                // tile dummy
                else
                {
                    TileInfo tile_Dummy = new TileInfo
                    {
                        index = i,
                        name = "Dummy",
                        discription = "This is dummy tile",
                    };
                    dic_tile.Add(i, tile_Dummy);
                }
            }
            Console.WriteLine($"Map setup complete. Maximum tile number is {maxTileNum}");
        }

        //5배수는 샛별 칸

        //아니면 일반 칸
    }
}
