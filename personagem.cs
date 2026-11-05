using System;

public class Personagem
{
    public string Nome;
    public int Vida;
    public int Nivel;

    public Personagem(string nome, int vida, int nivel)

{
    Nome = nome;
    Vida = vida;
    Nivel = nivel;
}
public void Apresentar()

{
    Console.WriteLine($"Nome; {Nome} | Vida: {Vida} | Nivel {Nivel}");
}
public void Atacar()

{
    Console.WriteLine($"{Nome} atacar!");
}
}