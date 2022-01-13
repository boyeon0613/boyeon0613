// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;


namespace UnityLesson_CSharp_Dice
{ 
    internal class Program
    {
        static private int totalTile = 20;//칸의 개수
        static private int currentStarPoint = 0;//샛별 갯수
        static private int totalDiceNumber = 20;//주사위 갯수
        static private int currentTileIndex = 0;//현재 칸의 번호
        static private int previousTileIndex = 0;//이전 칸의 번호(플레이어가 샛별 칸을 지나는지 비교하기 위함)
        static private Random random;
        static void Main(string[] args)
        {
            TileMap map = new TileMap(); //맵 클래스 인스턴스화
            map.MapSetup(totalTile); //맵 생성(20칸)

            int currentDiceNumber = totalDiceNumber; //현재 주사위 갯수 초기값은 최대 주사위 갯수
            while (currentDiceNumber >0)
            {

                int diceValue = RollADice();

                Console.WriteLine($"주사위 값은: {diceValue}");
                currentDiceNumber--;
                currentTileIndex += diceValue;

                //플레이어가 샛별 칸을 지날 때(5의 배수칸을 지날 때)
                if (previousTileIndex/5 < currentTileIndex/5)
                {
                    int passedStarTileindex = CalcPassedStarTileIndex(currentTileIndex);//지나온 샛별칸 번호 계산
                    TileInfo passedStarTileInfo = map.dic_tile.GetValueOrDefault(passedStarTileindex);
                    TileInfo_Star passedStarTileInfo_Star = passedStarTileInfo as TileInfo_Star;//TileInfo 타입을 TileInfo
                    if (passedStarTileInfo_Star != null) //샛별칸의 TileInfo 정보를 가져오는데 성공했으면
                    {
                        currentStarPoint += passedStarTileInfo_Star.starValue;// 샛별 점수 누적
                    }
                }

                if(currentTileIndex >= totalTile) //현재 칸이 최대칸을 넘어가버렸을 때 
                {
                    currentTileIndex -= totalTile;//현재칸에서 최대칸을 뺀다
                }

                TileInfo info = map.dic_tile.GetValueOrDefault(currentTileIndex);//map에서 현재칸의 TileInfo를 가져옴.
                if (info == null)//현재칸의 Tileinfo를 가져오지 못했을 때는 프로그램을 끝내버린다.
                {
                    return;
                }
                Console.WriteLine($"타일 인덱스 : {currentTileIndex}");//현재 칸의 번호 출력
                string tileMapName = info.name; //현재 칸의 이름
                switch (tileMapName) //현재 칸의 이름에 따른 분기문
                {
                    case "Dummy":
                        break;
                    case "Star":
                        break;
                    default:
                        return;
                        break;
                }
                switch (diceValue)
                {
                    case 1:
                        Console.WriteLine("┌───────────┐");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│     ●    │");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│           │");
                        Console.WriteLine("└───────────┘");
                        break;
                    case 2:
                        Console.WriteLine("┌───────────┐");
                        Console.WriteLine("│ ●        │");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│         ●│");
                        Console.WriteLine("└───────────┘");
                        break;
                    case 3:
                        Console.WriteLine("┌───────────┐");
                        Console.WriteLine("│         ●│");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│     ●    │");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│ ●        │");
                        Console.WriteLine("└───────────┘");
                        break;
                    case 4:
                        Console.WriteLine("┌───────────┐");
                        Console.WriteLine("│ ●      ●│");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│ ●      ●│");
                        Console.WriteLine("└───────────┘");
                        break;
                    case 5:
                        Console.WriteLine("┌───────────┐");
                        Console.WriteLine("│ ●      ●│");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│     ●    │");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│ ●      ●│");
                        Console.WriteLine("└───────────┘");
                        break;
                    case 6:
                        Console.WriteLine("┌───────────┐");
                        Console.WriteLine("│ ●      ●│");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│ ●      ●│");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│ ●      ●│");
                        Console.WriteLine("└───────────┘");
                        break;
                    default:
                        break;

                }

                Console.WriteLine($"플레이어의 현재 칸은 : {currentTileIndex}");
                Console.WriteLine($"남은 칸 갯수는: {totalTile}");

            }

        }
        static private int RollADice()
        {
            string userInput = "Default";

            while (userInput != "")
            {
                Console.WriteLine("엔터 키를 눌러서 주사위를 굴리세요.");
                userInput = Console.ReadLine();
            }

            random = new Random(); //난수 생성용 인스턴스
            int diceValue = random.Next(1, 6 + 1);//1~6 중 랜덤한 정수

            return diceValue;
        }
        //현재 칸의 번호를 넣어주면 지나온 샛별 칸의 번호를 반환해주는 함수
        static public int CalcPassedStarTileIndex(int currentTileIndex)
        {
            int index = currentTileIndex / 5 * 5;
            return index;
        }
    }

}

//엔터키 입력으로 주사위를 굴립니다.
//주사위를 굴리면 플레이어가 전진하고, 샛별칸에 도착하거나 지나갈 시 샛별에 대한 이벤트가 발생합니다.
//총 칸은 1에서 20까지 있으며, 20을 넘어가면 다시 1부터 전진을 계속합니다.
//5배수 칸은 샛별칸이고, 이 칸을 지나거나 도착하면 샛별을 획득할 수 있습니다.
//5배수 칸에 도착할 때에는 샛별 획득 개수가 영구적으로 1 증가합니다.
//샛별을 획득할 시 , 새로 얻은 샛별 수와 총 획득한 샛별 수를 보여줍니다.
//총 샛별을 30개 획득하면 게임이 종료되고, 사용한 총 주사위 수를 보여줍니다.
//
// 콘솔 출력 :
// 주사위를 돌려서 어떤 칸에 도착하면,
// 해당 칸의 번호 (1~20 중 하나 ), 해당 칸이 어떤칸인지 (그냥 일반인지 샛별인지 ),
// 현재 샛별수는 몇개인지 , 남은 주사위 수는 몇개인지 콘솔창에 출력해주고
// 다시 주사위를 굴리라고 콘솔창에 출력해줌.
// 주사위를 다쓰면 모은 샛별 수를 출력해주고 게임을 종료함.
//Console.WriteLine("┌───────────┐");
//Console.WriteLine("│ ●      ●│");
//Console.WriteLine("│           │");
//Console.WriteLine("│     ●    │");
//Console.WriteLine("│           │");
//Console.WriteLine("│ ●      ●│");
//Console.WriteLine("└───────────┘");

