using System;
using IMR;

public class SysComRender : DataRender<SysComModel>
{
    AppCommon common = MSingletonFactory.Get<AppCommon>();
    DataCmd cmd = null;
    Action action = null;
    Action<bool> baction = null;

    public override void cmdupdate()
    {
        base.cmdupdate();

        cmd = nextCmd();
        if (cmd == null)
            return;

        if (cmd.Cmd == SysComModel.CMD_ADDUPDATE)
        {
            action = cmd.Params[0] as Action;
            common.updateAction += action;
        }
        else if (cmd.Cmd == SysComModel.CMD_REMOVEUPDATE)
        {
            action = cmd.Params[0] as Action;
            common.updateAction -= action;
        }
        else if (cmd.Cmd == SysComModel.CMD_ADDFIXUPDATE)
        {
            action = cmd.Params[0] as Action;
            common.fixedupdateAction += action;
        }
        else if (cmd.Cmd == SysComModel.CMD_REMOVEFIXUPDATE)
        {
            action = cmd.Params[0] as Action;
            common.fixedupdateAction -= action;
        }
        else if (cmd.Cmd == SysComModel.CMD_ADDLATEUPDATE)
        {
            action = cmd.Params[0] as Action;
            common.lateupdateAction += action;
        }
        else if (cmd.Cmd == SysComModel.CMD_REMOVELATEUPDATE)
        {
            action = cmd.Params[0] as Action;
            common.lateupdateAction -= action;
        }
        else if (cmd.Cmd == SysComModel.CMD_ADDFOCUS)
        {
            baction = cmd.Params[0] as Action<bool>;
            common.focusAction += baction;
        }
        else if (cmd.Cmd == SysComModel.CMD_REMOVEFOCUS)
        {
            baction = cmd.Params[0] as Action<bool>;
            common.focusAction -= baction;
        }
        else if (cmd.Cmd == SysComModel.CMD_ADDPAUSE)
        {
            baction = cmd.Params[0] as Action<bool>;
            common.pauseAction += baction;
        }
        else if (cmd.Cmd == SysComModel.CMD_REMOVEPAUSE)
        {
            baction = cmd.Params[0] as Action<bool>;
            common.pauseAction -= baction;
        }
        else if (cmd.Cmd == SysComModel.CMD_ADDQUIT)
        {
            action = cmd.Params[0] as Action;
            common.quitAction += action;
        }
        else if (cmd.Cmd == SysComModel.CMD_REMOVEQUIT)
        {
            action = cmd.Params[0] as Action;
            common.quitAction -= action;
        }
    }
}
