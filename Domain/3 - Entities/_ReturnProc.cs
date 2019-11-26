using System;

namespace Team17.Domain.Entities
{
    /// <summary>
    /// Returns execution of a Stored Procedure
    /// </summary>
    public class _ReturnProc : _EntityBase
    {
        /// <summary>
        /// If the Id is numeric this Property will be filled
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// If the Id is Uniqueidentifier (string) this Property will be filled
        /// </summary>
        public string GuidId { get; set; }

        /// <summary>
        /// OK / NOK
        /// </summary>
        public string Code { get; set; }

        public bool IsValid
        {
            get
            {
                if(Code == null)
                {
                    return false;
                }

                return Code.ToUpper().Equals("OK");
            }
        }

        /// <summary>
        /// Returns the value, after make all checks
        /// </summary>
        public string GetValue()
        {
            string ret = "";
            if (IsValid)
            {
                if (Guid.TryParse(GuidId, out Guid dummy))
                {
                    ret = GuidId;
                }
                else
                {
                    ret = Id.ToString();
                }
            }
            else
            {
                // Return Error Message
                if (!ErrorMsg.StartsWith("Error"))
                {
                    ret = "Error " + ErrorMsg;
                }
                else
                {
                    ret = ErrorMsg;
                }
            }

            return ret;
        }
    }
}
