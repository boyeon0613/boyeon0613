// See https://aka.ms/new-console-template for more information

//경마게임 의사코드

//맵 구성 : 
//1.달리기를 할 트랙
//2. 1, 2, 3등을 위한 단상

//게임플레이 :
//Gameobject 5개를 랜덤한 속도로 전진하게 하여 
//결승점에 도달할 경우 게임을 끝내고
//1,2,3등은 1,2,3등 단상에 각각 위치시킨다.

//논리 세분화.

//1. Gameobject5개를 부른다.
//2. 모두 거리 0부터 달리게 한다.
//3. 결승점 위치는 N이다.
//4. "이동 거리"는 이동한 랜덤값이다.
//5. "말의 위치"는 0에 "이동 거리"를 더한다.
//6. "말의 위치"가 N보다 같거나 크면 Gameobject는 연산을 그만둔다.
//7. 작거나 같으면 4로 돌아간다.
//8. 연산을 멈춘 순서대로 Gameobject의 순위를 등록한다.
//9. 3등까지 해당 등수 단상에 올린다.

//의사코드 : 

//Horse Distance = 0
//FinishLine=N;
//Run = Random
//Horse Distance+=Run
//for문 Horse Distance>FinishLine까지 반복
//for문 종료 후
//Horse 먼저 들어온 순서대로 등수매김
//1~3위까지 단상

//GameObject 리스트에 GameObject 5개 대입
//GameObject 등수 리스트 생성
// if(게임진행이면 반복실행)
// {
//forerach 문 (GameObject 리스트를 반복)
//{
//    GameObject.Position += 랜덤 속도
// if (GameObject.Position > 결승점)
// {등수 리스트.Add(GameObject)}
// }
// if(등수리스트.count>5)\
// {게임 끝
//  등수리스트[0].Position = 1등 단상 위치
//  등수리스트[1].Position = 2등 단상 위치
//  등수리스트[2].Position = 3등 단상 위치
// }
//
//