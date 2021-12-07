public class Submarine
{
    public int horizontalPosition = 0;
    public int verticalPosition = 0;
    public int aim = 0;
    public int CompositePosition => horizontalPosition * verticalPosition;


    public void Follow(Command command)
    {
        if (command.direction == "forward")
            horizontalPosition += command.distance;

        if (command.direction == "down")
            verticalPosition += command.distance;

        if (command.direction == "up")
            verticalPosition -= command.distance;
    }

    public void FollowWithAim(Command command)
    {
        if (command.direction == "forward")
        {
            horizontalPosition += command.distance;
            verticalPosition += (aim * command.distance);
        }

        if (command.direction == "down")
            aim += command.distance;

        if (command.direction == "up")
            aim -= command.distance;
    }


    public int GetCompositePosition(List<Command> commands)
    {
        var submarine = new Submarine();

        commands.ForEach(command => submarine.Follow(command));

        return submarine.CompositePosition;
    }

    public int GetCompositeAimPosition(List<Command> commands)
    {
        var submarine = new Submarine();

        commands.ForEach(command => submarine.FollowWithAim(command));

        return submarine.CompositePosition;
    }
}
    
public class Command
{
    public Command(string direction, int distance)
    {
        this.direction = direction;
        this.distance = distance;
    }
    public string direction = string.Empty;
    public int distance = 0;
}