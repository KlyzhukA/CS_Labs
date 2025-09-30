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
                case 'M': 
                    mouse.Move(steps,size);
                    break;
                case 'C': 
                    cat.Move(steps,size);
                    break;
            }
            if (GetDistance() == 0)
            {
                mouse.state = State.Loser;
                cat.state = State.Winner;
                state = GameState.End;
            }
        }
        private int GetDistance()
        {
            return Math.Abs(mouse.location - cat.location);
        }
        public void Run()
        {
            char commandLetter;
            int steps = 0;
            while(state != GameState.End)
            {
                using (StreamReader reader = new StreamReader(inputFilePath))
                {
                    size = Convert.ToInt32(reader.ReadLine());
                    string line;
                    while((line = reader.ReadLine())!= null)
                    {
                        string[] str = line.Trim().Split(" ");
                        commandLetter = Convert.ToChar(str[0]);
                        switch (commandLetter)
                        {
                            case 'M' or 'C':
                                DoCommand(commandLetter, Convert.ToInt32(str[1]));
                                break;
                            case 'P':
                                DoPrintCommand();
                                break;
                        }
                    }
                    state = GameState.End;
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
            if (cat.state == State.NotInGame)
            {
                Console.WriteLine("Mouse       Cat        Distance");
                Console.WriteLine(mouse.location + "\t    " + "??" + "\t");
            }
            else if (mouse.state == State.NotInGame)
            {
                Console.WriteLine("Mouse       Cat        Distance");
                Console.WriteLine("??" + "\t    " + cat.location + "\t");
            }
            else
            {
                Console.WriteLine("Mouse       Cat        Distance");
                Console.WriteLine(mouse.location + "\t    " + cat.location + "\t" + GetDistance());

            }
        }
    }
}
