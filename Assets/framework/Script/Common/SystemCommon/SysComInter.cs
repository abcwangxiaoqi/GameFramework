using IMR;
using System;

public class SysComInter : Interaction<SysComModel>
{
    public void addUpdateAction(Action action)
    {
        if (action == null)
            return;

        sendCmd(SysComModel.CMD_ADDUPDATE, action);
    }
    public void removeUpdateAction(Action action)
    {
        if (action == null)
            return;

        sendCmd(SysComModel.CMD_REMOVEUPDATE, action);
    }

    public void addFixUpdateAction(Action action)
    {
        if (action == null)
            return;

        sendCmd(SysComModel.CMD_ADDFIXUPDATE, action);
    }
    public void removeFixUpdateAction(Action action)
    {
        if (action == null)
            return;

        sendCmd(SysComModel.CMD_REMOVEFIXUPDATE, action);
    }

    public void addLateUpdateAction(Action action)
    {
        if (action == null)
            return;

        sendCmd(SysComModel.CMD_ADDLATEUPDATE, action);
    }
    public void removeLateUpdateAction(Action action)
    {
        if (action == null)
            return;

        sendCmd(SysComModel.CMD_REMOVELATEUPDATE, action);
    }

    public void addFocusAction(Action<bool> action)
    {
        if (action == null)
            return;

        sendCmd(SysComModel.CMD_ADDFOCUS, action);
    }
    public void removeFocusAction(Action<bool> action)
    {
        if (action == null)
            return;

        sendCmd(SysComModel.CMD_REMOVEFOCUS, action);
    }

    public void addPauseAction(Action<bool> action)
    {
        if (action == null)
            return;

        sendCmd(SysComModel.CMD_ADDPAUSE, action);
    }
    public void removePauseAction(Action<bool> action)
    {
        if (action == null)
            return;

        sendCmd(SysComModel.CMD_REMOVEPAUSE, action);
    }

    public void addQuitAction(Action action)
    {
        if (action == null)
            return;

        sendCmd(SysComModel.CMD_ADDQUIT, action);
    }
    public void removeQuitAction(Action action)
    {
        if (action == null)
            return;

        sendCmd(SysComModel.CMD_REMOVEQUIT, action);
    }
}