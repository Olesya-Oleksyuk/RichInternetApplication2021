using System;
using System.ComponentModel;

namespace ToDoList.CommonData
{
    public static class CommonData
    {
        public enum StatusType
        {
            [Description("Сделать")]
            ToDo,
            [Description("В работе")]
            InProgess,
            [Description("Завершен")]
            Completed
        }
        /// <summary>
        /// Ответы
        /// </summary>
        public enum Result
        {
            ok = 1,
            error = 0
        }
    }
}
