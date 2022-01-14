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

        //maxTileNum만큼 칸을 생성하는 함수
        public void MapSetup(int maxTileNum) 
        {
            for (int i = 1; i <= maxTileNum; i++)
            {
                // 샛별칸 생성
                if (i % 5 == 0)
                {
                    TileInfo tile_Star = new TileInfo_Star();
                    tile_Star.index = i;
                    tile_Star.name = "Star";
                    tile_Star.discription = "이것은 별 타일, 너는 별을 얻고 이 타일의 별 개수가 증가";               
                    dic_tile.Add(i, tile_Star);
                }
                // tile dummy
                else
                {
                    TileInfo tile_Dummy = new TileInfo
                    {
                        index = i,
                        name = "Dummy",
                        discription = "이것은 일반 칸",
                    };
                    dic_tile.Add(i, tile_Dummy);
                }
            }
            Console.WriteLine($"맵이 완전히 설치되었다. 최대 타일 넘버는 {maxTileNum}");
        }

        //5배수는 샛별 칸

        //아니면 일반 칸
    }
}
