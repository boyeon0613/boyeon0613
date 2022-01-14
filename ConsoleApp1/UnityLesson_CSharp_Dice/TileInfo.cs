using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_Dice
{
    public class TileInfo
    {
        public int index;
        public string name;
        public string discription;

         virtual public void TileEvent()
        {
            Console.WriteLine($"타일 이름은 {name}, 위치는 {index}, 설명 : {discription}이다");
        }
    }
}
