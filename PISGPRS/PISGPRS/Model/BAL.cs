// <copyright file="BAL.cs" company="Sirveen Control System">
// Copyright (c) 2014 All Rights Reserved
// <author>Swati P</author>
// <date>12/02/2016 13:15 </date>
// <summary>This class is Business access layer which will communicate with database</summary>
// </copyright>

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace PISGPRS
{
    public class BAL
    {
        #region Member variables
        DataTable dt = new DataTable();
        string syntax = string.Empty;
        int result = 0;
        #endregion

        #region TRAIN DETAILS
        /// <summary>
        /// Get all the train details from database
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllTrainDetails()
        {
            try
            {
                syntax = "SELECT TrainID, TrainNo, TrainName, NoOfCoaches,Source,Destination,Distance,FromTime,ToTime,NoOfHours,Via  FROM Train";
                dt = DbConnection.GetData(syntax);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return dt;
        }

        /// <summary>
        /// Get the train details based on TrainID
        /// </summary>
        /// <param name="trainId"></param>
        /// <returns></returns>
        public DataTable GetTrainDetailsByTrainID(int trainId)
        {
            try
            {
                syntax = "SELECT TrainID, TrainNo, TrainName, NoOfCoaches,Source,Destination,Distance FROM Train where [TrainID]=" + trainId;
                dt = DbConnection.GetData(syntax);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return dt;
        }

        /// <summary>
        /// Save Train information into database
        /// </summary>
        /// <param name="operation">Insert=1, Update=2, Delete=3</param>
        /// <param name="trainId">trainId</param>
        /// <param name="trainno">Train No</param>
        /// <param name="trainname">Train Name</param>
        /// <param name="noofCoaches">No of Train coaches</param>
        /// <param name="source">source</param>
        /// <param name="destination">destination</param>
        /// <param name="distance">Distance from Source to Destination</param>
        /// <param name="fromTime">Train Start Time</param>
        /// <param name="toTime">Train End Time</param>
        /// <param name="noOfHours">Train run time</param>
        /// <param name="via">via Station</param>
        /// <returns>result of save operation </returns>
        public int SaveTrainDetails(int operation, int trainId, string trainno, string trainname, int noofCoaches,
            string source, string destination, int distance, string fromTime, string toTime, int noOfHours, string via)
        {
            try
            {
                if (operation == 1)
                {                    
                    syntax = "INSERT INTO Train ([TrainNo],[TrainName],[NoOfCoaches],[Source],[Destination],[Distance],[FromTime],";
                    syntax = syntax + "[ToTime],[NoOfHours],[Via]) values ('" + trainno + "','" + trainname + "'," + noofCoaches + ",'";
                    syntax = syntax + source + "','" + destination + "'," + distance + ",'" + fromTime + "','" + toTime + "',";
                    syntax = syntax + noOfHours + ",'" + via + "')";
                }
                else if (operation == 2)
                {
                    syntax = "UPDATE Train SET [TrainNo]='" + trainno + "',[TrainName]='" + trainname + "', [NoOfCoaches]=" + noofCoaches;
                    syntax = syntax + ", [Source]='" + source + "',[Destination]='" + destination + "',[Distance]=" + distance;
                    syntax = syntax + ",[FromTime]='" + fromTime + "',[ToTime]='" + toTime + "',[NoOfHours]=" + noOfHours;
                    syntax = syntax + ",[Via]='" + via + "' where [TrainID]=" + trainId;
                }
                else if (operation == 3)
                {
                    syntax = "DELETE FROM Coach where [TrainID]=" + trainId;
                    result = DbConnection.CreateUpdateDelete(syntax);
                    syntax = "DELETE FROM Train where [TrainID]=" + trainId;
                }
                result = DbConnection.CreateUpdateDelete(syntax);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return result;
        }
        #endregion

        #region COACH DETAILS

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TrainId"></param>
        /// <returns></returns>
        public DataTable GetCoachDetailsByTrainID(int TrainId)
        {
            try
            {
                syntax = "SELECT CoachID, CoachNo,TrainID,PISUnitID,SIMNo,HardwareID FROM Coach where TrainID=" + TrainId;
                dt = DbConnection.GetData(syntax);
                dt.Columns.Add("SentTime");
                dt.Columns.Add("Status");
                dt.Columns.Add("ResponseTime");
                dt.Columns.Add("Response");
                dt.Columns.Add("TrainNo");
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return dt;
        }

        public DataTable GetCoachDetailsByTrainIDForMessages(string trainNo, int trainId, string command)
        {
            DataTable dt1 = new DataTable();
            try
            {
                syntax = "SELECT CoachID, CoachNo,TrainID,SIMNo FROM Coach where TrainID=" + trainId;
                dt1 = DbConnection.GetData(syntax);
              dt1.Columns.Add("SentTime");
              dt1.Columns.Add("Status");
              dt1.Columns.Add("ResponseTime");
              dt1.Columns.Add("Response");
              dt1.Columns.Add("TrainNo");


              if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        DataTable ddd = GetCurrentUpdatesForResponse(trainNo, dt1.Rows[i]["SIMNo"].ToString(), command);

                        if (ddd != null)
                        {
                            if (ddd.Rows.Count > 0)
                            {
                                dt1.Rows[i]["Status"] = ddd.Rows[0]["Status"].ToString();

                                if (string.IsNullOrEmpty(ddd.Rows[0]["SentTime"].ToString()))
                                {
                                    dt1.Rows[i]["SentTime"] = string.Empty;
                                }
                                else
                                {
                                    DateTime dtSent = Convert.ToDateTime(ddd.Rows[0]["SentTime"]);
                                    dt1.Rows[i]["SentTime"] = dtSent.ToString("dd/MM/yyyy HH:mm:ss");
                                }
                               
                                dt1.Rows[i]["Response"] = ddd.Rows[0]["Response"].ToString();

                                if (string.IsNullOrEmpty(ddd.Rows[0]["ResponseTime"].ToString()))
                                {
                                    dt1.Rows[i]["ResponseTime"] = string.Empty;
                                }
                                else
                                {
                                    DateTime dtResponse = Convert.ToDateTime(ddd.Rows[0]["ResponseTime"]);
                                    dt1.Rows[i]["ResponseTime"] = dtResponse.ToString("dd/MM/yyyy HH:mm:ss");
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return dt1;
        }

        public DataTable GetCoachDetails(int coachId)
        {
            try
            {
                syntax = "SELECT CoachID, CoachNo,TrainID,PISUnitID,SIMNo,HardwareID FROM Coach where CoachID=" + coachId;
                dt = DbConnection.GetData(syntax);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return dt;
        }

        public string GetCoachNo(int coachID)
        {
            string CoachNo = string.Empty;
            try
            {
                syntax = "SELECT  CoachNo FROM Coach where CoachId=" + coachID;
                dt = DbConnection.GetData(syntax);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        CoachNo = dt.Rows[0]["CoachNo"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return CoachNo;
        }

        public Boolean CheckSIMNo(string SIMNo)
        {
            Boolean isExist = false;
            string CoachNo = string.Empty;
            try
            {
                syntax = "SELECT  SIMNo FROM Coach where SIMNo='" + SIMNo + "'";
                dt = DbConnection.GetData(syntax);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        isExist = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return isExist;
        }

        public int SaveCoachDetails(int operation, int coachId, string coachNo, int trainId, string trainNo, string pisunitid,
            string simno, string hardwareid)
        {
            try
            {
                if (operation == 1)
                {
                    syntax = "INSERT INTO Coach ([CoachNo],[TrainID],[PISUnitID],[SIMNo],[HardwareID]) values ('";
                    syntax = syntax + coachNo + "'," + trainId + ",'" + pisunitid + "','" + simno + "','" + hardwareid + "')";
                }
                else if (operation == 2)
                {
                    syntax = "Update Coach SET [CoachNo]='" + coachNo + "',[TrainID]=" + trainId + ",[PISUnitID]='" + pisunitid + "',[SIMNo]='";
                    syntax = syntax + simno + "',[HardwareID]='" + hardwareid + "' where CoachID=" + coachId;
                }
                else if (operation == 3)
                {
                    syntax = "DELETE FROM Coach where [CoachID]=" + coachId;
                }
                result = DbConnection.CreateUpdateDelete(syntax);

                #region LATEST STATUS
                string Status = string.Empty;
                string Response = string.Empty;

                if (coachId == 0)
                {
                    syntax = "select CoachId from Coach where TrainId=" + trainId + " and CoachNo='" + coachNo + "'";
                    dt = DbConnection.GetData(syntax);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            coachId = Convert.ToInt32(dt.Rows[0]["CoachID"].ToString());
                        }
                    }
                }

               
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return result;
        }
        #endregion

        #region USER DETAILS
        public DataTable GetUserDetails(int UserId)
        {
            try
            {
                syntax = "SELECT UserID, FirstName, LastName, Role, ContactNo,UserName,Password FROM Users where UserId=" + UserId;
                dt = DbConnection.GetData(syntax);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return dt;
        }

        public int SaveUser(int operation, int userId, string firstName, string lastName, string role, string contactno,
            string username, string password)
        {
            try
            {
                if (operation == 1)
                {
                    syntax = "INSERT INTO Users ( [FirstName], [LastName], [Role], [ContactNo], [UserName], [Password] ,[DisplayStatus]) values ('";
                    syntax = syntax + firstName + "','" + lastName + "','" + role + "','" + contactno + "','" + username + "','" + password + "',1)";

                }
                else if (operation == 2)
                {
                    syntax = "UPDATE Users SET [FirstName] = '" + firstName + "', [LastName] = '" + lastName + "', [Role] = '" + role + "', [ContactNo] = '";
                    syntax = syntax + contactno + "', [UserName] = '" + username + "', [Password] = '" + password + "'WHERE (([UserID])=" + userId + ")";

                }
                else if (operation == 3)
                {
                    syntax = "DELETE FROM Users WHERE (([UserID])=" + userId + ")";

                }
                result = DbConnection.CreateUpdateDelete(syntax);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return result;
        }

        public DataTable GetUserDetailsByUserName(string UserName)
        {
            try
            {
                syntax = "SELECT UserID, FirstName, LastName, Role, ContactNo,UserName,Password FROM Users where UserName=" + UserName;
                dt = DbConnection.GetData(syntax);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return dt;
        }

        public DataTable GetAllUserDetails()
        {
            try
            {
                syntax = "SELECT UserID, FirstName, LastName, Role, ContactNo,UserName,Password FROM Users where [DisplayStatus]=true";
                dt = DbConnection.GetData(syntax);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return dt;
        }

        public DataTable GetUserDetails()
        {
            try
            {
                syntax = "SELECT UserID, FirstName, LastName, Role, ContactNo,UserName,Password FROM Users ";
                dt = DbConnection.GetData(syntax);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return dt;
        }

        public List<UserModel> BindUserName()
        {
            List<UserModel> listUsers = new List<UserModel>();
            try
            {
                DataTable dt = new DataTable();
                dt = GetUserDetails();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            UserModel um = new UserModel();
                            um.FirstName = dt.Rows[i]["FirstName"].ToString();
                            um.UserName = dt.Rows[i]["UserName"].ToString();
                            um.Password = dt.Rows[i]["Password"].ToString();
                            um.ContactNo = dt.Rows[i]["ContactNo"].ToString();
                            um.Role = dt.Rows[i]["Role"].ToString();
                            listUsers.Add(um);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return listUsers;
        }

        public int ResetPassword(string username, string password)
        {
            try
            {
                syntax = "UPDATE Users SET  [Password] = '" + password + "'WHERE (([UserName])='" + username + "')";

                result = DbConnection.CreateUpdateDelete(syntax);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return result;
        }



        #endregion

        #region SMS DETAILS
        public DataTable GetSentSMSDetails()
        {
            try
            {
                syntax = "SELECT SMSDate, SMSTime,CoachNo, SIMNo, Message FROM SMSDetails where [MsgType]='" + BaseClass.MessageType.Request.ToString() + "' order by SMSDate, SMSTime desc ";
                dt = DbConnection.GetData(syntax);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return dt;
        }

        public DataTable GetReceivedSMSDetails()
        {
            try
            {
                syntax = "SELECT SMSDate, SMSTime,CoachNo, SIMNo, Message FROM SMSDetails where [MsgType]='" + BaseClass.MessageType.Response.ToString() + "' order by SMSDate, SMSTime desc";
                dt = DbConnection.GetData(syntax);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return dt;
        }

        public DataTable GetSMSDetailsBySIMNo(string SimNo)
        {
            try
            {
                syntax = "SELECT * FROM SMSDetails where SIMNo='" + SimNo + "'";
                dt = DbConnection.GetData(syntax);

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return dt;
        }

        public int SaveSMSDetails(int operation, int Id,string trainNo, int coachId,  string MsgType, string command, DateTime SMSDate, DateTime SMSTime, string CoachNo,
           string SIMNo, string Message, string status, DateTime? responseTime, string responseMsg)
        {
            try
            {
                #region Get CoachId and CoachNo
                
                CoachNo = GetCoachNo(coachId);
                #endregion
                                
                    syntax = "INSERT INTO SMSDetails ( [MsgType],  [SMSDate], [SMSTime],[CoachNo], [SIMNo], [Message],[Status] ) values ('";
                    syntax = syntax + MsgType + "','" + SMSDate + "','" + SMSTime + "','" + CoachNo + "','" + SIMNo + "','" + Message + "','" + status + "')";
                                             
                result = DbConnection.CreateUpdateDelete(syntax);

                SaveCurrentSMSDetails(operation, Id, trainNo, coachId, SIMNo, command, SMSDate, status, responseTime, responseMsg);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return result;
        }

        #endregion

        #region LATEST STATUS
      

        /// <summary>
        /// Save new messages
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="Id"></param>
        /// <param name="trainNo"></param>
        /// <param name="coachId"></param>
        /// <param name="SIMNo"></param>
        /// <param name="command"></param>
        /// <param name="sentDt"></param>
        /// <param name="Status"></param>
        /// <param name="responseDt"></param>
        /// <param name="Response"></param>
        /// <returns></returns>
        public int SaveCurrentSMSDetails(int operation,int Id, string trainNo, int coachId, string SIMNo,string command, DateTime sentDt,
            string Status, DateTime? responseDt, string Response)
        {
            try
            {
                string dtR = string.Empty;
                if (operation == 1)
                {
                    dtR = sentDt.ToString("MM/dd/yyyy HH:mm:ss");
                    dt = GetCurrentUpdates(trainNo, SIMNo, command);
                    //syntax = "INSERT INTO CurrentUpdates ( [TrainNo],[CoachId],[SIMNo],[Command],[SentDate],[Status],[ResponseDate],[Response]   ) values ('";
                    //syntax = syntax + trainNo + "'," + coachId + ",'" + SIMNo + "','" + command + "','" + sentDt + "','" + Status + "','" + responseDt + "','" + Response+ "')";

                    syntax = "INSERT INTO CurrentUpdates ( [TrainNo],[CoachId],[SIMNo],[Command],[SentTime],[Status],[Response]   ) values ('";
                    syntax = syntax + trainNo + "'," + coachId + ",'" + SIMNo + "','" + command + "','" + sentDt + "','" + Status + "','" + Response + "')";

                }
                else if (operation == 2)
                {
                   dt= GetCurrentUpdates(trainNo, SIMNo, command);

                   if(dt.Rows.Count>0)
                   {
                       for(int i=0; i<dt.Rows.Count; i++)
                       {
                           if (dt.Rows[i]["Status"].ToString() == "Msg Sent" && dt.Rows[i]["Response"].ToString() == "Waiting ..")
                           {
                                dtR = responseDt.Value.ToString("MM/dd/yyyy HH:mm:ss");
                               syntax = "UPDATE CurrentUpdates SET [ResponseTime] ='" + dtR + "', [Response] = '" + Response;
                               //syntax = syntax + "' WHERE (TrainNo='" + trainNo + "' and SIMNo='" + SIMNo + "' and command='" + command + "')";
                               syntax = syntax + "' WHERE (CurrentUpdateID=" + dt.Rows[i]["CurrentUpdateID"].ToString() + ")";
                             
                               break;
                           }   
                       }
                   }
                }

                result = DbConnection.CreateUpdateDelete(syntax);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return result;
        }

        /// <summary>
        /// Get current new message details
        /// </summary>
        /// <param name="trainNo"></param>
        /// <param name="SIMNo"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public DataTable GetCurrentUpdates(string trainNo, string SIMNo, string command)
        {
            try
            {
                string str = "Waiting ..";
                if (string.IsNullOrEmpty(trainNo) && string.IsNullOrEmpty(command))
                {                    
                    syntax = "select top 1 * from CurrentUpdates WHERE ( SIMNo='" + SIMNo + "' and Response='" + str + "') order by SentTime desc";
                    //dt = DbConnection.GetData(syntax);
                }
                else
                {
                   // syntax = "select top 1 * from CurrentUpdates WHERE (TrainNo='" + trainNo + "' and SIMNo='" + SIMNo + "' and command='" + command + "') order by SentTime desc";
                    syntax = "select top 1 * from CurrentUpdates WHERE (TrainNo='" + trainNo + "' and SIMNo='" + SIMNo;
                    syntax = syntax + "' and command='" + command + "' and Response='" + str + "') order by SentTime desc";
                   
                }
                     dt = DbConnection.GetData(syntax);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return dt;
        }

        public DataTable GetCurrentUpdatesForResponse(string trainNo, string SIMNo, string command)
        {
            try
            {
                string str = "Waiting ..";
                if (string.IsNullOrEmpty(trainNo) && string.IsNullOrEmpty(command))
                {
                    syntax = "select top 1 * from CurrentUpdates WHERE ( SIMNo='" + SIMNo + "' and Response='" + str + "') order by SentTime desc";                    
                }
                else
                {
                     syntax = "select top 1 * from CurrentUpdates WHERE (TrainNo='" + trainNo + "' and SIMNo='" + SIMNo + "' and command='" + command + "') order by SentTime desc";
                    //syntax = "select top 1 * from CurrentUpdates WHERE (TrainNo='" + trainNo + "' and SIMNo='" + SIMNo;
                    //syntax = syntax + "' and command='" + command + "' and Response='" + str + "') order by SentTime desc";

                }
                dt = DbConnection.GetData(syntax);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return dt;
        }

        #endregion

        public DataTable AutoNumberedTable(DataTable SourceTable)
        {

            DataTable ResultTable = new DataTable();
            try
            {
                DataColumn AutoNumberColumn = new DataColumn();

                AutoNumberColumn.ColumnName = "SNo";

                AutoNumberColumn.DataType = typeof(int);

                //AutoNumberColumn.AutoIncrement = true;

                //AutoNumberColumn.AutoIncrementSeed = 1;

                //AutoNumberColumn.AutoIncrementStep = 1;

                ResultTable.Columns.Add(AutoNumberColumn);

                ResultTable.Merge(SourceTable);

                for (int i = 0; i < ResultTable.Rows.Count; i++)
                {
                    ResultTable.Rows[i]["SNo"] = i + 1;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return ResultTable;
        }
    }


    public class UserModel
    {
        #region MEMBER VARIABLES
        string _UserName;
        string _Password;
        string _FirstName;
        string _LastName;        
        string _ContactNo;
        string _Role;
        #endregion

        #region PROPERTIES

        public string Role
        {
            get { return _Role; }
            set { _Role = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string ContactNo
        {
            get { return _ContactNo; }
            set { _ContactNo = value; }
        }

        #endregion
    }
}
