namespace CS_Lab2
{
    enum GameState
    {
        Start,
        End
    }
    class Game
    {
        public int size;
        public Player cat;
        public Player mouse;
        public GameState state;
        public Game(int size)
        {
            this.size = size;
            cat = new Player("Cat");
            mouse = new Player("Mouse");
            state = GameState.Start;
        }
        private void DoCommand(char command, int steps)
        {
            switch (command)
            {
                case 'M': mouse.Move(steps);break;
                case 'C': cat.Move(steps);break;
            }
        }
        private int GetDistance()
        {
            return Math.Abs(mouse.location - cat.location);
        }
        public void Run()
        {
            int choice = 0;
            int steps = 0;
            while(state != GameState.End)
            {
                Console.WriteLine("Выберите пункт:\n" +
                    "1. M\n" +
                    "2. C\n" +
                    "3. P\n" +
                    "4. Конец игры");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        if (mouse.state == State.NotInGame) mouse.state = State.Playing;
                        Console.WriteLine("Введите кол-во шагов");
                        steps = Convert.ToInt32(Console.ReadLine());
                        DoCommand('M', steps);
                        if (GetDistance() == 0)
                        {
                            mouse.state = State.Loser;
                            cat.state = State.Winner;
                            state = GameState.End;
                        }
                        break;
                    case 2:
                        if (cat.state == State.NotInGame) cat.state = State.Playing;
                        Console.WriteLine("Введите кол-во шагов");
                        steps = Convert.ToInt32(Console.ReadLine());
                        DoCommand('C', steps);
                        if (GetDistance() == 0)
                        {
                            mouse.state = State.Loser;
                            cat.state = State.Winner;
                            state = GameState.End;
                        }
                        break;
                    case 3:
                        DoPrintCommand();
                        break;
                    case 4:
                        state = GameState.End;
                        break;
                }
            }
            Console.WriteLine($"Distance traveled: Mouse:{mouse.distanceTraveled} Cat:{cat.distanceTraveled}");
            if(cat.state != State.Winner)
            {
                Console.WriteLine("Mouse evaded Cat");
            }
            else
            {
                Console.WriteLine($"Mouse caught at: {mouse.location}");
            }
        }
        public void DoPrintCommand()
        {
            Console.WriteLine("Cat Mouse  Distance");
            Console.WriteLine($"{cat.location}\t{mouse.location}\t\t{GetDistance()}");
        }
    }
}
