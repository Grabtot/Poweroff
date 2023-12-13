namespace Poweroff.Models
{
    public struct PoweroffResult(bool successful)
    {
        public bool Successful { get; set; } = successful;
    }
}
