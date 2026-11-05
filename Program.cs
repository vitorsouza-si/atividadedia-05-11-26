using System;
using System.Collections.Generic;

namespace MissaoRPG
{
    public class Personagem
    {
        private string _nome;
        private int _vida;
        private int _nivel;

        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }

        public int Vida
        {
            get => _vida;
            set
            {
                if (value > 100)
                    _vida = 100;
                else if (value < 0)
                    _vida = 0;
                else
                    _vida = value;
            }
        }

        public int Nivel
        {
            get => _nivel;
            set => _nivel = value;
        }

        public Personagem(string nome, int vida, int nivel)
        {
            Nome = nome;
            Vida = vida;
            Nivel = nivel;
        }

        public virtual void Apresentar()
        {
            Console.Write($"Nome: {Nome} | Vida: {Vida} | Nível: {Nivel}");
        }

        public virtual void Atacar()
        {
            if (Vida == 0)
            {
                Console.WriteLine($"{Nome} está sem vida e não pode atacar.");
                return;
            }

            Console.WriteLine($"{Nome} realiza um ataque básico.");
        }
    }

    // Classe Filha: Guerreiro
    public class Guerreiro : Personagem
    {
        public string Arma { get; set; }

        public Guerreiro(string nome, int vida, int nivel, string arma) 
            : base(nome, vida, nivel)
        {
            Arma = arma;
        }

        public override void Apresentar()
        {
            Console.Write($"Nome: {Nome} | Classe: Guerreiro | Vida: {Vida} | Nível: {Nivel} | Arma: {Arma}");
            Console.WriteLine();
        }

        public override void Atacar()
        {
            if (Vida == 0)
            {
                Console.WriteLine($"{Nome} está sem vida e não pode atacar.");
                return;
            }

            Console.WriteLine($"{Nome} ataca com o {Arma} e causa dano físico!");
        }
    }

    // Classe Filha: Mago
    public class Mago : Personagem
    {
        public string Elemento { get; set; }

        public Mago(string nome, int vida, int nivel, string elemento) 
            : base(nome, vida, nivel)
        {
            Elemento = elemento;
        }

        public override void Apresentar()
        {
            Console.Write($"Nome: {Nome} | Classe: Mago | Vida: {Vida} | Nível: {Nivel} | Elemento: {Elemento}");
            Console.WriteLine();
        }

        public override void Atacar()
        {
            if (Vida == 0)
            {
                Console.WriteLine($"{Nome} está sem vida e não pode atacar.");
                return;
            }

            Console.WriteLine($"{Nome} lança uma magia de {Elemento}!");
        }
    }

    // Desafio Extra: Arqueiro
    public class Arqueiro : Personagem
    {
        public int QtdFlechas { get; set; }

        public Arqueiro(string nome, int vida, int nivel, int qtdFlechas) 
            : base(nome, vida, nivel)
        {
            QtdFlechas = qtdFlechas;
        }

        public override void Apresentar()
        {
            Console.Write($"Nome: {Nome} | Classe: Arqueiro | Vida: {Vida} | Nível: {Nivel} | Flechas: {QtdFlechas}");
            Console.WriteLine();
        }

        public override void Atacar()
        {
            if (Vida == 0)
            {
                Console.WriteLine($"{Nome} está sem vida e não pode atacar.");
                return;
            }

            if (QtdFlechas > 0)
            {
                QtdFlechas--;
                Console.WriteLine($"{Nome} dispara uma flecha precisa! (Restam {QtdFlechas} flechas)");
            }
            else
            {
                Console.WriteLine($"{Nome} tentou atacar, mas está sem flechas!");
            }
        }
    }

    // Classe Principal com os Testes (Main)
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SAÍDA ESPERADA NO TESTE DA VIDA");
            Personagem testeAlto = new Personagem("HeroiAlto", 150, 1);
            Personagem testeBaixo = new Personagem("HeroiBaixo", -20, 1);
            Console.WriteLine($"Personagem criado com vida 150 -> vida registrada: {testeAlto.Vida}");
            Console.WriteLine($"Personagem criado com vida -20 -> vida registrada: {testeBaixo.Vida}");
            Console.WriteLine();

            List<Personagem> herois = new List<Personagem>
            {
                new Guerreiro("Thorin", 100, 5, "Machado de Batalha"),
                new Mago("Merlin", 80, 7, "Fogo"),
                new Guerreiro("Brutus", 0, 3, "Espada Longa"),
                new Arqueiro("Legolas", 90, 6, 15)
            };

            Console.WriteLine("=== PERSONAGENS ===");
            foreach (Personagem heroi in herois)
            {
                heroi.Apresentar();
            }

            Console.WriteLine();

            Console.WriteLine("=== BATALHA ===");
            foreach (Personagem heroi in herois)
            {
                heroi.Atacar();
            }
        }
    }
}