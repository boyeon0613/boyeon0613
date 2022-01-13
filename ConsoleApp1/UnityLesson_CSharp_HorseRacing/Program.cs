// See https://aka.ms/new-console-template for more information
namespace UnityLesson_CSharp_HorseRacing
{
    // 프로그램 시작시
    // 말 다섯마리를 만들고
    // 각 다섯마리는 초당 10~20 (정수형) 범위 거리를 랜덤하게 움직임
    // 각각의 말이 거리 200 에 도달하면 말의 이름과 등수를 출력해줌
    //
    // 말은
    // 이름, 달린거리 를 멤버변수로
    // 달리기 를 멤버 함수로 가짐.
    // 달리기 멤버함수는 입력받은 거리를 달린거리에 더해주어서 달린거리를 누적시키는 역할을 함.
    //
    // 매초 달릴 때 마다 각 말들이 얼마나 거리를 이동했는지 콘솔창에 출력해줌.
    // 경주가 끝나면 1,2,3,4,5 등 말의 이름을 등수 순서대로 콘솔창에 출력해줌.
    //
    // Hint
    // System.Threading namespace 에 있는 Thread.Sleep(1000); 를 사용하면 현재 프로그램을 1초 지연시킬수 있음
    // While 반복문에서 Thread.Sleep(1000); 을 추가하면 1초에 한번씩 반복문을 실행함.
    class Program
    {
        static bool isGameFinished = false; //경주가 끝났는지 체크하는 변수
        static int finishedDistance = 200;//결승점 거리
        static int currentGrade = 1;//순위를 가리기 위한 배열값 //현재 등수
        static Random random; //말이 달리는 소리를 랜덤하게 생성하기 위한 난수 변수
        static void Main(string[] args)
        {
            Horse[] arr_hor = new Horse[5]; //말 5마리를 인스턴스화시키기 위한 배열
            string[] arr_FinishedHorseName=new string[5]; //결승점을 통과한 말의 이름을 저장할 배열
             for (int i = 0; i < arr_hor.Length; i++) // 말들을 인스턴스화 시키고, 말들의 이름을 초기화하는 for문 
            {
                arr_hor[i] = new Horse();//말 인스턴스화
                arr_hor[i].name = "말" + (i + 1);//말 이름 초기화
                
            }

            Console.WriteLine("경주 시작!"); //경주 시작 표시하는 텍스트창.
            int count = 0; //While 문이 돈 횟수

            while ( ! isGameFinished) //게임이 끝날 때까지 돌아가는 while문
            {
                count++; //시작 시 카운트 증가
                Console.WriteLine($"========{count}==========");//count는 1초에 1씩 올라감. (이유 : while문 마지막에 Thread.Sleep(1000)으로 1초 지연이 있기 때문)
                for (int i = 0; i < arr_hor.Length; i++) //랜덤한 속도로 말을 달리게 하기 위한 for문
                {
                    if (!arr_hor[i].dontmove)//i번째 말이 움직일 수 있으면
                    {
                        random = new Random(); //난수형 인스턴스
                        int tmpMoveDistance = random.Next(10, 20);//10~20 사이의 임의의 변수
                        arr_hor[i].Run(tmpMoveDistance);//i번째 말을 tmpMoveDistance(10~20 사이 정수) 만큼 달림.
                        Console.WriteLine($"{arr_hor[i].name}는 {count}초 간 {arr_hor[i].distance}만큼 달렸다.");//i번째 말이름가 달린 거리 {i번째 말이 달린 거리} 출력.
                    }
                        if(arr_hor[i].distance>=finishedDistance)//i번째 말이 달린 거리가 결승점 거리보다 크거나 같을 때
                    {
                        arr_hor[i].dontmove = true; //i번째 말을 더이상 달리지 않게 해줌
                        arr_FinishedHorseName[currentGrade - 1] = arr_hor[i].name; //결승점에 도달한 말의 이름을 현재 등수-1번째 자리에 저장
                        currentGrade++; //등수가 늘어남 
                    }

                    Console.WriteLine("=================================================");
                    if (currentGrade>5)//현재 등수가 5보다 크면, 즉 1에서 5등까지 전부 결승선에 들어왔으면
                    {
                        isGameFinished = true; //게임이 끝났다
                        Console.WriteLine("경주 끝"); //경주 끝 출력
                        break; //while loop 탈출
                    }
                }
                Thread.Sleep(1000);//1초에 1씩 카운트 올라가게 됨


            }
            Console.WriteLine("결과발표");//결과발표를 출력
            for (int i = 0; i < arr_FinishedHorseName.Length; i++)//경주가 끝난 말의 이름을 등수대로 출력해주는 for문
            {
                Console.WriteLine($"{i+1}등 {arr_FinishedHorseName}"); //[i+1]에 저장된 완주마의 이름 출력
            }
           
        }
    }
}
