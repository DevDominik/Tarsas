using System;
using System.IO;
using System.Linq;

List<string> osvenyek = File.ReadAllLines("Datas\\osvenyek.txt").ToList();

List<int> dobasok = new List<int>();
foreach (string olvasottSor in File.ReadAllLines("Datas\\dobasok.txt").ToList())
{
	foreach (var item in olvasottSor.Split(' '))
	{
		dobasok.Add(int.Parse(item));
	}
}

Console.WriteLine(
	$"2. feladat:" +
	$"\nA dobások száma: {dobasok.Count()}" +
	$"\nAz ösvények száma: {osvenyek.Count()}\n"
);


int leghosszabbOsvenyIndex = 0;
for (int i = 1; i < osvenyek.Count; i++)
{
	if (osvenyek[i].Length > osvenyek[leghosszabbOsvenyIndex].Length)
	{
		leghosszabbOsvenyIndex = i;
	}
}
Console.WriteLine(
	$"3. feladat:\n" +
	$"Az egyik leghosszab a(z) {leghosszabbOsvenyIndex + 1}. ösvény, hossza: {osvenyek[leghosszabbOsvenyIndex].Length}\n"
);

Console.WriteLine("4. feladat:");
Console.Write("Adja meg egy ösvény sorszámát: ");
int osvenyBeolvasott = int.Parse(Console.ReadLine());
if (osvenyBeolvasott < 1)
{
	osvenyBeolvasott = 1;
}
else if (osvenyBeolvasott > osvenyek.Count())
{
	osvenyBeolvasott = osvenyek.Count();
}
Console.Write("Adja meg a játékosok számát: ");
int jatekosokBeolvasott = int.Parse(Console.ReadLine());
if (jatekosokBeolvasott > 5)
{
	jatekosokBeolvasott = 5;
}
else if (jatekosokBeolvasott < 2)
{
	jatekosokBeolvasott = 2;
}

Dictionary<char, int> statisztika = new Dictionary<char, int>();

foreach (char item in osvenyek[osvenyBeolvasott - 1])
{
	if (statisztika.ContainsKey(item))
	{
		statisztika[item] += 1;
	}
	else
	{
		statisztika[item] = 1;
	}
}
Console.WriteLine("");
Console.WriteLine("5. feladat:");
foreach (var item in statisztika)
{
    Console.WriteLine($"{item.Key}: {item.Value} darab");
}
Console.WriteLine("");

Dictionary<int, int> jatekosok = new Dictionary<int, int>();
for (int i = 1; i < jatekosokBeolvasott + 1; i++)
{
	jatekosok[i] = 0;
}
int kor = 1;
int jelenlegiJatekos = 1;
int dobas;
while (true)
{
	foreach (var item in jatekosok)
	{
		
		if (jelenlegiJatekos < jatekosokBeolvasott)
		{
			jelenlegiJatekos++;
		}
		else
		{
			jelenlegiJatekos = 1;
		}
	}
}

int legtovabbJutott = 1;


foreach (var item in jatekosok)
{
	if (item.Value > jatekosok[legtovabbJutott])
	{
		legtovabbJutott = item.Key;
	}
}

Console.WriteLine(
	$"7. feladat:\n" +
	$"A játék a(z) {kor}. körben fejeződött be. A legtávolabb jutó(k) száma: {legtovabbJutott}"
);