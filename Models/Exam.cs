using MyMvcExamProject.Models;

public class Exam
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<ExamResult> Results { get; set; }
}
