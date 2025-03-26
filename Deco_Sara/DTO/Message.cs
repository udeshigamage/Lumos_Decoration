namespace Deco_Sara.DTO
{
    public class Message<TEntity>
    {
        public string Status { get; set; } = "E";
        public string Text { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public TEntity Result { get; set; }

    }
}
