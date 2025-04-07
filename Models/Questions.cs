namespace MyMvcExamProject.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ICollection<Option> Options { get; set; }  // Şıklar ile ilişki
        public int CorrectOptionIndex { get; set; }
    }

}