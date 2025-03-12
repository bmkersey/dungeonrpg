using Godot;
using System;

public partial class PlayerDashState : Node
{
  private Player characterNode;
  [Export] private Timer dashTimerNode;
  public override void _Ready()
  {
    characterNode = GetOwner<Player>();
    dashTimerNode.Timeout += HandleDashTimeout;
  }

    // public override void _PhysicsProcess(double delta)
    // {
    //   if (characterNode.direction != Vector2.Zero)
    //   {
    //     characterNode.stateMachineNode.SwitchState<PlayerMoveState>();
    //   }
    //   else if (characterNode.direction == Vector2.Zero)
    //   {
    //     characterNode.stateMachineNode.SwitchState<PlayerIdleState>();
    //   }
    // }
    public override void _Notification(int what)
    {
      base._Notification(what);

      if (what == 5001)
      {
        
        characterNode.animPlayerNode.Play(GameConstants.DASH_ANIM);
        dashTimerNode.Start();
      }
      
    }

    private void HandleDashTimeout()
    {
      characterNode.stateMachineNode.SwitchState<PlayerIdleState>();
    }
}
