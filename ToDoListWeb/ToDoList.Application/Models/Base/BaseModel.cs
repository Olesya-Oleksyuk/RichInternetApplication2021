using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using static ToDoList.CommonData.CommonData;

namespace ToDoList.Application.Models.Base
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public Exception Error { get; set; }
        public string ErrorInfo
        {
            get
            {
                if (Error != null)
                {
                    return Error.Message + (Error.InnerException != null ? ", " + Error.InnerException.Message : "");
                }
                else
                {
                    return "";
                }

            }
        }
        public Result Result { get; set; }
        public BaseModel()
        {
            Result = Result.ok;
        }
        public BaseModel(Exception exp)
        {
            Error = exp;
            Result = Result.error;
        }
        public static BaseModel ErrorFormat(Exception exp)
        {
            return new BaseModel(exp);
        }
    }

    public static class BaseModelUtilities<T>
        where T : BaseModel, new()
    {
        public static T DataFormat(T CurrentData)
        {
            CurrentData.Result = Result.ok;
            return CurrentData;
        }

        public static T ErrorFormat(Exception exp)
        {
            return new T() { Error = exp, Result = Result.error };
        }
    }
}
