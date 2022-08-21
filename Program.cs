using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniLand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false; //커서가 표시되지 않게 하기
            bool _isFinish = false; //끝내기
            bool _isStart = false; //진행하기
            int posY = 0; //커서 위치

            do
            {
                if (_isStart) //시작(enter)키를 누른 경우
                {
                    switch (posY)
                    {
                        case 0: //홀짝게임
                            Console.Clear(); //안내메세지 지우기
                            oddoreven(); //홀짝게임
                            _isStart = false;
                            break;

                        case 1: //가위바위보 게임
                            Console.Clear();
                            RockPaper();
                            _isStart = false;
                            break;
                        case 2: //업앤다운 게임
                            Console.Clear();
                            upanddown();
                            _isStart = false;
                            break;
                        case 3: //종료
                            _isFinish = true;
                            break;
                    }
                }
                else //대기화면인 경우
                {
                    Console.Clear();
                    Start();
                    what(ref posY);
                    _isStart = true;
                    Console.Clear();
                }

            } while (!_isFinish);

        }

        static void Start() //메인화면
        {
            Console.WriteLine("미니 랜드에 오신 것을 환영합니다. 플레이 하실 게임을 선택해주세요.");
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("홀짝 게임");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("가위바위보 게임");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("업앤다운 게임");
            Console.SetCursorPosition(3, 5);
            Console.WriteLine("게임 완전 종료");
        }

        static void what(ref int posY)
        {
            bool _letOut = false;
            do
            {
                for (int i = 0; i < 4; i++) //커서의 y축 위치 변경
                {
                    Console.SetCursorPosition(0, i + 2);
                    Console.Write("  ");
                }
                Console.SetCursorPosition(0, posY + 2);
                Console.Write("▶");

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key) //커서가 선택목록 밖으로 벗어나지 않게
                {
                    case ConsoleKey.UpArrow: 
                        posY--;
                        if (posY < 0)
                        {
                            posY = 3;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        posY++;
                        if (posY > 3)
                        {
                            posY = 0;
                        }
                        break;
                    case ConsoleKey.Enter: //엔터를 눌렀을 시 break
                        _letOut = true;
                        break;
                }

            } while (!_letOut);

            Console.SetCursorPosition(0, 0); //커서의 시작 위치
        }

        static void oddoreven() //홀짝게임 반복으로 돌아가게
        {
            int win = 0;
            int lose = 0;
            Console.Clear();
            game1(ref win, ref lose);
            while (true)
            {
                Console.Write("다시 하시겠습니까? (Y/N): ");
                string b = Console.ReadLine();
                if (b == "y" || b == "Y")
                {
                    game1(ref win, ref lose);
                    continue;
                }
                if (b == "n" || b == "N")
                {
                    Console.WriteLine("총 {0}번 패배, {1}번 승리하셨습니다.", lose, win);
                    Console.WriteLine("게임 선택 화면으로 돌아갑니다.");
                    Console.ReadKey();
                    Start();
                    break;
                }
                else
                {
                    Console.WriteLine("입력을 확인하지 못했습니다.");
                    continue;
                }
            }
        }

        static void game1(ref int win, ref int lose)
        {
            Random random = new Random();

            while (true)
            {
                int i = random.Next(1, 9);

                Console.Write("홀 또는 짝 중에 하나를 적어주십시오: ");
                string a = Console.ReadLine();

                if (a == "짝")
                {
                    if (i % 2 == 0)
                    {
                        win++;
                        Console.WriteLine("컴퓨터의 선택: 짝");
                        Console.WriteLine("승리!");
                        break;
                    }
                    else //사용자가 짝을 입력했을 때, 컴퓨터가 홀수를 골랐을 시
                    {
                        lose++;
                        Console.WriteLine("컴퓨터의 선택: 홀");
                        Console.WriteLine("패배!");
                        break;
                    }
                }

                if (a == "홀")
                {
                    if (i % 2 != 0)
                    {
                        win++;
                        Console.WriteLine("컴퓨터의 선택: 홀");
                        Console.WriteLine("승리!");
                        break;
                    }
                    else //사용자가 홀을 입력했을 때, 컴퓨터가 짝수를 골랐을 시
                    {
                        lose++;
                        Console.WriteLine("컴퓨터의 선택: 짝");
                        Console.WriteLine("패배!");
                        break;
                    }
                }
            }
        }


        static void RockPaper() //가위바위보 게임 반복으로 돌아가게
        {
            int wining = 0;
            int same = 0;
            int losing = 0;
            Console.Clear();
            game2(ref wining, ref same, ref losing);
            while (true)
            {
                Console.Write("다시 하시겠습니까? (Y/N): ");
                string b = Console.ReadLine();
                if (b == "y" || b == "Y")
                {
                    game2(ref wining, ref same, ref losing);
                    continue;
                }
                if (b == "n" || b == "N")
                {
                    Console.WriteLine("총 {0}번 비기고, {1}번 패배, {2}번 승리하셨습니다.", same, losing, wining);
                    Console.WriteLine("게임 선택 화면으로 돌아갑니다.");
                    Console.ReadKey();
                    Start();
                    break;
                }
                else
                {
                    Console.WriteLine("입력을 확인하지 못했습니다.");
                    continue;
                }
            }
        }
        static void game2(ref int wining, ref int same, ref int losing)
        {
            Random random = new Random();

            while (true)
            {
                int i = random.Next(1, 4); // 1~3을 컴퓨터가 선택함. 1=가위 2=바위 3=보

                Console.Write("가위 바위 보 중에 하나를 선택해주십시오: ");
                string a = Console.ReadLine();

                if (a == "가위")
                {
                    if (i == 1) // 컴퓨터가 가위를 냈을 시
                    {
                        same++; //비긴 횟수가 올라감
                        Console.WriteLine("컴퓨터의 선택: 가위");
                        Console.WriteLine("무승부!");
                        break;
                    }
                    if (i == 3) // 컴퓨터가 보를 골랐을 시
                    {
                        wining++; //승리 횟수가 올라감
                        Console.WriteLine("컴퓨터의 선택: 보");
                        Console.WriteLine("승리!");
                        break;
                    }
                    else // 컴퓨터가 바위를 냈을 시
                    {
                        losing++; //패배 횟수가 올라감
                        Console.WriteLine("컴퓨터의 선택: 바위");
                        Console.WriteLine("패배!");
                        break;
                    }
                }

                if (a == "바위")
                {
                    if (i == 2) // 컴퓨터가 바위를 냈을 시
                    {
                        same++; //비긴 횟수가 올라감
                        Console.WriteLine("컴퓨터의 선택: 바위");
                        Console.WriteLine("무승부!");
                        break;
                    }
                    if (i == 1) // 컴퓨터가 가위를 골랐을 시
                    {
                        wining++; //승리 횟수가 올라감
                        Console.WriteLine("컴퓨터의 선택: 가위");
                        Console.WriteLine("승리!");
                        break;
                    }
                    else
                    {
                        losing++;
                        Console.WriteLine("컴퓨터의 선택: 보");
                        Console.WriteLine("패배!");
                        break;
                    }
                }

                if (a == "보")
                {
                    if (i == 3) // 컴퓨터가 보를 냈을 시
                    {
                        same++; //비긴 횟수가 올라감
                        Console.WriteLine("컴퓨터의 선택: 보");
                        Console.WriteLine("무승부!");
                        break;
                    }
                    if (i == 2) // 컴퓨터가 바위를 골랐을 시
                    {
                        wining++; //승리 횟수가 올라감
                        Console.WriteLine("컴퓨터의 선택: 바위");
                        Console.WriteLine("승리!");
                        break;
                    }
                    else
                    {
                        losing++;
                        Console.WriteLine("컴퓨터의 선택: 가위");
                        Console.WriteLine("패배!");
                        break;
                    }
                }
            }
        }

        static void upanddown() //업앤다운 게임 반복으로 돌아가게
        {
            Console.Clear();
            randoms();
            while (true)
            {
                Console.Write("다시 하시겠습니까? (Y/N): ");
                string b = Console.ReadLine();
                if (b == "y" || b == "Y")
                {
                    Console.Clear();
                    randoms();
                    continue;
                }
                if (b == "n" || b == "N")
                {
                    Console.WriteLine("게임 선택 화면으로 돌아갑니다.");
                    Console.ReadKey();
                    Start();
                    break;
                }
                else
                {
                    Console.WriteLine("입력을 확인하지 못했습니다.");
                    continue;
                }
            }
        }
        static void randoms()
        {
            Random ran = new Random();
            int NumTry = 0; //시도 횟수
            int Answer = ran.Next(1, 501); //1부터 500까지의 랜덤 숫자
            while (true)
            {
                Console.Write("1~500의 숫자 중 하나를 입력해주세요: ");
                string input = Console.ReadLine();
                int guess = int.Parse(input);
                if (guess > Answer && guess <= 500) //추측이 정답보다 크고, 500이하여야 함
                {
                    NumTry++;
                    Console.WriteLine("더 작아야합니다.");
                    continue;
                }
                if (guess < Answer && guess >= 1) //추측이 정답보다 작고, 1이상이어야 함
                {
                    NumTry++;
                    Console.WriteLine("더 커야합니다.");
                    continue;
                }
                if (guess < 1 || guess > 500) //추측이 1보다 작거나 500보다 클 때
                {
                    Console.WriteLine("입력한 숫자가 지정된 범위에서 벗어났습니다."); //시도 횟수를 카운트하지 않음
                    continue;
                }
                if (guess == Answer)
                {
                    NumTry++;
                    Console.WriteLine("정답입니다!");
                    Console.WriteLine("총 {0}라운드를 진행하셨습니다.", NumTry);
                    break;
                }
            }
        }
    }
}
