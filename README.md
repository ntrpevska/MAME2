## MAME2

Создадовме спој од две игри насловен како „МАМЕ2“. Првата од двете игри е добро-познатата логичка игра “Minesweeper”, која може да се најде на секој компјутер кој има “Microsoft Windows” за оперативен систем. Втората игра е математичката игра “Raindrops”, составен дел од мозочните игри на страната [Lumosity.com](http://www.lumosity.com).

Главната форма е Form1 и е прилично едноставна, составена од копче, две лабели и две слики. Секоја од игрите се почнува со клик или на соодветната лабела или на соодветната слика. Лабелите го имплементираат Mouse Hover евентот, како и Mouse Leave кои ја менуваат бојата на лабелата и ја враќаат во црна боја соодветно. Копчето служи за да објасни како да се користи апликацијата, како и имињата на нејзините автори.

![Main Form](http://i.imgur.com/U82Xd5d.png)

MineSweeper
===========
![Minesweeper](http://i.imgur.com/Z7Pp8mK.png)

Играта “MineSweeper” претставува квадратна табла со копчиња, позади кои се кријат одреден број на бомби. Целта во играта е корисникот да ги открие сите места, без да кликне на бомбите. За таа цел, тој ги користи бројките на отворените копчиња кои значат колку бомби се скриени околу тоа копче. Откако корисникот ја завршува играта со победа, се објавува времето кое му било потребно. Отворањето на полето се одвива со лев клик на маусот, а пак селектирањето на бомбите се одвива со користење на десен клик, при што се менува бојата на копчето и неможе да се кликне се додека не се притисне десниот клик повторно.

Form2 е формата во која се чува визуелната репрезентација на играта. Моделот на играта е класата Game.cs, во која се чуваат податоци за: дали полето е мина, колку мини има околу полето и слично и секако дво-димензионална матрица од полиња. Информацијата за секое поле е во класата Square.cs. Главна инспирација за кодот превземав од [C# Minesweeper Game](http://www.reflectionit.nl/Blog/2003/c-minesweeper-game). Сите функции се напишани од мене (Наташа Трпевска), а Роберт Андоновски е автор на функцијата OpenAround. При клик на "About the Game" се отвора Credits.cs, а при клик на "Help" се отвора Instructions.cs.

Raindrops
=========

![Raindrops1](http://i.imgur.com/39QaYxa.png)
![Raindrops2](http://i.imgur.com/rxwOdxg.png)

Играта “Raindrops” е игра во која е потребно корисникот да одговори на математичкиот израз испишан во капката пред таа да падне во водата. Од корисникот се бара брзина при одредување на резултатите. Резултатот се внесува преку нумеричките копчиња од тастатурата или со кликање на копчињата од прозорчето. На почеток на играта, корисникот има 3 животи. Живот се губи кога капката ќе падне во водата. Поените во играта се инкрементираат со секое уништување на капка, додека се декрементираат кога внесениот резултат е погрешен. На крајот од играта се прикажуваат освоените поени. Играта највеќе е наменета за деца, но не е ограничена на нив. Луѓето преку неа можат да ги вежбаат математичките операции и да го развиваат мозокот.

//Внеси твој опис на формата

Изработиле:
===========

Наташа Трпевска - 125030

Роберт Андоновски


