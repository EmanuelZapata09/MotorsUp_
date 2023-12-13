namespace MotorsUp_.Models
{
    internal class DateNotInPastAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}