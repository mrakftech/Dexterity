using Domain.Entities.Settings.Immunisation;

namespace Services.Features.Settings.Dtos.Immunisations;

public class CourseDto
{
    public Course Course { get; set; }
    public List<Shot> Shots { get; set; }
}