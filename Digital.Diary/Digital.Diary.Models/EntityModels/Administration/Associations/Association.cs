using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Diary.Models.EntityModels.Administration.Associations;

[Table(nameof(Association), Schema = "Administration.Associations")]
public class Association
{
    public Guid Id { get; set; } = default!;
    public string AssociationName { get; set; } = default!; 
    public ICollection<AssociationEmployee>? AssociationEmployees { get; set; } = new List<AssociationEmployee>();
}