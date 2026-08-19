public abstract class State : IState
{
    protected Fox fox;

    public State(Fox fox)
    {
        this.fox = fox;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
