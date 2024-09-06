namespace TODOList.Models
{
    public class TODO
    {
        public int Id { get; set; }
        public string Tarefa { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty ;
        public bool feto { get; set; } = false;
    }
}
