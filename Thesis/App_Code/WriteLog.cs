using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using thesis.bll;
using thesis.model;

/// <summary>
///WriteLog 的摘要说明
/// </summary>
public class WriteLog
{
    public WriteLog()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static void WriteLogWRX(int userid, string username, string log)
    {
        OperationLogBll olBll = new OperationLogBll();
        OperationLog oLog = new OperationLog();
        oLog.SPECIES12_ID = userid; ;
        oLog.RQSJ = DateTime.Now;
        oLog.NR = username + log;
        oLog.ENR = "empty";
        olBll.Add(oLog);
    }
}
