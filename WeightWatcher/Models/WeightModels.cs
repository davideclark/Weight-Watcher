using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Mvc;
using System.Web.Security;
namespace MvcApplication1.Models
{
    public class WeightModel
    {
        
        public List<WeightRecord> weightrecords = new List<WeightRecord>();

        //
        // Query Methods
        public List<WeightRecord> GetWeights(string userID, int? weightId, int? pageIndex, int? pageSize, string orderBy, out int totalCount )
        {

            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {

                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Weights"].ConnectionString);
                command = new SqlCommand("usp_SelectWeights", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter totalCountParam = command.Parameters.Add("@totalCount", SqlDbType.Int);
                totalCountParam.Direction = ParameterDirection.Output;
                totalCountParam.Value = 10;

                SqlParameter userNameParam = command.Parameters.Add("@userName", SqlDbType.NVarChar);
                userNameParam.Direction = ParameterDirection.Input;
                if (userID == string.Empty)
                    userID = null;
                userNameParam.Value = userID;

                SqlParameter weightIdParam = command.Parameters.Add("@weightID", SqlDbType.Int);
                weightIdParam.Direction = ParameterDirection.Input;
                weightIdParam.Value = weightId;

                SqlParameter pageIndexParam = command.Parameters.Add("@pageIndex", SqlDbType.Int);
                pageIndexParam.Direction = ParameterDirection.Input;
                pageIndexParam.Value = pageIndex;
                
                SqlParameter pageSizeParam = command.Parameters.Add("@pageSize", SqlDbType.Int);
                pageSizeParam.Direction = ParameterDirection.Input;
                pageSizeParam.Value = pageSize;

                SqlParameter orderByParam = command.Parameters.Add("@orderBy", SqlDbType.VarChar);
                orderByParam.Direction = ParameterDirection.Input;
                orderByParam.Value = orderBy;

                connection.Open();

                SqlDataReader r = command.ExecuteReader();

                while (r.Read())
                {
                    WeightRecord newWeightRec = new WeightRecord();
                    newWeightRec.UserName = Convert.ToString(r["userName"]);
                    newWeightRec.Weight = Convert.ToDouble(r["weightKg"]);
                    newWeightRec.Date = Convert.ToDateTime(r["date"]);
                    newWeightRec.WeightRecordID = Convert.ToInt32(r["weightId"]);
                    weightrecords.Add(newWeightRec);
                }
                connection.Close(); // You have to close the output stream before you can read output parameters
                totalCount = -1;
                if (totalCountParam.Value != null)
                {
                    totalCount = (int)totalCountParam.Value;
                }


            }
            catch (Exception e)
            {
                throw new Exception("Error getting Sortie  " + e.Message.ToString(), e);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }

                if (command != null)
                {
                    command.Dispose();
                }
            }

            return weightrecords;
        }

        // Insert/Delete Methods
        public int Add(WeightRecord weight)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Weights"].ConnectionString);
                command = new SqlCommand("usp_InsertWeight", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter userNameParam = command.Parameters.Add("@userName", SqlDbType.NVarChar);
                userNameParam.Direction = ParameterDirection.Input;
                userNameParam.Value = weight.UserName;

                SqlParameter weightIdParam = command.Parameters.Add("@weightKg", SqlDbType.Int);
                weightIdParam.Direction = ParameterDirection.Input;
                weightIdParam.Value = weight.Weight;

                SqlParameter weightDateParam = command.Parameters.Add("@date", SqlDbType.DateTime);
                weightDateParam.Direction = ParameterDirection.Input;
                weightDateParam.Value = weight.Date;

                SqlParameter returnParam = command.Parameters.Add("", SqlDbType.DateTime);
                returnParam.Direction = ParameterDirection.ReturnValue;

                connection.Open();

                command.ExecuteScalar();
                int r = (int)returnParam.Value;
                return r;
            }
            catch (Exception e)
            {
                throw new Exception("Error getting Sortie  " + e.Message.ToString(), e);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }

                if (command != null)
                {
                    command.Dispose();
                }
            }
        }

        public void Delete(int weightId)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Weights"].ConnectionString);
                command = new SqlCommand("usp_DeleteWeight", connection);
                command.CommandType = CommandType.StoredProcedure;


                SqlParameter weightIdParam = command.Parameters.Add("@weightId", SqlDbType.Int);
                weightIdParam.Direction = ParameterDirection.Input;
                weightIdParam.Value = weightId;

                connection.Open();

                command.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception("Error getting Sortie  " + e.Message.ToString(), e);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }

                if (command != null)
                {
                    command.Dispose();
                }
            }
        }


        public void Update(WeightRecord weight)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Weights"].ConnectionString);
                command = new SqlCommand("usp_UpdateWeight", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter userNameParam = command.Parameters.Add("@userName", SqlDbType.NVarChar);
                userNameParam.Direction = ParameterDirection.Input;
                userNameParam.Value = weight.UserName;

                SqlParameter weightIdParam = command.Parameters.Add("@weightId", SqlDbType.Int);
                weightIdParam.Direction = ParameterDirection.Input;
                weightIdParam.Value = weight.WeightRecordID;

                SqlParameter dateParam = command.Parameters.Add("@date", SqlDbType.DateTime);
                dateParam.Direction = ParameterDirection.Input;
                dateParam.Value = weight.Date;

                SqlParameter weightKgParam = command.Parameters.Add("@weightKg", SqlDbType.Float);
                weightKgParam.Direction = ParameterDirection.Input;
                weightKgParam.Value = weight.Weight;

                connection.Open();

                command.ExecuteScalar();
                
            }
            catch (Exception e)
            {
                throw new Exception("Error getting Sortie  " + e.Message.ToString(), e);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }

                if (command != null)
                {
                    command.Dispose();
                }
            }

        }




    }

    //Restrict data binding to just weight and date
    [Bind(Include="Weight, Date")]
    public class WeightRecord
    {
        private int weightRecordID;

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public int WeightRecordID
        {
            get { return weightRecordID; }
            set { weightRecordID = value; }
        }

        private double _weight;

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public WeightRecord()
        {
        }

        public WeightRecord(double weight, DateTime date, int id, string userName)
        {
            WeightRecordID = id;
            _weight = weight;
            _date = date;
            UserName = userName;
        }

        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }
        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (string.IsNullOrEmpty(userName))
                yield return new RuleViolation("User name is required", "userName");

            // TODO need to add check for valid date .............. is the done using a string or a datetime
            //if (!DateValidator.IsDateValid(date))
            //    yield return new RuleViolation("User name is not valid");

            if (_weight < 0 || Weight > 500)
                yield return new RuleViolation("Weight is out of acceptable range", "weight");
            
            yield break;
        }
        public void Validate()
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving");
        }


    }

    public class RuleViolation
    {
        public string ErrorMessage { get; private set; }
        public string PropertyName { get; private set; }
        public RuleViolation(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public RuleViolation(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }

    }
    
    static public class UserNameValidator
    {
        public static bool IsValidUserName(string userName)
        {
            MembershipUserCollection members = Membership.FindUsersByName(userName);
            if (members.Count > 0)
                return true;
            else
                return false;
        }
    
}
}