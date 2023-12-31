# 유니티 심화 주차 개인 프로젝트
- A02조 함영주
<br>

## 🖥 프로젝트 소개 
가수 뉴진스의 IP를 활용한 팬 게임 개발 : 뉴진스 뮤직비디오에 나온 게임을 모티브로 제작하여, 누구나 쉽게 할 수 있는 2D 플랫포머 게임을 제작하여 팬과 그 외 모든 유저들이 즐길 수 있는 게임 제작.
<br>


### 🐰 **프로젝트명** : NewJeans : 버니즈 구하기 
- 뉴진스 X 파워 퍼프걸 캐릭터를 이용해 캐릭터가 이동하며 아이템(쿠키)을 먹고 토끼 캐릭터(버니즈:뉴진스 팬 명칭)를 구하는게임 

<br>

### 🕰 **프로젝트 기간** : 2023.10.10 ~ 2023.10.12

### ✅ 개발 환경 
**Unity 2022.3.2f** 
-해상도 :  1980 * 1280
<br>

### ✅제작 과정
- 기획단계 : 문서 가이드라인 제작
 ![스크린샷 2023-10-12 오전 11 09 02](https://github.com/HamYoungjoo/Unity_Project_3-3/assets/141566906/780b1541-4529-454e-b902-4cce31b46113)

<br>

### ✅게임 방법 
```　
1. 키보드 방향 키를 이용해 플레이어 이동, 스페이스 키를 이용해 점프한다.
2. 플레이어는 적 토끼를 피해 목표 지점까지 가서 버니즈 토끼를 구한다.
3. 플레이어에게는 3개의 목숨이 주어지고, 바닥에 떨어지거나, 적과 부딪힐 때, 장애물(촛불)과 부딪힐 때 하나씩 감소하고 모두 감소 될 시 게임오버 된다.
4. 적 혹은 장애물과 충돌 시 플레이어는 잠시 동안 무적 상태가 된다.
5. 플레이어는 점프를 통해 적을 밟아 공격할 수 있고, 적을 처리 할 시 100점의 점수를 얻을 수 있다.
6. 아이템 쿠키를 먹으면 1개의 100점씩 점수가 추가 된다.
7. 게임을 클리어 하면 최종 점수를 확인 할 수 있고 처음 화면으로 돌아가거나 다시 시작 할 수 있다.
```

<br>

### ✅ 구현 기능
**[Start Scene]**
 - **배경음악** : 게임 시작 화면에 게임오브젝트에 AudioSuorce 컴포넌트를 추가해 배경음악을 추가하였다.
 - **시작버튼** : 스타트 텍스트 클릭시 메인 게임화면으로 이동하는 기능으로 버튼 컴포넌트 추가 후 게임매니저 내 함수를 적용하였다. 
 - **애니매이션** : 시작버튼에 색변환 애니매이션 효과를 넣었다.
   
<br>

**[Main Scene]**
 - **배경음악** : 게임매니저에 AudioSuorce 컴포넌트를 추가, 스크립트를 이용해 게임 중지 시 음악이 멈추도록 하였다.
 - **플레이어**<br/>
   - 이동 : 방향키를 이동해 좌우 이동, 스페이스 키를 이용해 점프.
   - 데미지 효과 : 데미지를 입으면 잠시동안 캐릭터 색상이 변한다.
   - 공격 : 점프를 이용해 적을 밟아서 없앨 수 있다.
   - 애니매이션 : 기본 상태, 점프 상태 ,이동 상태의 애니매이션을 각각 다르게 하였다.
- **적**<br/>
  - 이동 : 레이캐스트힛을 이용해 바닥에 닿아 있을 때를 파악해 떨어지지 않게 하고 , 일정 시간을 기준으로 랜덤으로 좌, 우 움직임과 정지를 하게 하였다.
  - 데미지 효과 : 플레이어의 공격으로 데미지를 입을 시 스프라이트의 상하가 반전되고 색상이 변하고 사라지게 하였다.
- **아이템** : 플레이어가 아이템을 먹으면 점수창에 점수가 올라간다.
- **타이머** : 게임 시작 시 타이머가 작동해 게임 클리어까지 얼만큼의 시간을 소요했는지 파악 할 수 있다.
- **플레이어 목숨** : 플레이어가 데미지를 입었을 때 빨간색으로 변한다.
- **게임오버, 게임클리어 패널** : 목숨을 다 잃거나, 게임을 클리어 했을 때 패널이 팝업되어 처음 시작화면으로 돌아가거나 게임을 다시 시작할 수 있다.

<br>

### ✅ 게임 화면 
![스크린샷 2023-10-12 오전 11 48 39](https://github.com/HamYoungjoo/Unity_Project_3-3/assets/141566906/abab5886-54dc-4146-afac-e6db040be62c) <br/>

![스크린샷 2023-10-12 오전 11 21 53](https://github.com/HamYoungjoo/Unity_Project_3-3/assets/141566906/79b09b1b-64b1-4a53-8df4-a8d02fc42059) <br/>
![스크린샷 2023-10-12 오전 11 22 33](https://github.com/HamYoungjoo/Unity_Project_3-3/assets/141566906/bebd9d91-02c5-4e54-af3c-a6b95be59c87) <br/>
![스크린샷 2023-10-12 오후 12 20 20](https://github.com/HamYoungjoo/Unity_Project_3-3/assets/141566906/9821f6a0-bfbb-43c6-b5b5-5805699beaf2) <br/>


### ✅ 추후 계획
- 아이템을 prefab으로 생성하는 방법이 있을 것 같은데 구현 방법을 아직 찾지 못해 추후 아이템 생성 방법을 공부 한 뒤 추가.
- 적 캐릭터 위치별 생성.
- 스테이지 추가, 지금은 하나의 스테이지에서 목표지점에 도착하면 게임 클리어인데 스테이지를 추가해 난이도의 차별성을 둘 것.

